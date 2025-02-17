using UnityEngine;

namespace ActionDemo.Animation
{
	public class SkillLayer : AnimationLayerBase
	{
		const string NormalAttackStateNameFormat = "NormalAttack{0}";

		public SkillLayer(Animator animator, int layerIndex, AnimationTransitionTable table) : base(animator, layerIndex, table)
		{
		}

		public void NormalAttack(int index)
		{
			var normalAttackStateHash = Animator.StringToHash(string.Format(NormalAttackStateNameFormat, index + 1));
			Transition(normalAttackStateHash);
		}
	}
}
