using Nico.Utils.Core;

namespace WeaponSys
{
    public class MoveController : IController<Weapon>
    {
        public Weapon owner { get; }

        public MoveController(Weapon owner)
        {
            this.owner = owner;
        }

        public void OnEnable()
        {
            owner.animationEventHandler.OnStartMove += _handle_start_move;
            owner.animationEventHandler.OnStopMove += _handle_stop_move;
        }

        public void OnDisable()
        {
            owner.animationEventHandler.OnStartMove -= _handle_start_move;
            owner.animationEventHandler.OnStopMove -= _handle_stop_move;
        }

        private void _handle_start_move()
        {
        }

        private void _handle_stop_move()
        {
        }

        public void Start()
        {
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
        }
    }
}