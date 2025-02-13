using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ActionDemo
{
	public abstract class StateBehaviourBase
	{
		public virtual void OnStateBehaviourEnter()
		{
		}

		public virtual void OnStateBehaviourUpdate()
		{
		}

		public virtual void OnStateBehaviourExit()
		{
		}
	}
}
