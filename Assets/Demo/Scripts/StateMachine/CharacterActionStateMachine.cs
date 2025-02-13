using UnityEngine;

namespace ActionDemo
{
	public class CharacterActionStateMachine
	{
		InputResolver inputResolver;

		LocomotionLayer locomotionLayer;
		SkillLayer skillLayer;

		IState CurrentState { get; set; }

		public CharacterActionStateMachine(InputResolver inputResolver)
		{
			this.inputResolver = inputResolver;
			locomotionLayer = new LocomotionLayer();
			skillLayer = new SkillLayer();
		}

		public void Dodge()
		{
			//ActivateLocomotion();
			//var dodgeDirection = inputResolver.LastDirectionInput;
			//locomotionLayer.PrepareDirection(dodgeDirection);
			//locomotionLayer.Dodge();
		}

		public void SkillAttack(SkillType type)
		{
			//locomotionLayer.CancelMotion();
			////var targetDirection = controller.InputResolver.SearchTarget(true);
			////locomotionLayer.PrepareDirection(targetDirection);
			//attackLayer.SkillAttack(type);
		}

		public void Move()
		{
			var moveInput = inputResolver.LastMoveInput;
			if (moveInput.sqrMagnitude > 0f)
			{
				ActivateLocomotion();
				//locomotionLayer.Move();
			}
		}

		public void Dead(Vector3 damageDirection)
		{
			//ActivateLocomotion();
			//locomotionLayer.Dead();
			//statusEffectLayer.CancelStatusEffect();
		}

		public void KnockBack(Vector3 damageDirection)
		{
			//locomotionLayer.CancelMotion();
			//attackLayer.CancelAttack();
			//chainSkillLayer.CancelChainSkill();
			//damageLayer.Damage();
		}

		public void KnockDown(Vector3 damageDirection)
		{
			//locomotionLayer.CancelMotion();
			//attackLayer.CancelAttack();
			//chainSkillLayer.CancelChainSkill();
			//damageLayer.Down();
		}


		void ActivateLocomotion()
		{
		}
	}
}
