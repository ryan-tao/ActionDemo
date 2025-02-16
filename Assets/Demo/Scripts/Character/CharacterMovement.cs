using UnityEngine;

namespace ActionDemo
{
	public class CharacterMovement
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
		/// 移動方向（ワールド座標）
		/// </summary>
		public Vector3 Direction;

		/// <summary>
		/// 向き（ワールド座標）
		/// </summary>
		public Vector3 Forward;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public CharacterMovement()
		{
			Velocity = Vector3.zero;
			Acceleration = 0f;
			Deceleration = 0f;
			Position = Vector3.zero;
			Direction = Vector3.forward;
			Forward = Direction;
		}
	}
}
