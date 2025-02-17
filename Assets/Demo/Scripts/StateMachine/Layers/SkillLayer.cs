namespace ActionDemo
{
	public class SkillLayer : LayerBase
	{
		readonly NoneState noneState;
		readonly NormalAttackState[] normalAttackStates;
		int normalAttackComboIndex;
		int normalAttackComboCount;

		public SkillLayer(IStateMachine stateMachine) : base(stateMachine)
		{
			var stateSettings = stateMachine.StateSettings;

			var noneStateBehaviour = new NoneStateBehaviour();
			noneState = new NoneState(this, noneStateBehaviour, stateSettings.FindSettingsByName("None"));
			var normalAttackSettings = stateSettings.FindSettingsStartWith("NormalAttack");
			normalAttackComboIndex = -1;
			normalAttackComboCount = normalAttackSettings.Length;
			normalAttackStates = new NormalAttackState[normalAttackComboCount];
			for (var i = 0; i < normalAttackSettings.Length; i++)
			{
				var normalStateBehaviour = new NormalAttackStateBehaviour(i);
				normalAttackStates[i] = new NormalAttackState(this, normalStateBehaviour, normalAttackSettings[i]);
			}

			NoneState = noneState;
			DefaultState = noneState;
			CurrentState = noneState;
		}

		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);

			if (IsActive && CurrentState == noneState)
			{
				normalAttackComboIndex = -1;

				if (StateMachine is CharacterStateMachine stateMachine)
				{
					stateMachine.ActivateLocomotion();
				}
			}
		}

		public void Skill(SkillType type)
		{
			switch (type)
			{
				case SkillType.NormalAttack:
					NormalAttackSkill();
					break;

				default:
					break;
			}
		}

		void NormalAttackSkill()
		{
			if (normalAttackComboCount == 0)
			{
				return;
			}

			normalAttackComboIndex = (normalAttackComboIndex + 1) % normalAttackComboCount;
			Transition(normalAttackStates[normalAttackComboIndex]);
		}

		public void ResetNormalAttackCombo()
		{
		}
	}
}