using Nico.ECC;
using Nico.ECC.Template;
using Nico.Utils;
using UnityEngine;

namespace DungeonGame.Controller
{
    public class FacingMouse<T> : TemplateController<T> where T : TemplateEntityMonoBehavior<T>
    {
        public FacingMouse(T owner) : base(owner)
        {
        }

        public override void OnEnable()
        {
            
        }

        public override void OnDisable()
        {
            
        }

        public override void Start()
        {
            
        }

        public override void Update()
        {
            var direction = Facing.Self2MouseDirection(owner.transform,Camera.main);
            Facing.Facing2DDirection(owner.transform, direction);
        }

        public override void FixedUpdate()
        {
            
        }
    }
}