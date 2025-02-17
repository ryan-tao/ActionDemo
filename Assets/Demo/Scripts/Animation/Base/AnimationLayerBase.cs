using UnityEngine;

namespace ActionDemo.Animation
{
	public class AnimationLayerBase
	{
		public static readonly int NoneStateHash = Animator.StringToHash("None");

		public Animator Animator { get; }

		public int LayerIndex { get; }

		public float Weight
		{
			get
			{
				return Animator.GetLayerWeight(LayerIndex);
			}
			set
			{
				var weight = Mathf.Clamp01(value);
				Animator.SetLayerWeight(LayerIndex, weight);
			}
		}

		public AnimationTransitionTable TransitionTable { get; }

		public AnimationLayerBase(Animator animator, int layerIndex, AnimationTransitionTable transitionTable)
		{
			Animator = animator;
			LayerIndex = layerIndex;
			TransitionTable = transitionTable;
			Weight = 0f;
		}

		public void SetActive(bool active)
		{
			if (active)
			{
				Weight = 1f;
			}
			else
			{
				Weight = 0f;
				Transition(NoneStateHash);
			}
		}

		public AnimatorStateInfo GetAnimatorStateInfo()
		{
			if (Animator.IsInTransition(LayerIndex))
			{
				return Animator.GetNextAnimatorStateInfo(LayerIndex);
			}
			else
			{
				return Animator.GetCurrentAnimatorStateInfo(LayerIndex);
			}
		}

		public void Transition(int toStateHash, bool canSelfTransition = false)
		{
			AnimatorStateInfo stateInfo = GetAnimatorStateInfo();
			if (canSelfTransition || stateInfo.shortNameHash != toStateHash)
			{
				var row = TransitionTable.FindTransitionRow(stateInfo.shortNameHash, toStateHash);
				Animator.CrossFade(toStateHash, row.TransitionTime, LayerIndex, row.TransitionOffset);
			}
		}
	}
}
