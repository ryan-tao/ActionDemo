using UnityEngine;

namespace ActionDemo
{
	public class CharacterMovementController
	{
		Transform targetRoot;
		CharacterMovement movement;

		public CharacterMovementController(Transform targetRoot, CharacterMovement movement)
		{
			this.targetRoot = targetRoot;
			this.movement = movement;
		}

		public void OnAnimatorMove(float deltaTime, Vector3 deltaPosition, Quaternion deltaRotation)
		{
			UpdateRootMotion(deltaPosition, deltaRotation, Vector3.one);
			UpdateCollision();
			ApplyMovement();
		}

		void ApplyMovement()
		{
			targetRoot.position = movement.Position;
			targetRoot.rotation = Quaternion.LookRotation(movement.Direction);
		}

		void UpdateRootMotion(Vector3 deltaPosition, Quaternion deltaRotation, Vector3 positionScaleRate)
		{
			movement.Position += Vector3.Scale(deltaPosition, positionScaleRate);
			movement.Direction = deltaRotation * movement.Direction;
		}

		void UpdateCollision()
		{
			// TODO 障害物などの当たり判定
		}
	}
}
