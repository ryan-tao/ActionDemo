using UnityEngine;

namespace ActionDemo.Animation
{
	public class AnimationManager : MonoBehaviour
	{
		[SerializeField] Animator animator;
		[SerializeField] AnimationTransitionTable transitionTable;

		LocomotionLayer locomotionLayer;
		SkillLayer skillLayer;

		public void Initialize()
		{
			transitionTable.Prepare();
			locomotionLayer = new LocomotionLayer(animator, 0, transitionTable);
			skillLayer = new SkillLayer(animator, 1, transitionTable);
		}

		public void Move()
		{
			skillLayer.SetActive(false);
			locomotionLayer.SetActive(true);
			locomotionLayer.Move();
		}

		public void SetMoveSpeed(float moveSpeed)
		{
			locomotionLayer.SetMoveSpeed(moveSpeed);
		}

		public void Dodge()
		{
			skillLayer.SetActive(false);
			locomotionLayer.SetActive(true);
			locomotionLayer.Dodge();
		}

		public void NormalAttack(int index)
		{
			locomotionLayer.SetActive(false);
			skillLayer.SetActive(true);
			skillLayer.NormalAttack(index);
		}
	}
}
