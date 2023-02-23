using Nico.ECC;
using Nico.ECC.Template;
using Nico.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DungeonGame.Controller
{
    public class FacingRightStick<T> : TemplateController<T> where T : TemplateEntityMonoBehavior<T>
    {
        public FacingRightStick(T owner) : base(owner)
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
            var direction = Gamepad.current.rightStick.ReadValue();
            Facing.Facing2DDirection(owner.transform, direction);
        }

        public override void FixedUpdate()
        {
            
        }
    }
}