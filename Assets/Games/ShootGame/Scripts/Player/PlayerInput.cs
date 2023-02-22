using Nico.ECC;
using UnityEngine;

namespace ShootGame
{
    public class PlayerInput: IComponent<Player>
    {
        public Player owner { get; set; }
        private readonly NormalControls controls;
        public Vector2 move => controls.Player.Move.ReadValue<Vector2>();
        public bool rightAttack => controls.Player.NormalAttack.triggered;
        public bool leftAttack => controls.Player.SpecialAttack.triggered;
        public PlayerInput(Player owner)
        {
            this.owner = owner;
            controls = new NormalControls();
        }
        public void OnEnable()
        {
            controls.Player.Enable();
        }

        public void OnDisable()
        {
            controls.Player.Disable();
        }
    }
}