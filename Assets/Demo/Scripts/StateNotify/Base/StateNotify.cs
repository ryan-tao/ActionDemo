using System;

namespace ActionDemo.StateNotify
{
	public interface INotify
	{
	}

	[Serializable]
	public struct StateNotify
	{
		public float Time;

		public float Duration;

		public string FunctionName;

		// NOTE: 編集ツールができるまで一旦InputConstraintNotifyだけにする
		//[SerializeReference]
		//public INotify Notify;
		public InputConstraintNotify Notify;

		public StateNotify(float time, float duration, InputConstraintNotify notify)
		{
			Time = time;
			Duration = duration;
			var attribute = notify.GetNotifyAttribute();
			FunctionName = attribute.OnBeginFunctionName;
			Notify = notify;
		}
	}
}
