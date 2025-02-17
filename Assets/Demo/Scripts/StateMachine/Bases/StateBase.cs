using System;

namespace ActionDemo
{
	public interface IState
	{
        [Serializable]
        public struct Settings
        {
            public string StateName;
            public float Duration;
            public bool IsLoop;

            public Settings(float duration, bool isLoop)
            {
                StateName = "";
                Duration = duration;
                IsLoop = isLoop;
            }
        }

        public struct RuntimeInfo
        {
            public float ElapsedTime;
        }

        Guid Id { get; }
        ILayer Layer { get; }
        Settings StateSettings { get; }
		RuntimeInfo StateRuntimeInfo { get; }
        void OnStateEnter();
		void OnStateUpdate(float deltaTime);
		void OnStateExit();
    }

	public abstract class StateBase<T> : IState
        where T : StateBehaviourBase
	{
		IState.RuntimeInfo runtimeInfo;

        public Guid Id { get; }

		public ILayer Layer { get; private set; }

		public T StateBehaviour { get; private set; }

		public IState.Settings StateSettings { get; }

        public IState.RuntimeInfo StateRuntimeInfo => runtimeInfo;

		public StateBase(ILayer layer, T behaviour, IState.Settings settings)
		{
            Id = Guid.NewGuid();
			Layer = layer;
			StateBehaviour = behaviour;
            StateBehaviour.State = this;
            StateSettings = settings;
            runtimeInfo = new IState.RuntimeInfo
            {
                ElapsedTime = 0f
            };
        }

		public virtual void OnStateEnter()
		{
            runtimeInfo.ElapsedTime = 0f;
            StateBehaviour.OnStateEnter(runtimeInfo);
		}

		public virtual void OnStateUpdate(float deltaTime)
		{
            runtimeInfo.ElapsedTime += deltaTime;
            StateBehaviour.OnStateUpdate(runtimeInfo, deltaTime);
		}

		public virtual void OnStateExit()
		{
            runtimeInfo.ElapsedTime = 0f;
            StateBehaviour.OnStateExit(runtimeInfo);
		}
	}
}
