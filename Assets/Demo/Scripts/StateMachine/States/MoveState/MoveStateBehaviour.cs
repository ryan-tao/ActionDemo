using UnityEngine;

namespace ActionDemo
{
	public class MoveStateBehaviour : StateBehaviourBase
	{
		InputResolver inputResolver;
		LocomotionSettings settings;
		CharacterMovement movement;
		float currentVelocity;
		float deltaTime;

		public MoveStateBehaviour(InputResolver inputResolver, CharacterMovement movement, LocomotionSettings settings)
		{
			this.inputResolver = inputResolver;
			this.movement = movement;
			this.settings = settings;
			OnStateUpdateBehaviour = UpdateMovement;
		}

		void UpdateMovement(IState.RuntimeInfo runtimeInfo, float deltaTime)
		{
			this.deltaTime = deltaTime;
			UpdateRotateInput();
			UpdateMovementInput();
			UpdateCollision();
		}

		void UpdateMovementInput()
		{
			movement.Acceleration = settings.MaxMoveVelocity / settings.AccelMoveTime;
			movement.Deceleration = settings.MaxMoveVelocity / settings.DecelMoveTime;

			var worldMove = inputResolver.LastMoveInput;
			var move = new Vector3(worldMove.x, 0f, worldMove.z);
			var inputMagnitude = move.magnitude;
			if (inputMagnitude > 0f)
			{
				currentVelocity = Mathf.Min(currentVelocity + movement.Acceleration * deltaTime, settings.MaxMoveVelocity * inputMagnitude);
				movement.Direction = worldMove / inputMagnitude;
			}
			else
			{
				currentVelocity = Mathf.Max(currentVelocity - movement.Deceleration * deltaTime, 0f);
			}

			movement.Velocity = movement.Direction * currentVelocity;
			movement.Position += movement.Velocity * deltaTime;
		}

		void UpdateRotateInput()
		{
			// TODO
		}

		void UpdateCollision()
		{
			// TODO
		}
	}
}
