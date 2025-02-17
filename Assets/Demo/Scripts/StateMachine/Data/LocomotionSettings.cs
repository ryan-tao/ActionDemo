using UnityEngine;

namespace ActionDemo
{
	[CreateAssetMenu(fileName = "LocomotionSettings", menuName = "ScriptableObjects/LocomotionSettings")]
	public class LocomotionSettings : ScriptableObject
	{
		public float MaxMoveVelocity = 5f;
		public float AccelMoveTime = 0.5f;
		public float DecelMoveTime = 0.5f;
	}
}
