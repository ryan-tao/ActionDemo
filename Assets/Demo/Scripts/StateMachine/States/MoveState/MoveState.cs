namespace ActionDemo
{
	public class MoveState : StateBase<MoveStateBehaviour>
	{
		public MoveState(LayerBase layer, MoveStateBehaviour behaviour, IState.Settings settings)
			: base(layer, behaviour, settings)
		{
		}
	}
}
