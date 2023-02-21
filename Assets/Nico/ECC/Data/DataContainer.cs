using System.Collections.Generic;
using UnityEngine;

namespace Nico.ECC.Data
{
    //ToDo 实现一个通用的数据存储容器
    //ToDo 为DataContainer实现一个Inspector的绘制器 以便于添加各类DataElement
    //其中包含一个DataElement的列表
    public class DataContainer<T> : ScriptableObject
    {
        [SerializeField] public List<DataElement> dataElements;
    }
}