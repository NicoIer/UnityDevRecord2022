using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Nico.Data;
using Nico.Utils;
using OfficeOpenXml;
using Sirenix.OdinInspector;
using Unity.Assertions;
using UnityEditor;
using UnityEngine;
using DataTable = Nico.Data.DataTable;

namespace Nico.Editor
{
    [CreateAssetMenu(fileName = "ExcelToAsset", menuName = "ExcelToAsset")]
    public class ExcelToAsset : ScriptableObject
    {
        [LabelText("Excel目录")] public string directorPath = "Excels/";
        [LabelText("脚本保存目录")] public string csSaveDirePath = "Assets/Test/";
        [LabelText("So保存目录")] public string soSaveDirPath = "Assets/Test/SO/";


        [Button("生成SO数据")]
        public void GenerateSo()
        {
            AssetDatabase.Refresh();
            var filesPath = Directory.GetFiles(directorPath);
            var excelsPath = filesPath.Where(_ => _.EndsWith(".xlsx"));

            if (!Directory.Exists(soSaveDirPath))
            {
                Directory.CreateDirectory(soSaveDirPath);
            }

            foreach (var excelPath in excelsPath)
            {
                Debug.Log($"从{excelPath}读取数据");
                var excelData = _get_excel_data(excelPath);
                foreach (var (sheetName, sheetData) in excelData)
                {
                    var structName = $"{sheetName}Data";
                    var fullStructName = $"Nico.Data.{structName}";

                    var tableName = $"{sheetName}DataTable";
                    var fullTableName = $"Nico.Data.{tableName}";

                    //创建DataTableSO 
                    DataTable dataTable = CreateInstance(tableName) as DataTable;
                    if (dataTable == null)
                    {
                        Debug.LogError("创建DataTableSO失败");
                        continue;
                    }

                    //获取对应的类型
                    Type dataType = TypeUtil.GetTypeByString(fullStructName);
                    //读取2,3行获取 attributeNames 和 attributeTypes
                    List<string> attributeTypes = new List<string>();
                    List<string> attributeNames = new List<string>();
                    var colCount = sheetData.GetLength(1);
                    //获取attributeTypes
                    for (int col = 0; col < colCount; col++)
                    {
                        var attributeName = sheetData[1, col];
                        attributeNames.Add(attributeName);
                        var attributeType = sheetData[2, col];
                        attributeTypes.Add(attributeType);
                    }

                    //读取数据
                    for (int row = 3; row < sheetData.GetLength(0); row++)
                    {
                        var structObj = Activator.CreateInstance(dataType); //创建对应类型的实例
                        for (int col = 0; col < colCount; col++)
                        {
                            var attributeName = attributeNames[col];
                            var attributeType = attributeTypes[col];
                            //读取数据 
                            var attributeValue = sheetData[row, col];

                            FieldInfo fieldInfo = dataType.GetField(attributeName);
                            if (fieldInfo == null)
                            {
                                Debug.LogError($"类型{dataType}中不存在属性{attributeName}");
                                continue;
                            }

                            if (!string.IsNullOrEmpty(attributeValue))
                            {
                                fieldInfo.SetValue(structObj, Convert.ChangeType(attributeValue, fieldInfo.FieldType));
                            }
                            else
                            {
                                Debug.LogWarning($"类型{dataType}的属性{attributeName},对应的值缺失,value:{attributeValue}");
                                fieldInfo.SetValue(structObj, null);
                            }
                        }

                        var metaData = structObj as MetaData;
                        dataTable.Add(metaData);
                    }

                    var soSavePath = $"{soSaveDirPath}/{tableName}.asset";
                    AssetDatabase.CreateAsset(dataTable, soSavePath);
                }

                AssetDatabase.Refresh();
            }
        }

        [Button("生成代码文件")]
        public void GenerateCode()
        {
            var filesPath = Directory.GetFiles(directorPath);
            var excelsPath = filesPath.Where(_ => _.EndsWith(".xlsx"));

            List<(string, string)> scriptContents = new List<(string, string)>();
            foreach (var excelPath in excelsPath)
            {
                scriptContents.AddRange(GenerateScriptText(excelPath));
            }

            foreach (var (sheetName, scriptText) in scriptContents)
            {
                var csFileName = $"{sheetName}DataTable.cs";
                var csFileSavePath = $"{csSaveDirePath}{csFileName}";
                if (!Directory.Exists(csSaveDirePath))
                {
                    Directory.CreateDirectory(csSaveDirePath);
                }

                if (!File.Exists(csFileSavePath))
                {
                    File.Create(csFileSavePath).Close();
                }

                File.WriteAllText(csFileSavePath, scriptText);
            }

            //保存类的存储信息
            AssetDatabase.Refresh();
            UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation(); //立刻重新编译
        }


        public static List<(string, string)> GenerateScriptText(string excel_path)
        {
            List<(string, string)> contents = new List<(string, string)>();

            var fileInfo = new FileInfo(excel_path);
            ExcelPackage excelPackage = new ExcelPackage(fileInfo);
            var workbook = excelPackage.Workbook;
            var sheets = workbook.Worksheets;
            foreach (var sheet in sheets)
            {
                var className = sheet.Name;
                var names = sheet.Cells[2, 1, 2, sheet.Dimension.End.Column].Select(_ => _.Value.ToString())
                    .ToList();
                var types = sheet.Cells[3, 1, 3, sheet.Dimension.End.Column].Select(_ => _.Value.ToString())
                    .ToList();
                var fileContent = _get_class_define(className, "Nico.Data", types, names);
                contents.Add((className, fileContent));
            }

            return contents;
        }


        private static List<(string, string[,])> _get_excel_data(string excel_path)
        {
            var fileInfo = new FileInfo(excel_path);
            //读取Excel文件
            ExcelPackage excelPackage = new ExcelPackage(fileInfo);
            //读取Excel的工作表
            var workbook = excelPackage.Workbook;
            var sheets = workbook.Worksheets;
            //获取第一个Sheet
            List<(string, string[,])> results = new List<(string, string[,])>();
            foreach (var excelWorksheet in sheets)
            {
                var row = excelWorksheet.Dimension.End.Row;
                var column = excelWorksheet.Dimension.End.Column;
                string[,] data = new string[row, column];
                for (int i = 1; i <= row; i++)
                {
                    for (int j = 1; j <= column; j++)
                    {
                        var value = excelWorksheet.Cells[i, j].Value;
                        string valueStr = value?.ToString();
                        data[i - 1, j - 1] = valueStr;
                    }
                }

                results.Add((excelWorksheet.Name, data));
            }

            return results;
        }

        private static string _get_class_define(string className, string nameSpace, List<string> types,
            List<string> names)
        {
            var csFile = new StringBuilder(2048);
            csFile.Append("using System;\n");
            csFile.Append("using System.Collections.Generic;\n");
            csFile.Append("using UnityEngine;\n");
            csFile.AppendFormat("namespace {0}\n", nameSpace);
            csFile.Append("{\n");
            csFile.Append("\t[Serializable]\n");
            csFile.Append($"\tpublic class " + className + "Data: MetaData" + "\n");
            csFile.Append("\t{\n");

            Assert.IsTrue(types.Count == names.Count);

            for (var i = 0; i < types.Count; i++)
            {
                var type = types.ElementAt(i);
                var name = names.ElementAt(i);
                csFile.AppendFormat("\t\tpublic {0} {1};\n", type, name);
            }


            csFile.Append("\t\t}\n");

            csFile.AppendFormat("\tpublic class {0} : DataTable\n", className + "DataTable");
            csFile.Append("\t{\n");

            csFile.AppendFormat("\t\tpublic List<{0}> dataList = new();\n", className + "Data");
            csFile.Append("\t\tpublic int Count => dataList.Count;\n");
            csFile.AppendFormat("\t\tpublic {0} GetByID(int idx)\n", className + "Data");
            csFile.Append("\t\t{\n");
            csFile.AppendFormat("\t\t\treturn ({0})dataList[idx];\n", className + "Data");
            csFile.Append("\t\t}\n");


            csFile.Append("\t\tpublic override void Add(MetaData data)\n");
            csFile.Append("\t\t{\n");
            csFile.AppendFormat("\t\t\tdataList.Add(({0})data);\n", className + "Data");
            csFile.Append("\t\t}\n");


            csFile.Append("\t}\n");

            csFile.Append("}\n");

            return csFile.ToString();
        }
    }
}