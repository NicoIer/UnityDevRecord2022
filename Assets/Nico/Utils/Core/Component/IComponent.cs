namespace Nico.Utils.Core
{
    public interface IComponent<T>
    {
        public T owner { get; set; }
        void Enable();
        void Disable();
    }
}