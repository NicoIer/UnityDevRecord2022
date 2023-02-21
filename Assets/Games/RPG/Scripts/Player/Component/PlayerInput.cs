using Nico.Template;
using Nico.Utils.Core;
using UnityEngine;

namespace RPG
{
    public class PlayerInput : TemplateInput<Player>
    {
        public Vector2 Move => controls.Player.Move.ReadValue<Vector2>();
        public bool Run => controls.Player.Run.WasPerformedThisFrame();
        public bool Attack => controls.Player.NormalAttack.WasPressedThisFrame();

        public PlayerInput(Player owner) : base(owner)
        {
        }
    }
}