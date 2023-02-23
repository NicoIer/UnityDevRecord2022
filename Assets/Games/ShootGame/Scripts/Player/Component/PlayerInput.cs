using Nico.ECC;
using Nico.ECC.Template;
using UnityEngine;

namespace ShootGame
{
    public class PlayerInput: TemplateInput<Player>
    {
        public PlayerInput(Player owner) : base(owner)
        {
        }
    }
}