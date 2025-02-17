using System;
using UnityEngine;

namespace ActionDemo
{
	[Serializable]
	public struct AnimatorBoolParameter
	{
		[SerializeField]
		private string name;

		public readonly string Name => name;

		public readonly int NameHash => Animator.StringToHash(Name);

		public AnimatorBoolParameter(string name)
		{
			this.name = name;
		}

		public readonly void Set(Animator context, bool value)
		{
			context.SetBool(NameHash, value);
		}

		public readonly bool Get(Animator context)
		{
			return context.GetBool(NameHash);
		}

		public readonly bool IsValid(Animator context)
		{
			foreach (var p in context.parameters)
			{
				if (p.nameHash == NameHash && p.type == AnimatorControllerParameterType.Bool)
				{
					return true;
				}
			}

			return false;
		}
	}
}