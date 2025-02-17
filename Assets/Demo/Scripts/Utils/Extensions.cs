using ActionDemo.StateNotify;
using System;
using UnityEngine;

namespace ActionDemo
{
	public static class GameObjectExtensions
	{
		public static void SetLayerRecursively(this GameObject self, int layer)
		{
			self.layer = layer;

			foreach (Transform n in self.transform)
			{
				SetLayerRecursively(n.gameObject, layer);
			}
		}

		public static NotifyAttribute GetNotifyAttribute(this INotify notify)
		{
			return GetAttribute(notify.GetType(), typeof(NotifyAttribute)) as NotifyAttribute;

			static Attribute GetAttribute(Type type, Type attributeType)
			{
				foreach (var a in type.GetCustomAttributes(false))
				{
					if (a.GetType() == attributeType)
					{
						return a as Attribute;
					}
				}

				return null;
			}
		}
	}
}

