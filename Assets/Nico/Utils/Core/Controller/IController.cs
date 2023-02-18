namespace Nico.Utils.Core
{
    public interface IController<T>: IComponent
    {
        T owner { get;}
        void Start();
        void Update();
        void FixedUpdate();
    }
}