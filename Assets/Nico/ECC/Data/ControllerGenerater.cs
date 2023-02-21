using Nico.ECC.Template;

namespace Nico.ECC.Data
{
    public class ControllerGenerater
    {
        public void Generate<T>(T enity,DataContainer<T> entityData) where T: TemplateEntityMonoBehavior<T>
        {
            
        }
    }
}