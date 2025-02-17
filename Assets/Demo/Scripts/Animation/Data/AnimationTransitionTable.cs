using System;
using System.Collections.Generic;
using UnityEngine;

namespace ActionDemo.Animation
{
	[CreateAssetMenu(fileName = "AnimationTransitionTable", menuName = "ScriptableObjects/AnimationTransitionTable")]
	public class AnimationTransitionTable : ScriptableObject
	{
		public AnimationTransitionRow[] List;

		[NonSerialized]
		readonly Dictionary<(int, int), AnimationTransitionRow> dict = new();

		public void Prepare()
		{
			foreach (var row in List)
			{
				var fromHash = Animator.StringToHash(row.FromState);
				var toHash = Animator.StringToHash(row.ToState);
				dict[(fromHash, toHash)] = row;
			}
		}

		public AnimationTransitionRow FindTransitionRow(int fromHash, int toHash)
		{
			if (dict.TryGetValue((fromHash, toHash), out var row))
			{
				return row;
			}

			return default;
		}
	}

	[Serializable]
	public struct AnimationTransitionRow
	{
		public string FromState;

		public string ToState;

		public float TransitionTime;

		public float TransitionOffset;
	}
}
