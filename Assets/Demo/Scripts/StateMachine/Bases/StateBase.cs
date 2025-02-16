namespace ActionDemo
{
	public interface IState
	{
        public readonly struct Settings
        {
            public readonly float Duration;
            public readonly bool IsLoop;
        }

        public struct RuntimeInfo
        {
            public float ElapsedTime;
        }

        Settings StateSettings { get; }
		RuntimeInfo StateRuntimeInfo { get; }
        void OnStateEnter();
		void OnStateUpdate(float deltaTime);
		void OnStateExit();
    }

	public abstract class StateBase<T> : IState where T : StateBehaviourBase
	{
        IState.RuntimeInfo runtimeInfo;

		public LayerBase Layer { get; private set; }

		public T StateBehaviour { get; private set; }

		public IState.Settings StateSettings { get; }

        public IState.RuntimeInfo StateRuntimeInfo => runtimeInfo;

        public StateBase(LayerBase layer, T behaviour, IState.Settings settings)
		{
			Layer = layer;
			StateBehaviour = behaviour;
            StateSettings = settings;
            runtimeInfo = new IState.RuntimeInfo
            {
                ElapsedTime = -1f
            };
        }

		public virtual void OnStateEnter()
		{
            runtimeInfo.ElapsedTime = 0f;
            StateBehaviour.OnStateBehaviourEnter();
		}

		public virtual void OnStateUpdate(float deltaTime)
		{
            runtimeInfo.ElapsedTime += deltaTime;
            StateBehaviour.OnStateBehaviourUpdate();
		}

		public virtual void OnStateExit()
		{
            runtimeInfo.ElapsedTime = -1f;
            StateBehaviour.OnStateBehaviourExit();
		}
	}
}
