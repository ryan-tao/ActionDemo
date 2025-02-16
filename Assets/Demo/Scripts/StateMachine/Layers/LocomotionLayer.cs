using UnityEngine;

namespace ActionDemo
{
	public class LocomotionLayer : LayerBase
	{
		enum LocomotionState
		{
			Move,
			Dead,
		}

		MoveState moveState;
		
		public LocomotionLayer(Transform targetRoot, InputResolver inputResolver, CharacterMovement movement, LocomotionSettings settings) : base()
		{
			var moveStateBehaviour = new MoveStateBehaviour(inputResolver, movement, settings);
			moveState = new MoveState(this, moveStateBehaviour, new IState.Settings(1f, true));
			DefaultState = moveState;
			CurrentState = moveState;
		}

		public void Move()
		{
			Transition(DefaultState);
		}
	}
}
