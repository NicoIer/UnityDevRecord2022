using UnityEngine;

namespace Nico.Interface
{
    public interface IKnockbackable
    {
        void Knockback(Vector2 angel,float force,float time);
    }
}