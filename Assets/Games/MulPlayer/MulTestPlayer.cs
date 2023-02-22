using System;
using Mirror;
using UnityEngine;

namespace Games.MulPlayer
{
    public class MulTestPlayer : NetworkBehaviour
    {
        private NormalControls controls;

        private void Awake()
        {
            controls = new NormalControls();
            controls.Player.Enable();
        }

        private void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                var move = controls.Player.Move.ReadValue<Vector2>();
                Debug.Log(move);
                transform.position += new Vector3(move.x, move.y, 0) * 0.1f;
            }
        }
    }
}