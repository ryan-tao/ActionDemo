using ActionDemo.Animation;

namespace ActionDemo
{
	public class CharacterStateMachine : StateMachineBase
	{
		readonly LocomotionLayer locomotionLayer;
		readonly SkillLayer skillLayer;

		public CharacterStateMachine(InputResolver inputResolver, CharacterMovement movement, LocomotionSettings locomotionSettings, StateSettings stateSettings, AnimationManager animationManager)
			:base(inputResolver, stateSettings, locomotionSettings, movement, animationManager)
		{
			locomotionLayer = new LocomotionLayer(this);
			skillLayer = new SkillLayer(this);
			ActivateLocomotion();
		}

        public override void Update(float deltaTime)
        {
			locomotionLayer.Update(deltaTime);
			skillLayer.Update(deltaTime);
		}

		public void ActivateLocomotion()
		{
			skillLayer.SetActive(false);
			locomotionLayer.SetActive(true);
			locomotionLayer.Move();
		}

		public void Move()
		{
			var moveInput = InputResolver.LastMoveInput;
			if (moveInput.sqrMagnitude > 0f)
			{
				skillLayer.SetActive(false);
				locomotionLayer.SetActive(true);
				locomotionLayer.Move();
			}
		}

		public void Dodge()
		{
			skillLayer.SetActive(false);
			locomotionLayer.SetActive(true);
			locomotionLayer.Dodge();
		}

		public void Skill(SkillType type)
		{
			locomotionLayer.SetActive(false);
			skillLayer.SetActive(true);
			skillLayer.Skill(type);
		}
	}
}
