using UnityEngine;

namespace ActionDemo
{
	public class MoveStateBehaviour : StateBehaviourBase
	{
		float currentVelocity;
		float deltaTime;

		public MoveStateBehaviour()
		{
			OnStateEnterBehaviour = StartMovement;
			OnStateUpdateBehaviour = UpdateMovement;
		}

		void StartMovement(IState.RuntimeInfo runtimeInfo)
		{
			StartMovementAnimation();
		}

		void UpdateMovement(IState.RuntimeInfo runtimeInfo, float deltaTime)
		{
			this.deltaTime = deltaTime;
			UpdateMovementInput();
			UpdateMovementAnimation();
		}

		void UpdateMovementInput()
		{
			var locomotionSettings = State.Layer.StateMachine.LocomotionSettings;
			var movement = State.Layer.StateMachine.Movement;

			movement.Acceleration = locomotionSettings.MaxMoveVelocity / locomotionSettings.AccelMoveTime;
			movement.Deceleration = locomotionSettings.MaxMoveVelocity / locomotionSettings.DecelMoveTime;

			var inputResolver = State.Layer.StateMachine.InputResolver;
			var worldMove = inputResolver.LastMoveInput;
			var move = new Vector3(worldMove.x, 0f, worldMove.z);
			var inputMagnitude = move.magnitude;
			if (inputMagnitude > 0f)
			{
				currentVelocity = Mathf.Min(currentVelocity + movement.Acceleration * deltaTime, locomotionSettings.MaxMoveVelocity * inputMagnitude);
				movement.Direction = worldMove / inputMagnitude;
			}
			else
			{
				currentVelocity = Mathf.Max(currentVelocity - movement.Deceleration * deltaTime, 0f);
			}

			movement.Velocity = movement.Direction * currentVelocity;
			movement.Position += movement.Velocity * deltaTime;
		}

		void StartMovementAnimation()
		{
			var animationManager = State.Layer.StateMachine.AnimationManager;
			animationManager.Move();
		}

		void UpdateMovementAnimation()
		{
			var animationManager = State.Layer.StateMachine.AnimationManager;
			var locomotionSettings = State.Layer.StateMachine.LocomotionSettings;
			var movement = State.Layer.StateMachine.Movement;
			var moveSpeed = Mathf.InverseLerp(0f, locomotionSettings.MaxMoveVelocity, movement.Velocity.magnitude);
			animationManager.SetMoveSpeed(moveSpeed);
		}
	}
}
