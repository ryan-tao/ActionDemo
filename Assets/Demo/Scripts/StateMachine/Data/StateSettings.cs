using System.Collections.Generic;
using UnityEngine;

namespace ActionDemo
{
	[CreateAssetMenu(fileName = "StateSettings", menuName = "ScriptableObjects/StateSettings")]
	public class StateSettings : ScriptableObject
	{
		public IState.Settings[] Settings;

		public IState.Settings FindSettingsByName(string name)
		{
			foreach (var setting in Settings)
			{
				if (setting.StateName == name)
				{
					return setting;
				}
			}

			return default;
		}

		public IState.Settings[] FindSettingsStartWith(string startWith)
		{
			List<IState.Settings> list = new();
			foreach (var setting in Settings)
			{
				if (setting.StateName.StartsWith(startWith))
				{
					list.Add(setting);
				}
			}

			return list.ToArray();
		}
	}
}
