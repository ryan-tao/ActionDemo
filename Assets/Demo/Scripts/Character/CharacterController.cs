using ActionDemo.Animation;
using UnityEngine;

namespace ActionDemo
{
	public class CharacterController : MonoBehaviour, ISyncAnimatorMove
	{
		[SerializeField] InputReceiver inputReceiver;
		[SerializeField] AnimationManager animationManager;
		[SerializeField] LocomotionSettings locomotionSettings;
		[SerializeField] StateSettings stateSettings;

		InputResolver inputResolver;
		CharacterStateMachine stateMachine;
		CharacterBrain brain;
		CharacterStateController stateController;
		CharacterMovementController movementController;

		float deltaTime;
		CharacterMovement movement;
		CharacterState state;

		void Awake()
		{
			animationManager.Initialize();

			movement = new CharacterMovement();
			state = new CharacterState();

			inputResolver = new InputResolver(inputReceiver);
			stateMachine = new CharacterStateMachine(inputResolver, movement, locomotionSettings, stateSettings, animationManager);
			brain = new CharacterBrain(inputResolver, stateMachine);
			stateController = new CharacterStateController(state);
			movementController = new CharacterMovementController(transform, movement);

			var animatorSync = GetComponentInChildren<AnimatorMoveSynchronizer>();
			if (animatorSync != null)
			{
				animatorSync.SyncTarget = this;
			}
		}

		void OnEnable()
		{
			inputResolver.OnEnable();
		}

		void OnDisable()
		{
			inputResolver.OnDisable();
		}

		void Update()
		{
			// このフレーム処理用時間を更新する
			UpdateTime();

			// キャラのやりたいことを更新する
			brain.Update();

			// キャラ実際の行動を更新する
			stateMachine.Update(deltaTime);

			// キャラのステータスを更新する
			stateController.Update();
		}

		public void SyncAnimatorMove(Vector3 deltaPosition, Quaternion deltaRotation)
		{
			// キャラの移動や回転などを更新する
			movementController.OnAnimatorMove(deltaTime, deltaPosition, deltaRotation);
		}

		void UpdateTime()
		{
			deltaTime = Time.deltaTime;
		}
	}
}
