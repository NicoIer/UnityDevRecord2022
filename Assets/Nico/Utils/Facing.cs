using UnityEngine;

namespace Nico.Utils
{
    public static class Facing
    {
        public static void Facing2DDirection(Transform transform,Vector2 direction)
        {
            if (direction.x < 0)
            {
                transform.localScale = new Vector3(1, -1, 1);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            transform.right = direction;
        }
        
        public static Vector2 Self2MouseDirection(Transform transform,Camera camera)
        {
            var mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

            var direction = mousePosition - transform.position;
            direction.z = 0;
            direction = direction.normalized;
            return direction;
        }
    }
}