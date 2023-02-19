namespace Nico.Utils.Core
{
    public interface IController<T>: ICoreComponent
    {
        T owner { get;}
        void Start();
        void Update();
        void FixedUpdate();
    }
}