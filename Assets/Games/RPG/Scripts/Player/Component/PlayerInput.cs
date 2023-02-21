using Nico.ECC.Template;
using Nico.ECC;
using UnityEngine;

namespace RPG
{
    public class PlayerInput : TemplateInput<Player>
    {
        public bool Run => controls.Player.Run.WasPerformedThisFrame();
        public PlayerInput(Player owner) : base(owner)
        {
        }
    }
}