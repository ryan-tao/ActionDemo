using UnityEngine;

namespace ActionDemo
{
	public class CharacterStateMachine : StateMachineBase
	{
		InputResolver inputResolver;
		LocomotionLayer locomotionLayer;

		public CharacterStateMachine(Transform targetRoot, InputResolver inputResolver, CharacterMovement movement, LocomotionSettings settings)
		{
			this.inputResolver = inputResolver;
			locomotionLayer = new LocomotionLayer(targetRoot, inputResolver, movement, settings);
			ActivateLocomotion();
		}

        public override void Update(float deltaTime)
        {
			locomotionLayer.Update(deltaTime);
        }

        public void Dodge()
		{
			ActivateLocomotion();
			var dodgeDirection = inputResolver.LastDirectionInput;
			//locomotionLayer.Dodge(dodgeDirection);
		}

		public void Skill(SkillType type)
		{
			//locomotionLayer.CancelMotion();
			//attackLayer.SkillAttack(type, targetDirection);
		}

		public void Move()
		{
			var moveInput = inputResolver.LastMoveInput;
			if (moveInput.sqrMagnitude > 0f)
			{
				ActivateLocomotion();
				locomotionLayer.Move();
			}
		}

		public void Dead(Vector3 damageDirection)
		{
			ActivateLocomotion();
			//locomotionLayer.Dead(damageDirection);
		}

		public void KnockBack(Vector3 damageDirection)
		{
			//locomotionLayer.CancelMotion();
			//attackLayer.CancelAttack();
			//damageLayer.KnockBack(damageDirection);
		}

		public void KnockDown(Vector3 damageDirection)
		{
			//locomotionLayer.CancelMotion();
			//attackLayer.CancelAttack();
			//damageLayer.KnockDown(damageDirection);
		}

		void ActivateLocomotion()
		{
			locomotionLayer.IsActive = true;
			locomotionLayer.Move();
		}
	}
}
