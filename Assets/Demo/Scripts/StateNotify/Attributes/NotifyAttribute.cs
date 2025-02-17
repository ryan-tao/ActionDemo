using System;

namespace ActionDemo.StateNotify
{
	public class NotifyAttribute : Attribute
	{
		public NotifyAttribute(string functionName)
		{
			OnBeginFunctionName = functionName;
		}

		public readonly string OnBeginFunctionName;
	}
}
