using UnityEngine;

namespace ActionDemo.Animation
{
	public class LocomotionLayer : AnimationLayerBase
	{
		//public enum LocomotionState
		//{
		//	None,
		//	Move,
		//	Dodge,
		//}

		readonly int MoveStateHash = Animator.StringToHash("Move");
		readonly int DodgeStateHash = Animator.StringToHash("Dodge");

		//public LocomotionState LayerState => GetCurrentState();

		public LocomotionLayer(Animator animator, int layerIndex, AnimationTransitionTable table) : base(animator, layerIndex, table)
		{
		}

		public void Move()
		{
			Transition(MoveStateHash);
		}

		public void SetMoveSpeed(float moveSpeed)
		{
			AnimatorParameterDefine.MoveSpeed.Set(Animator, moveSpeed);
		}

		public void Dodge()
		{
			Transition(DodgeStateHash);
		}

		//LocomotionState GetCurrentState()
		//{
		//	AnimatorStateInfo stateInfo = GetAnimatorStateInfo();

		//	if (stateInfo.shortNameHash == MoveStateHash)
		//	{
		//		return LocomotionState.Move;
		//	}
		//	else if (stateInfo.shortNameHash == DodgeStateHash)
		//	{
		//		return LocomotionState.Dodge;
		//	}

		//	return LocomotionState.None;
		//}
	}
}
