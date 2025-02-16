using System;
using System.Collections.Generic;

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

        void Update()
        {
            foreach (var stateMachine in stateMachines.Values)
            {
                stateMachine.Update();
            }
        }
    }
}
