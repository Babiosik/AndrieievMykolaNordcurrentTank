using UnityEngine;

namespace Tanks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TankMovement : MonoBehaviour
    {
        [Tooltip("In units/sec")]
        [SerializeField] protected float moveSpeed;
        [Tooltip("In units")]
        [SerializeField] protected float turnRadius;

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
            float angSpeedDeg = -directionMove.x * moveSpeed / turnRadius * Mathf.Rad2Deg;
            rb.MoveRotation(rb.rotation + angSpeedDeg * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + (Vector2)transform.up * directionMove.y * moveSpeed * Time.fixedDeltaTime);
        }

        public Vector2 DirectionVector { set => directionMove = value; }
    }
}