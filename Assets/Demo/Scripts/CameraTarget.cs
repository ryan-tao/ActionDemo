using UnityEngine;

namespace ActionDemo
{
	public class CameraTarget : MonoBehaviour
	{
		[SerializeField] Transform target;
		[SerializeField] Vector3 worldOffset = default;

		public Vector3 CurrentPosition { get; set; }

		public Vector3 TargetPosition => target != null ? target.position + worldOffset : Vector3.zero;

		public Transform Target
		{
			get { return target; }
			set { target = value; }
		}

		void Update()
		{
			UpdatePosition();
		}

		void UpdatePosition()
		{
			gameObject.transform.position = TargetPosition;
		}
	}
}
