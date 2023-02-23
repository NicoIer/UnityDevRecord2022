using UnityEngine;
using UnityEngine.InputSystem;

namespace Nico.ECC.Template
{
    public class TemplateInput<T> : IComponent<T>
    {
        public T owner { get; set; }
        protected readonly NormalControls controls;
        public Vector2 move => controls.Player.Move.ReadValue<Vector2>();
        public bool rightAttack => controls.Player.NormalAttack.triggered;
        public bool leftAttack => controls.Player.SpecialAttack.triggered;
        public Vector2 mousePostion => Mouse.current.position.ReadValue();
        public Vector2 arrow => controls.Player.Arrow.ReadValue<Vector2>();
        public Vector2 rotate => controls.Player.Rotate.ReadValue<Vector2>();

        public TemplateInput(T owner)
        {
            this.owner = owner;
            controls = new NormalControls();
        }

        #region IComponent

        public void OnEnable()
        {
            controls.Player.Enable();
        }


        public void OnDisable()
        {
            controls.Player.Disable();
        }

        #endregion
    }
}