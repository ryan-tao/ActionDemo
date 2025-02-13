namespace ActionDemo
{
	public interface IState
	{

	}

	public abstract class StateBase<T> : IState where T : StateBehaviourBase
	{
		public LayerBase Layer { get; private set; }
		public T StateBehaviour { get; private set; }

		public StateBase(LayerBase layer, T behaviour)
		{
			Layer = layer;
			StateBehaviour = behaviour;
		}

		public virtual void OnStateEnter()
		{
			StateBehaviour.OnStateBehaviourEnter();
		}

		public virtual void OnStateUpdate()
		{
			StateBehaviour.OnStateBehaviourUpdate();
		}

		public virtual void OnStateExit()
		{
			StateBehaviour.OnStateBehaviourExit();
		}
	}
}
