using UnityEngine;

namespace Mirror.Examples.Pong
{
    public class Player : NetworkBehaviour
    {
        public float speed = 30;
        public Rigidbody2D rigidbody2d;

		private void Start()
		{
            tag = "Player";
            if (isServer)
                name = "Left Paddle";
            else
                name = "Right Paddle";

        }

		// need to use FixedUpdate for rigidbody
		void FixedUpdate()
        {
            
            // only let the local player control the racket.
            // don't control other player's rackets
            if (isLocalPlayer)
                rigidbody2d.velocity = new Vector2(0, Input.GetAxisRaw("Vertical")) * speed * Time.fixedDeltaTime;
        }
    }
}
