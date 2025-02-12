using UnityEngine;

namespace ActionDemo
{
	public class CameraManager : MonoBehaviour
	{
		readonly Vector2 cameraSensorSize = new(36f, 24f);

		[SerializeField] Camera mainCamera;
		[SerializeField] CameraTarget followTarget;
		[SerializeField] CameraTarget aimTarget;

		public Camera MainCamera => mainCamera;

		public void Initialize()
		{
			mainCamera.usePhysicalProperties = true;
			mainCamera.gateFit = Camera.GateFitMode.Vertical;
			mainCamera.sensorSize = cameraSensorSize;
		}
	}
}
