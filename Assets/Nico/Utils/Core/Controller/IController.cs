namespace Nico.Utils.Core
{
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