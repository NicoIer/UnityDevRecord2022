using System;

namespace Nico.ECC.Data
{
    /// <summary>
    /// 数据元素 需要表标记依赖它的类型 以便于反射 自动创建
    /// 简单的说 某个Controller依赖于这项数据 则relyType为Controller的类型
    /// 这样做的目的是 遍历DataContainer时,可以根据relyType来判断是否需要创建对应Controller
    /// </summary>
    [Serializable]
    public abstract class DataElement
    {
        public Type relyType;//依赖的类型
    }
}