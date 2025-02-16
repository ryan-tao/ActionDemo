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
					// 先行入力を優先で確認する
					result = bufferingSkillInput;
					bufferingSkillInput = SkillType.None;
				}
				else if (IsSkillActionAvailable(lastSkillInput))
				{
					// None以外返したら必ず先行入力をクリアする
					result = lastSkillInput;
					bufferingSkillInput = SkillType.None;
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
			return true;
		}

		bool IsSkillActionAvailable(SkillType skillAttackType)
		{
			// Noneは対象外
			if (skillAttackType == SkillType.None)
			{
				return false;
			}

			// 個別判定
			switch (skillAttackType)
			{
				case SkillType.DodgeSkill:
					return true;

				case SkillType.NormalAttack:
					return true;

				case SkillType.SkillAttack:
					return true;

				case SkillType.SpecialAttack:
					return true;

				default:
					return false;
			}
		}
	}
}
