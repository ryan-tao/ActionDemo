using UnityEngine;

namespace ActionDemo
{
	public struct CharacterMovement
	{
		/// <summary>
		/// 速度
		/// </summary>
		public Vector3 Velocity;

		/// <summary>
		/// 加速度
		/// </summary>
		public float Acceleration;

		/// <summary>
		/// 加速度（減速用）
		/// </summary>
		public float Deceleration;

		/// <summary>
		/// 移動位置（ワールド座標）
		/// </summary>
		public Vector3 Position;

		/// <summary>
		/// 向き（ワールド座標）
		/// </summary>
		public Vector3 Direction;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="position">移動位置</param>
		/// <param name="direction">向き</param>
		public CharacterMovement(Vector3 position, Vector3 direction)
		{
			Velocity = Vector3.zero;
			Acceleration = 0f;
			Deceleration = 0f;
			Position = position;
			Direction = direction;
		}
	}
}
