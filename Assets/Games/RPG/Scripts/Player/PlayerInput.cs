using Nico.Utils.Core;
using UnityEngine;

namespace RPG
{
    public class PlayerInput : ICoreComponent
    {
        private readonly NormalControls oper;
        public Vector2 Move => oper.Input.Move.ReadValue<Vector2>();

        public PlayerInput()
        {
            oper = new NormalControls();
        }

        #region IComponent

        public void Enable()
        {
            oper.Input.Enable();
        }


        public void Disable()
        {
            oper.Input.Disable();
        }

        #endregion
    }
}