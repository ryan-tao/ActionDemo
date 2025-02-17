namespace ActionDemo
{
	public class DodgeState : StateBase<DodgeStateBehaviour>
	{
		public DodgeState(ILayer layer, DodgeStateBehaviour behaviour, IState.Settings settings)
			: base(layer, behaviour, settings)
		{
		}
	}
}
