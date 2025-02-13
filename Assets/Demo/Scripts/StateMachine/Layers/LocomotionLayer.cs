using UnityEngine;

namespace ActionDemo
{
	public class LocomotionLayer : LayerBase
	{
		enum LocomotionState
		{
			Idle,
			Move,
			Dead,
		}

		LocomotionState currentState;

		IdleState idleState;
		MoveState moveState;


		InputResolver inputResolver;
		CharacterMovement movement;

		LocomotionSettings settings;
		float currentVelocity;
		float currentMoveSpeed;

		public LocomotionLayer()
		{
			currentState = LocomotionState.Idle;

			idleState = new IdleState(this, new IdleStateBehaviour());
			moveState = new MoveState(this, new MoveStateBehaviour());
		}

		public void Update()
		{
			UpdateRotateInput();
			UpdateMovement();
			ApplyMovement();


		}

		void UpdateRotateInput()
		{
			var rotationInput = inputResolver.LastRotateInput;
			rotationInput.y = 0;
			//if (rotationInput.sqrMagnitude < 0.0001f)
			//{
			//	// 回転入力がなくなったら、今の回転を目標回転ということにする。
			//	movement.RotationTarget = Mathf.Atan2(movement.Direction.x, movement.Direction.z) * Mathf.Rad2Deg;
			//	movement.RotationSeconds = -1;
			//	return;
			//}

			//rotationInput.Normalize();

			//if (stateController.RotationSpeed < 0)
			//{
			//	// MDCharacterRecord.RotationSpeedに負数が設定されていたら即回転
			//	movement.Direction = rotationInput;
			//	movement.RotationSeconds = -1;
			//	return;
			//}

			//// rotationStatus度を1秒で回れる回転性能。何秒で回転するか算出する
			//if (movement.RotationSeconds < 0)
			//{
			//	movement.RotationStart = Mathf.Atan2(movement.Direction.x, movement.Direction.z) * Mathf.Rad2Deg;
			//	movement.RotationTarget = Mathf.Atan2(rotationInput.x, rotationInput.z) * Mathf.Rad2Deg;
			//	movement.RotationSeconds = 0;
			//}

			//// 回転
			//movement.RotationSeconds += Time.deltaTime;
			//CharacterMovementController.UpdateRotation(ref movement, stateController);
		}

		void UpdateMovement()
		{
			// 移動入力を更新する
			movement.Acceleration = settings.MaxMoveVelocity / settings.AccelMoveTime;
			movement.Deceleration = settings.MaxMoveVelocity / settings.DecelMoveTime;

			var worldMove = inputResolver.LastMoveInput;
			var move = new Vector3(worldMove.x, 0f, worldMove.z);
			var inputMagnitude = move.magnitude;
			if (inputMagnitude > 0f)
			{
				currentVelocity = Mathf.Min(currentVelocity + movement.Acceleration * Time.deltaTime, settings.MaxMoveVelocity * inputMagnitude);
				movement.Direction = worldMove / inputMagnitude;
			}
			else
			{
				currentVelocity = Mathf.Max(currentVelocity - movement.Deceleration * Time.deltaTime, 0f);
			}

			// 移動位置更新
			movement.Velocity = movement.Direction * currentVelocity;
			movement.Position += movement.Velocity * Time.deltaTime;
		}

		void ApplyMovement()
		{
			//var lastRotation = monitor.TargetRoot.rotation;
			//monitor.TargetRoot.position = movement.Position;
			//monitor.TargetRoot.rotation = Quaternion.LookRotation(movement.Direction);

			//var moveSpeed = Mathf.InverseLerp(0f, Settings.MaxMoveVelocity, movement.Velocity.magnitude);
			//var rotationFactor = lastRotation != monitor.TargetRoot.rotation ? Settings.MaxMoveVelocity / 4 : 0;

			//// 本来は回転は回転用のモーションやステートがあるべきだと思いますが、いったん移動と同じモーションを借ります
			////CharacterAnimatorParameters.MoveSpeed.Set(Animator, Mathf.Max(velocityFactor, rotationFactor));
			//// 試しに回転時は足を動かなくします 05/19
			//CharacterAnimatorParameters.MoveSpeed.Set(Animator, moveSpeed);

			//// BlendTreeの仕様上、Blend0のモーションにあるAnimationEventは発火されないが、内部としてはモーションはずっと再生されている
			//// 移動を始めるタイミングでrunモーションの0フレ目にあるAnimationEventを発火させるため、毎回0からアニメーションをスタートさせる
			//// 副作用で、MoveステートをExitする判定がrunモーション０フレAnimationEvent発火後に発生しEndRangedNotify()が実行される。そのため直後のLateUpdateでRangedNotifyを取得することができない
			//if (currentMoveSpeed == 0 && moveSpeed > 0)
			//{
			//	Animator.Play("Move", 0, 0);
			//}

			//currentMoveSpeed = moveSpeed;
		}
	}
}
