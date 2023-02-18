using Nico.Utils.Core;

namespace RPG
{
    public class PlayerController : IController<Player>
    {
        public Player owner { get; private set; }
        
        public PlayerStateMachine stateMachine { get; private set; }

        public PlayerController(Player owner)
        {
            this.owner = owner;
            stateMachine = new PlayerStateMachine(owner);

        }

        #region Controller Life

        public void Start()
        {
            stateMachine.Start();
        }

        public void Update()
        {
            stateMachine.Update();
        }


        public void FixedUpdate()
        {
            stateMachine.FixedUpdate();
        }

        #endregion

        public void Enable()
        {
            stateMachine.Enable();
        }

        public void Disable()
        {
        }
    }
}