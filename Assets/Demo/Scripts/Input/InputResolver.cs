using ActionDemo.StateNotify;
using UnityEngine;

namespace ActionDemo
{
	public class InputResolver
	{
		const float MoveInputThreshold = 0.0001f;

		InputReceiver inputReceiver;
		InputConstraintNotify notify;
		Vector3 lastMoveInput;
		Vector3 lastRotateInput;
		SkillType lastSkillInput;
		SkillType bufferingSkillInput;

		// ユーザ入力：移動（移動不可の場合、Vector3.zeroが返される）
		public Vector3 LastMoveInput => IsMoveActionAvailable() ? lastMoveInput : Vector3.zero;

		// ユーザ入力：移動方向（移動不可の場合でも、方向が返される）
		public Vector3 LastDirectionInput => lastMoveInput;

		// ユーザ入力：向き
		public Vector3 LastRotateInput => IsMoveActionAvailable() ? lastRotateInput : Vector3.zero;

		public SkillType LastSkillInput
		{
			get
			{
				var result = SkillType.None;

				if (IsSkillActionAvailable(bufferingSkillInput))
				{
					result = bufferingSkillInput;
					bufferingSkillInput = SkillType.None;
					lastSkillInput = SkillType.None;
				}
				else if (IsSkillActionAvailable(lastSkillInput))
				{
					result = lastSkillInput;
					bufferingSkillInput = SkillType.None;
					lastSkillInput = SkillType.None;
				}

				return result;
			}
		}

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

		public void UpdateNotify(InputConstraintNotify notify)
		{
			this.notify = notify;
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
			lastSkillInput = SkillType.Dodge;
			BufferSkillInput(lastSkillInput);
		}

		void BufferSkillInput(SkillType skillType)
		{
			if (bufferingSkillInput != SkillType.None)
			{
				return;
			}

			bufferingSkillInput = skillType;
		}

		bool IsMoveActionAvailable()
		{
			if (notify == null)
			{
				return true;
			}

			if (notify.AvailableActions == CharacterActionCommand.None)
			{
				return false;
			}

			if (notify.AvailableActions == CharacterActionCommand.All)
			{
				return true;
			}

			return notify.AvailableActions.HasFlag(CharacterActionCommand.Move);
		}

		bool IsSkillActionAvailable(SkillType skillAttackType)
		{
			if (skillAttackType == SkillType.None)
			{
				return false;
			}

			if (notify == null)
			{
				return true;
			}

			if (notify.AvailableActions == CharacterActionCommand.None)
			{
				return false;
			}

			if (notify.AvailableActions == CharacterActionCommand.All)
			{
				return true;
			}

			// 個別判定
			switch (skillAttackType)
			{
				case SkillType.Dodge:
					return notify.AvailableActions.HasFlag(CharacterActionCommand.Dodge);

				case SkillType.NormalAttack:
					return notify.AvailableActions.HasFlag(CharacterActionCommand.NormalAttack);

				default:
					return false;
			}
		}
	}
}
