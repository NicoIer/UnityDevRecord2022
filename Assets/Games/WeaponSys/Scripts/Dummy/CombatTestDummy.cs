using Nico.ECC.Template;
using Nico.Interface;
using UnityEngine;

namespace Games.WeaponSys.Scripts.Dummy
{
    public class CombatTestDummy : TemplateEntityMonoBehavior<CombatTestDummy>,IDamageAble
    {

        private Animator ac;
        protected override void _get_mono_components()
        {
            ac = GetComponent<Animator>();
        }

        protected override void _init_components()
        {
            
        }

        protected override void _init_controller()
        {
            
        }

        public void TakeDamage(float amount)
        {
            Debug.Log($"{name}受到{amount}点伤害");
            // Instantiate()
            ac.SetTrigger("damage");
            // Destroy(gameObject);
        }
    }
}