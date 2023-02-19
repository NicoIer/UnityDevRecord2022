namespace Nico.Utils.Core
{
    /// <summary>
    /// 控制器用于控制行为
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IController<T>
    {
        T owner { get; }
        void Enable();
        void Disable();
        void Start();
        void Update();
        void FixedUpdate();
    }
}