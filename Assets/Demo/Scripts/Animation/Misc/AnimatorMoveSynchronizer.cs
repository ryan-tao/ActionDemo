using UnityEngine;

namespace ActionDemo
{
	public interface ISyncAnimatorMove
	{
		void SyncAnimatorMove(Vector3 deltaPosition, Quaternion deltaRotation);
	}

	[RequireComponent(typeof(Animator))]
	public class AnimatorMoveSynchronizer : MonoBehaviour
	{
		public ISyncAnimatorMove SyncTarget { get; set; }

		Animator animator;

		void Awake()
		{
			animator = GetComponent<Animator>();
		}

		void OnAnimatorMove()
		{
			SyncTarget?.SyncAnimatorMove(animator.deltaPosition, animator.deltaRotation);
		}
	}
}
