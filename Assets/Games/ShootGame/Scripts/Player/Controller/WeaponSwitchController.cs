using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Nico.ECC;
using Nico.ECC.Template;
using UnityEngine;

namespace ShootGame
{
    public class WeaponSwitchController : TemplateController<Player>
    {
        Vector2 arrow => owner.input.arrow;
        private Weapon[] weapons;
        private int curWeaponIdx = -1;
        private bool canSwitch = true;
        private float interval = 0.5f;

        public WeaponSwitchController(Player owner) : base(owner)
        {
            weapons = new[] { owner.primaryWeapon, owner.secondaryWeapon };
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
            if (arrow.y > 0 && canSwitch) //要等待指定间隔时间后才能切换武器
            {
                canSwitch = false;
                _switch_weapon();
                UniTask.Delay(TimeSpan.FromSeconds(0.5)).ContinueWith(() => canSwitch = true).Forget();
            }
        }

        public override void FixedUpdate()
        {
        }

        private void _switch_weapon()
        {
            Debug.Log("切换武器");
            //取消上一个武器
            if (curWeaponIdx != -1)
            {
                weapons[curWeaponIdx].SetActive(false);
            }

            //切换到下一个武器
            curWeaponIdx = (curWeaponIdx + 1) % weapons.Length;
            weapons[curWeaponIdx].SetActive(true);
            return;
        }
    }
}