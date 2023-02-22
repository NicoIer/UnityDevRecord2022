
using UnityEditor;
using UnityEngine;

// namespace Nico.Editor
// {
//     [CustomPropertyDrawer(typeof(DataContainer<>), true)]
//     public class DataContainerDrawer : PropertyDrawer
//     {
//         public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//         {
//             EditorGUI.BeginProperty(position, label, property);
//     
//             // 获取List属性
//             var dataListProp = property.FindPropertyRelative("dataList");
//     
//             // 显示Label
//             position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
//     
//             // 显示List元素数量
//             var indent = EditorGUI.indentLevel;
//             EditorGUI.indentLevel = 0;
//             var listSizeRect = new Rect(position.x, position.y, 30, position.height);
//             var listSize = EditorGUI.IntField(listSizeRect, dataListProp.arraySize);
//             EditorGUI.indentLevel = indent;
//     
//             if (listSize != dataListProp.arraySize)
//             {
//                 // 调整List元素数量
//                 dataListProp.arraySize = listSize;
//             }
//     
//             // 显示List元素
//             position.x += 30;
//             for (int i = 0; i < dataListProp.arraySize; i++)
//             {
//                 var elementProp = dataListProp.GetArrayElementAtIndex(i);
//                 var elementRect = new Rect(position.x, position.y, position.width, EditorGUI.GetPropertyHeight(elementProp));
//                 EditorGUI.PropertyField(elementRect, elementProp);
//                 position.y += elementRect.height;
//             }
//     
//             EditorGUI.EndProperty();
//         }
//
//     }
//
// }