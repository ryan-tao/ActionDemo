using ActionDemo.Animation;
using ActionDemo.StateNotify;

namespace ActionDemo
{
	public class CharacterStateMachine : StateMachineBase
	{
		readonly InputResolver inputResolver;
		readonly LocomotionLayer locomotionLayer;
		readonly SkillLayer skillLayer;

		public CharacterStateMachine(InputResolver inputResolver, CharacterMovement movement, LocomotionSettings locomotionSettings, StateSettings stateSettings, AnimationManager animationManager)
			: base(inputResolver, stateSettings, locomotionSettings, movement, animationManager)
		{
			this.inputResolver = inputResolver;
			locomotionLayer = new LocomotionLayer(this);
			skillLayer = new SkillLayer(this);
			ActivateLocomotion();
		}

		InputConstraintNotify GetCurrentInputConstraintNotify(ILayer[] layers)
		{
			foreach (var layer in layers)
			{
				if (layer.IsActive)
				{
					return layer.CurrentState.GetLastInputConstraintNotify();
				}
			}

			return null;
		}

        public override void Update(float deltaTime)
        {
			var layers = new ILayer[] { locomotionLayer, skillLayer };
			foreach (var layer in layers)
			{
				layer.Update(deltaTime);
			}

			inputResolver.UpdateNotify(GetCurrentInputConstraintNotify(layers));
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
