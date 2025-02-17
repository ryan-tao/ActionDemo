using System;

namespace ActionDemo
{
	public abstract class StateBehaviourBase
	{
		public IState State { get; set; }
		public Action<IState.RuntimeInfo> OnStateEnterBehaviour { get; set; }
		public Action<IState.RuntimeInfo, float> OnStateUpdateBehaviour { get; set; }
		public Action<IState.RuntimeInfo> OnStateExitBehaviour { get; set; }

		public void OnStateEnter(IState.RuntimeInfo runtimeInfo)
		{
			OnStateEnterBehaviour?.Invoke(runtimeInfo);
		}

		public void OnStateUpdate(IState.RuntimeInfo runtimeInfo, float deltaTime)
		{
			OnStateUpdateBehaviour?.Invoke(runtimeInfo, deltaTime);
		}

		public void OnStateExit(IState.RuntimeInfo runtimeInfo)
		{
			OnStateExitBehaviour?.Invoke(runtimeInfo);
		}
	}
}
