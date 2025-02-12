using UnityEngine;

namespace ActionDemo
{
	public class InputResolver
	{
		const float MoveInputThreshold = 0.01f;

		InputReceiver inputReceiver;
		Vector3 lastMoveInput;
		Vector3 lastRotateInput;
		SkillType lastSkillInput;
		SkillType bufferingSkillInput;

		// ユーザ入力：移動（移動不可の場合、Vector3.zeroが返される）
		public Vector3 LastMoveInput => IsMoveActionAvailable() ? lastMoveInput : Vector3.zero;

		// ユーザ入力：回転（移動しないで回転する場合がある）（移動不可の場合、Vector3.zeroが返される）
		public Vector3 LastRotateInput => IsMoveActionAvailable() ? lastRotateInput : Vector3.zero;

		// ユーザ入力：移動方向（移動不可の場合でも、方向が返される）
		public Vector3 LastDirectionInput => lastMoveInput;

		public InputResolver(InputReceiver inputReceiver)
		{
			this.inputReceiver = inputReceiver;
		}

		public void OnEnable()
		{
			if (inputReceiver != null)
			{
				inputReceiver.SetResolver(this);
			}
		}

		public void OnDisable()
		{
			if (inputReceiver != null)
			{
				inputReceiver.SetResolver(null);
			}
		}

		public void OnPlayerInputMove(Vector3 input)
		{
			input = input.normalized;
			if (input.sqrMagnitude < MoveInputThreshold * MoveInputThreshold)
			{
				input = Vector2.zero;
			}

			lastMoveInput = input;
		}

		public void OnPlayerInputRotation(Vector3 rotation)
		{
			lastRotateInput = rotation;
		}

		public void OnPlayerInputAttack(bool attack)
		{
			lastSkillInput = attack ? SkillType.NormalAttack : SkillType.None;

			if (attack)
			{
				BufferSkillInput(SkillType.NormalAttack);
			}
		}

		public void OnPlayerInputDodge()
		{
			lastSkillInput = SkillType.DodgeSkill;
			BufferSkillInput(lastSkillInput);
		}

		public void OnPlayerInputSkillAttack()
		{
			lastSkillInput = SkillType.SkillAttack;
			BufferSkillInput(lastSkillInput);
		}

		public void OnPlayerInputSpecial()
		{
			lastSkillInput = SkillType.SpecialAttack;
			BufferSkillInput(lastSkillInput);
		}

		bool IsMoveActionAvailable()
		{
			return true;
		}

		void BufferSkillInput(SkillType skillType)
		{
			if (bufferingSkillInput != SkillType.None)
			{
				return;
			}

			bufferingSkillInput = skillType;
		}
	}
}
