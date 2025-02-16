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

		public void OnAnimatorMove(float deltaTime)
		{
			ApplyMovement();
		}

		void ApplyMovement()
		{
			targetRoot.position = movement.Position;
			targetRoot.rotation = Quaternion.LookRotation(movement.Direction);
		}
	}
}
