using System;
using UnityEngine;

namespace ActionDemo
{
	[Serializable]
	public struct AnimatorFloatParameter
	{
		[SerializeField]
		private string name;

		public readonly string Name => name;

		public readonly int NameHash => Animator.StringToHash(Name);

		public AnimatorFloatParameter(string name)
		{
			this.name = name;
		}

		public readonly void Set(Animator context, float value)
		{
			context.SetFloat(NameHash, value);
		}

		public readonly float Get(Animator context)
		{
			return context.GetFloat(NameHash);
		}

		public readonly bool IsValid(Animator context)
		{
			foreach (var p in context.parameters)
			{
				if (p.nameHash == NameHash && p.type == AnimatorControllerParameterType.Float)
				{
					return true;
				}
			}

			return false;
		}
	}
}

