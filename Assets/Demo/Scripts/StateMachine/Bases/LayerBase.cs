namespace ActionDemo
{
    public abstract class LayerBase
	{
		public bool IsActive { get; set; }

        public IState CurrentState { get; protected set; }

		public IState DefaultState { get; protected set; }

		public LayerBase()
		{
			IsActive = false;
            CurrentState = null;
        }
        
		public void Transition(IState toState)
		{
			if (!IsActive || toState == null)
			{
				return;
			}

			if (toState.Equals(CurrentState))
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
