using UnityEngine;

namespace Enemy.Movement.States
{
    public class EnemyCollisionState : EnemyMoveState
    {
        private ContactPoint2D contactPoint;

        public void SetContactPoint(ContactPoint2D contactPoint)
        {
            this.contactPoint = contactPoint;
        }

        public override void Enter()
        {
            Vector2 inDir = contactPoint.otherRigidbody.transform.up;
            Vector2 normal = contactPoint.normal;

            Vector2 tangent = new Vector2(-normal.y, normal.x);
            float side = Mathf.Sign(Vector3.Cross(inDir, tangent).z);

            // Possible add backward move for more realistic pilot behavior
            Vector2 direction = side > 0 ? Vector2.left : Vector2.right;
            direction.y = -.1f;

            Direction = direction;
        }
    }
}