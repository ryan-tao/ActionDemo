namespace ActionDemo
{
	public class DodgeStateBehaviour : StateBehaviourBase
	{
		public DodgeStateBehaviour()
		{
			OnStateEnterBehaviour = StartDodge;
		}

		void StartDodge(IState.RuntimeInfo runtimeInfo)
		{
			var animationManager = State.Layer.StateMachine.AnimationManager;
			var movement = State.Layer.StateMachine.Movement;
			var inputResolver = State.Layer.StateMachine.InputResolver;

			var dodgeDirection = inputResolver.LastDirectionInput;
			if (dodgeDirection.sqrMagnitude > 0.0001f)
			{
				movement.Direction = dodgeDirection.normalized;
			}

			animationManager.Dodge();
		}
	}
}
