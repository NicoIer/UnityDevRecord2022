using Nico.Utils.Core;
using UnityEngine;

namespace RPG
{
    public class PlayerInput : IComponent<Player>
    {
        public Player owner { get; set; }
        private readonly NormalControls oper;
        public Vector2 Move => oper.Player.Move.ReadValue<Vector2>();
        public bool Run => oper.Player.Run.WasPerformedThisFrame();
        public bool Attack => oper.Player.NormalAttack.WasPressedThisFrame();

        public PlayerInput(Player owner)
        {
            this.owner = owner;
            oper = new NormalControls();
        }

        #region IComponent

        public void Enable()
        {
            oper.Player.Enable();
        }


        public void Disable()
        {
            oper.Player.Disable();
        }

        #endregion
    }
}