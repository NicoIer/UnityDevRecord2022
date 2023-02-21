using UnityEngine;

namespace Nico.ECC.Template
{
    public class TemplateInput<T> : IComponent<T>
    {
        public T owner { get; set; }
        protected readonly NormalControls controls;
        public Vector2 move => controls.Player.Move.ReadValue<Vector2>();
        public bool rightAttack => controls.Player.NormalAttack.triggered;
        public bool leftAttack => controls.Player.SpecialAttack.triggered;
        
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