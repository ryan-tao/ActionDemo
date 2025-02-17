using ActionDemo.Animation;
using System;

namespace ActionDemo
{
    public interface IStateMachine
    {
        Guid Id { get; }
		InputResolver InputResolver { get; }
		StateSettings StateSettings { get; }
		AnimationManager AnimationManager { get; }
		CharacterMovement Movement { get; }
		LocomotionSettings LocomotionSettings { get; }

		void Update(float deltaTime);
    }

    public abstract class StateMachineBase : IStateMachine
    {
        public Guid Id { get; }
		public InputResolver InputResolver { get; }
		public StateSettings StateSettings { get; }
		public LocomotionSettings LocomotionSettings { get; }
		public CharacterMovement Movement { get; }
		public AnimationManager AnimationManager { get; }

		public StateMachineBase(InputResolver inputResolver, StateSettings stateSettings, LocomotionSettings locomotionSettings, CharacterMovement movement, AnimationManager animationManager)
        {
            Id = Guid.NewGuid();
			InputResolver = inputResolver;
			StateSettings = stateSettings;
			LocomotionSettings = locomotionSettings;
			Movement = movement;
			AnimationManager = animationManager;
        }

        public abstract void Update(float deltaTime);
    }
}
