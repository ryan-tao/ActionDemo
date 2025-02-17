using System;

namespace ActionDemo.StateNotify
{
	[Serializable, Notify("OnInputConstraintBegin")]
	public class InputConstraintNotify : INotify
	{
		/// <summary>
		/// Input制限情報
		/// </summary>
		public CharacterActionCommand AvailableActions;

		/// <summary>
		/// 先行入力可能なアクション
		/// </summary>
		public InputBufferingActionCommand BufferableActions;

		/// <summary>
		/// 先行入力可能な開始時間（0~Constraint最大時間）
		/// </summary>
		public float InputBufferingStartTime;
	}
}
