using Nico.ECC;
using Nico.Interface;
using UnityEngine;

namespace WeaponSys
{
    public class AttackDamageController : IController<Weapon>
    {
        public Weapon owner { get; }
        private readonly HitBoxController hitBoxController;
        private AttackDamageData data=>owner.data.GetDataElement<AttackDamageData>();
        public AttackDamageController(Weapon owner)
        {
            this.owner = owner;
            hitBoxController = owner.GetIController<HitBoxController>();
        }

        private void _handle_attack_hit(Collider2D[] collider2Ds)
        {
            foreach (var collider2D in collider2Ds)
            {
                if (collider2D.TryGetComponent(out IDamageAble damageAble))
                {
                    damageAble.TakeDamage(data[owner.baseAc.curAttackIndex]);
                }
            }
        }

        public void OnEnable()
        {
            hitBoxController.OnDetectHitBox += _handle_attack_hit;
        }

        public void OnDisable()
        {
            hitBoxController.OnDetectHitBox -= _handle_attack_hit;
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