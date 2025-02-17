namespace ActionDemo
{
	public interface ILayer
	{
		IStateMachine StateMachine { get; }
		bool IsActive { get; }
		IState CurrentState { get; }
		IState DefaultState { get; }
		IState NoneState { get; }
		void SetActive(bool active);
		void Transition(IState toState);
		void Update(float deltaTime);
	}

    public abstract class LayerBase : ILayer
	{
		public IStateMachine StateMachine { get; }

		public bool IsActive { get; private set; }

        public IState CurrentState { get; protected set; }

		public IState DefaultState { get; protected set; }

		public IState NoneState { get; protected set; }

		public LayerBase(IStateMachine stateMachine)
		{
			StateMachine = stateMachine;
			IsActive = false;
            CurrentState = null;
			DefaultState = null;
			NoneState = null;
        }

		public void SetActive(bool active)
		{
			if (!active)
			{
				Transition(NoneState);
			}

			IsActive = active;
		}

		public void Transition(IState toState)
		{
			if (!IsActive || toState == null)
			{
				return;
			}

			if (CurrentState == null)
			{
				CurrentState = toState;
				CurrentState?.OnStateEnter();
				return;
			}

			if (toState.Id.Equals(CurrentState.Id))
			{
				return;
			}

            CurrentState?.OnStateExit();
			CurrentState = toState;
            CurrentState?.OnStateEnter();
		}

		public virtual void Update(float deltaTime)
		{
			if (!IsActive || CurrentState == null)
			{
				return;
			}

			CurrentState.OnStateUpdate(deltaTime);

			if (IsCurrentStateFinish())
			{
				Transition(DefaultState);
			}
		}

		bool IsCurrentStateFinish()
		{
			var settings = CurrentState.StateSettings;
			var runtimeInfo = CurrentState.StateRuntimeInfo;
			return !settings.IsLoop && settings.Duration <= runtimeInfo.ElapsedTime;
        }
	}
}
