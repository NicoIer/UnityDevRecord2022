using Nico.Algorithm;
using Nico.ECC.Template;

namespace ShootGame
{
    public class PositionController: TemplateController<Weapon>
    {
        public PositionController(Weapon owner) : base(owner)
        {
        }

        public override void OnEnable()
        {
            
        }

        public override void OnDisable()
        {
            
        }

        public override void Start()
        {
           
        }

        public override void Update()
        {
            owner.transform.localPosition = owner.player.attribute.facingDirection == Direction2DEnum.Left ? owner.data.leftPostion : owner.data.rightPostion;
        }

        public override void FixedUpdate()
        {
            
        }
    }
}