using Nico.Utils.Core;
using UnityEngine;

namespace WeaponSys.Components
{
    public class WeaponSprite : IController<Weapon>
    {
        public Weapon owner { get; }
        private SpriteRenderer baseRenderer;
        private SpriteRenderer weaponRenderer;

        public WeaponSprite(Weapon owner)
        {
            this.owner = owner;
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
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