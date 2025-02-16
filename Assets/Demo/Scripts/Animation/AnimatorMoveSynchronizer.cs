using UnityEngine;

namespace ActionDemo
{
	public interface ISyncAnimatorMove
	{
		void SyncAnimatorMove();
	}

	[RequireComponent(typeof(Animator))]
	public class AnimatorMoveSynchronizer : MonoBehaviour
	{
		public ISyncAnimatorMove SyncTarget { get; set; }

		void OnAnimatorMove()
		{
			SyncTarget?.SyncAnimatorMove();
		}
	}
}
