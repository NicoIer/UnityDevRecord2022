using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Nico.Editor
{
    [CreateAssetMenu(fileName = "Test", menuName = "Test")]
    public class Test : ScriptableObject
    {
        public string filePath = "Excels/";


        [Button("测试Excel To Assets")]
        public void T()
        {
            //第一步 获取所有的Excel文件路径
            //第二步 遍历所有的Excel文件路径 读取Excel文件
            //第三步 读取Excel文件中的所有Sheet
            //第四步 读取Sheet中的前两行数据
            //根据第2,3行数据生成类

            var filesPath = Directory.GetFiles(filePath);
            var csvFilesPath = filesPath.Where(_ => _.EndsWith(".xlsx"));
            Debug.Log($"{string.Join(",", csvFilesPath)}");

            //获取第一个Excel文件
            var csvFilePath = csvFilesPath.First();
            var fileInfo = new FileInfo(csvFilePath);
            //读取Excel文件
            ExcelPackage excelPackage = new ExcelPackage(fileInfo);
            //读取Excel的工作表
            var workbook = excelPackage.Workbook;
            var sheets = workbook.Worksheets;
            //获取第一个Sheet
            var sheet = sheets.First();
            //将第一行数据读取出来 参数分别是左上角的行列，右下角的行列
            List<List<string>> data = new List<List<string>>();
            for (int i = 1; i < 4; i++)
            {
                var row = sheet.Cells[i, 1, i, sheet.Dimension.End.Column].Select(_ => _.Value.ToString()).ToList();
                data.Add(row);
            }

            foreach (var row in data)
            {
                Debug.Log($"{string.Join(",", row)}");
            }
            //生成类的文本信息
            
            var className = sheet.Name;
            var classContent = $"public class {className}\n{{\n";
            //1,2行数据
            for (int col = 0; col < sheet.Dimension.End.Column; col++)
            {
                var type = $"{data[2][col]}";
                var name = $"{data[1][col]}";
                classContent += "\t" + $"public {type} {name};\n";
            }

            classContent += "}";

            Debug.Log(classContent);
            //生成类的存储信息
        }
    }
}