namespace ActionDemo
{
	public class IdleState : StateBase<IdleStateBehaviour>
	{
		public IdleState(LayerBase layer, IdleStateBehaviour behaviour, IState.Settings settings)
			: base(layer, behaviour, settings)
		{
		}
	}
}
