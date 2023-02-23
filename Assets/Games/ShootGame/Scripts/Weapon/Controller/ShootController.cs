using Nico.ECC.Template;
using UnityEngine;

namespace ShootGame
{
    public class ShootController: TemplateController<Weapon>
    {
        public ShootController(Weapon owner) : base(owner)
        {
        }

        public override void OnEnable()
        {
            owner.acEventHandler.OnStartAnim += _shoot;
        }

        public override void OnDisable()
        {
            owner.acEventHandler.OnStartAnim -= _shoot;
        }

        public override void Start()
        {

        }

        public override void Update()
        {

        }

        public override void FixedUpdate()
        {
 
        }
        
        private void _shoot()
        {
            Debug.Log("shoot");
            Vector3 mousePosition = owner.player.input.mousePostion;
            mousePosition.z = 10f;
            //ToDO 后续修改为从CameraManager获取位置
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.DrawLine(owner.worldPosition, mousePosition, Color.red);
        }
    }
}