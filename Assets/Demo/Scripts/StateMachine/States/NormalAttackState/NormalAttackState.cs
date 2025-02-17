namespace ActionDemo
{
	public class NormalAttackState : StateBase<NormalAttackStateBehaviour>
	{
		public NormalAttackState(ILayer layer, NormalAttackStateBehaviour behaviour, IState.Settings settings)
			: base(layer, behaviour, settings)
		{
		}
	}
}
