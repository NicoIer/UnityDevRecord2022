namespace Nico.ECC.Template
{
    public abstract class TemplateController<T>: IController<T>
    {
        public T owner { get; }

        public TemplateController(T owner)
        {
            this.owner = owner;
        }
        public abstract void OnEnable();
        public abstract void OnDisable();
        public abstract void Start();
        public abstract void Update();
        public abstract void FixedUpdate();
        
        
    }
}