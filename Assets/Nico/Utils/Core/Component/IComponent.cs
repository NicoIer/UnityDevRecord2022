namespace Nico.Utils.Core
{
    /// <summary>
    /// 组件用于存储信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IComponent<T>
    {
        public T owner { get; set; }
        void Enable();
        void Disable();
    }
}