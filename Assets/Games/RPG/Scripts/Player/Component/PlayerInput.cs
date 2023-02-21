using Nico.Template;
using Nico.Utils.Core;
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