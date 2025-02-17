using ActionDemo.Animation;

namespace ActionDemo
{
	public class LocomotionLayer : LayerBase
	{
		readonly NoneState noneState;
		readonly MoveState moveState;
		readonly DodgeState dodgeState;
		
		public LocomotionLayer(IStateMachine stateMachine) : base(stateMachine)
		{
			var noneStateBehaviour = new NoneStateBehaviour();
			var moveStateBehaviour = new MoveStateBehaviour();
			var dodgeStateBehaviour = new DodgeStateBehaviour();

			var stateSettings = stateMachine.StateSettings;
			noneState = new NoneState(this, noneStateBehaviour, stateSettings.FindSettingsByName("None"));
			moveState = new MoveState(this, moveStateBehaviour, stateSettings.FindSettingsByName("Move"));
			dodgeState = new DodgeState(this, dodgeStateBehaviour, stateSettings.FindSettingsByName("Dodge"));
			NoneState = noneState;
			DefaultState = moveState;
			CurrentState = moveState;
		}

		public void Move()
		{
			Transition(moveState);
		}

		public void Dodge()
		{
			Transition(dodgeState);
		}
	}
}
