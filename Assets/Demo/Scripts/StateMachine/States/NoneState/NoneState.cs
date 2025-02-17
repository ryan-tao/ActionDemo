namespace ActionDemo
{
	public class NoneState : StateBase<NoneStateBehaviour>
	{
		public NoneState(ILayer layer, NoneStateBehaviour behaviour, IState.Settings settings)
			: base(layer, behaviour, settings)
		{
		}
	}
}
