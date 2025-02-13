using System;

namespace ActionDemo
{
	[Serializable]
	public class LocomotionSettings
	{
		public float OnGroundThreshold = 0.5f;

		public float MaxMoveVelocity = 5f;

		public float AccelMoveTime = 0.1f;

		public float DecelMoveTime = 0.1f;
	}
}
