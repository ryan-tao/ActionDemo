using System;
using UnityEngine;

namespace ActionDemo
{
	[Serializable]
	public struct AnimatorTriggerParameter
	{
		[SerializeField]
		private string name;

		public readonly string Name => name;

		public readonly int NameHash => Animator.StringToHash(Name);

		public AnimatorTriggerParameter(string name)
		{
			this.name = name;
		}

		public readonly void Set(Animator context)
		{
			context.SetTrigger(NameHash);
		}

		public readonly bool IsValid(Animator context)
		{
			foreach (var p in context.parameters)
			{
				if (p.nameHash == NameHash && p.type == AnimatorControllerParameterType.Trigger)
				{
					return true;
				}
			}

			return false;
		}
	}
}

