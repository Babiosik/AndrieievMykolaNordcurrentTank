using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TankMovement : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float turnSpeed;

        protected Rigidbody2D rb;
        protected Vector2 directionMove;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (directionMove != Vector2.zero)
                DoMove();
        }

        protected virtual void DoMove()
        {
            rb.MovePosition(rb.position + (Vector2)transform.up * directionMove.y * moveSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation - directionMove.x * turnSpeed * Time.fixedDeltaTime);
        }

        public Vector2 DirectionVector { set => directionMove = value; }
    }
}