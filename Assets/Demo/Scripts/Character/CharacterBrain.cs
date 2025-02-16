namespace ActionDemo
{
	public class CharacterBrain
	{
		InputResolver inputResolver;
		CharacterStateMachine stateMachine;

		public CharacterBrain(InputResolver inputResolver, CharacterStateMachine stateMachine)
		{
			this.inputResolver = inputResolver;
			this.stateMachine = stateMachine;
		}

		public void Update()
		{
			if (TrySkill(inputResolver))
			{
				return;
			}

			TryMove();
		}

		bool TrySkill(InputResolver inputResolver)
		{
			var skillInput = inputResolver.LastSkillInput;
			if (skillInput == SkillType.None)
			{
				return false;
			}

			if (skillInput == SkillType.DodgeSkill)
			{
				stateMachine.Dodge();
			}
			else
			{
				stateMachine.Skill(skillInput);
			}

			return true;
		}

		private void TryMove()
		{
			stateMachine.Move();
		}
	}
}
