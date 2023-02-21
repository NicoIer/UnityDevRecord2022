namespace Nico.ECC
{
    /// <summary>
    /// 组件用于存储信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IComponent<T>
    {
        public T owner { get; set; }
        void OnEnable();
        void OnDisable();
    }
}