using System;
using System.Collections.Generic;
using UnityEngine;

namespace ActionDemo
{
    public class StateMachineManager : MonoSingleton<StateMachineManager>
    {
        readonly Dictionary<Guid, IStateMachine> stateMachines = new();

        public void Initialize()
        {
        }

        public void Register(IStateMachine stateMachine)
        {
            if (stateMachine == null || stateMachines.ContainsKey(stateMachine.Id))
            {
                UnityEngine.Debug.LogError("invalid state machine when register");
                return;
            }

            stateMachines.Add(stateMachine.Id, stateMachine);
        }

        public void UnRegister(IStateMachine stateMachine)
        {
            if (stateMachine == null || !stateMachines.ContainsKey(stateMachine.Id))
            {
                UnityEngine.Debug.LogError("invalid state machine when unregister");
                return;
            }

            stateMachines.Remove(stateMachine.Id);
        }

        public IStateMachine GetStateMachine(Guid id)
        {
            if (stateMachines.TryGetValue(id, out IStateMachine stateMachine))
            {
                return stateMachine;
            }

			UnityEngine.Debug.LogError("registerd state machine not found by id: " + id.ToString());
            return null;
		}

        void Update()
        {
            foreach (var stateMachine in stateMachines.Values)
            {
                stateMachine.Update(Time.deltaTime);
            }
        }
    }
}
