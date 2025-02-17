namespace ActionDemo
{
	public class NormalAttackStateBehaviour : StateBehaviourBase
	{
		readonly int index;

		public NormalAttackStateBehaviour(int index)
		{
			this.index = index;
			OnStateEnterBehaviour = EnterNormalAttack;
			OnStateExitBehaviour = ExitNormalAttack;
		}

		void EnterNormalAttack(IState.RuntimeInfo runtimeInfo)
		{
			var animationManager = State.Layer.StateMachine.AnimationManager;
			var movement = State.Layer.StateMachine.Movement;
			var inputResolver = State.Layer.StateMachine.InputResolver;

			var skillDirection = inputResolver.LastDirectionInput;
			if (skillDirection.sqrMagnitude > 0.00001f)
			{
				movement.Direction = skillDirection.normalized;
			}

			animationManager.NormalAttack(index);
		}

		void ExitNormalAttack(IState.RuntimeInfo runtimeInfo)
		{
			if (State.Layer is SkillLayer layer)
			{
				layer.ResetNormalAttackCombo();
			}
		}
	}
}
