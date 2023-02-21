namespace Nico.Utils.Core
{
    public interface IStateMachine<T> : IController<T>
    {
        public IState<T> cur { get; }
        void Change<T1>() where T1 : IState<T>;
    }
}