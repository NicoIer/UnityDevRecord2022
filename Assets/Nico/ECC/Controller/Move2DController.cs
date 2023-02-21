using Nico.Algorithm;
using UnityEngine;

namespace Nico.ECC
{
    //ToDo fix it
    public class Move2DController<T> : IController<T>
    {
        public T owner { get; }
        public Rigidbody2D rb { get; }
        public Direction2DEnum facing { get; private set; }
        public Vector2 velocity;
        public Move2DController(T owner, Rigidbody2D rb)
        {
            this.owner = owner;
            this.rb = rb;
        }
        private void _handle_start_move()
        {
        }

        private void _handle_stop_move()
        {
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