using UnityEngine;
using UnityEngine.InputSystem;

namespace ActionDemo
{
	public class InputReceiver : MonoBehaviour
	{
		const string MoveAction = "Move";
		const string AttackAction = "Attack";
		const string DodgeAction = "Dodge";

		[SerializeField] CameraManager cameraManager;
		[SerializeField] PlayerInput playerInput;
		InputResolver resolver;

		public void SetResolver(InputResolver inputResolver)
		{
			this.resolver = inputResolver;
		}

		private void OnEnable()
		{
			playerInput.actions[AttackAction].started += Attack;
			playerInput.actions[AttackAction].canceled += AttackCanceled;
			playerInput.actions[DodgeAction].started += Dodge;
		}

		private void OnDisable()
		{
			playerInput.actions[AttackAction].started -= Attack;
			playerInput.actions[AttackAction].canceled -= AttackCanceled;
			playerInput.actions[DodgeAction].started -= Dodge;
		}

		private void Update()
		{
			UpdateMove();
		}

		void UpdateMove()
		{
			var value = playerInput.actions[MoveAction].ReadValue<Vector2>();
			var input = new Vector3(value.x, 0, value.y);

			var cameraRotation = cameraManager.MainCamera.transform.rotation;
			var worldInput = Quaternion.AngleAxis(cameraRotation.eulerAngles.y, Vector3.up) * input;

			resolver?.OnPlayerInputMove(worldInput);
			resolver?.OnPlayerInputRotation(worldInput);
		}

		void Attack(InputAction.CallbackContext obj)
		{
			resolver?.OnPlayerInputAttack(true);
		}

		void AttackCanceled(InputAction.CallbackContext obj)
		{
			resolver?.OnPlayerInputAttack(false);
		}

		void Dodge(InputAction.CallbackContext obj)
		{
			resolver?.OnPlayerInputDodge();
		}
	}
}
