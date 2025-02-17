using System;
using System.Collections.Generic;
using ActionDemo.StateNotify;
using static ActionDemo.IState;

namespace ActionDemo
{
	public interface IState
	{
        [Serializable]
        public struct Settings
        {
            public string StateName;
            public float Duration;
            public bool IsLoop;
            public StateNotify.StateNotify[] StateNotifies;
        }

        public struct RuntimeInfo
        {
            public float ElapsedTime;
        }

        Guid Id { get; }
        ILayer Layer { get; }
        Settings StateSettings { get; }
		RuntimeInfo StateRuntimeInfo { get; }
        void OnStateEnter();
		void OnStateUpdate(float deltaTime);
		void OnStateExit();
        InputConstraintNotify GetLastInputConstraintNotify();

	}

	public abstract class StateBase<T> : IState
        where T : StateBehaviourBase
	{
		readonly List<int> notifyIndexList = new();
		IState.RuntimeInfo runtimeInfo;

		public Guid Id { get; }

		public ILayer Layer { get; private set; }

		public T StateBehaviour { get; private set; }

		public IState.Settings StateSettings { get; }

        public IState.RuntimeInfo StateRuntimeInfo => runtimeInfo;

		public StateBase(ILayer layer, T behaviour, IState.Settings settings)
		{
            Id = Guid.NewGuid();
			Layer = layer;
			StateBehaviour = behaviour;
            StateBehaviour.State = this;
            StateSettings = settings;
            runtimeInfo = new IState.RuntimeInfo
            {
                ElapsedTime = 0f
            };
        }

		public virtual void OnStateEnter()
		{
            runtimeInfo.ElapsedTime = 0f;
            StateBehaviour.OnStateEnter(runtimeInfo);
		}

		public virtual void OnStateUpdate(float deltaTime)
		{
            TriggerInputConstraintNofity(runtimeInfo);
			StateBehaviour.OnStateUpdate(runtimeInfo, deltaTime);
			runtimeInfo.ElapsedTime += deltaTime;
		}

		public virtual void OnStateExit()
		{
            FinishInputConstraintNotify();
			StateBehaviour.OnStateExit(runtimeInfo);
            runtimeInfo.ElapsedTime = 0f;
		}

		// ----------------------------------------------
		// 以下は暫定対応
		// ----------------------------------------------
		public InputConstraintNotify GetLastInputConstraintNotify()
		{
			if (notifyIndexList.Count > 0)
			{
				return StateSettings.StateNotifies[^1].Notify;
			}

			return null;
		}

		void TriggerInputConstraintNofity(RuntimeInfo runtimeInfo)
        {
            var elapsedTime = runtimeInfo.ElapsedTime;
            for (int i = 0; i < StateSettings.StateNotifies.Length; i++)
            {
                var notify = StateSettings.StateNotifies[i];
                if (notify.Time <= elapsedTime && notify.Time + notify.Duration > elapsedTime)
                {
                    if (notifyIndexList.Contains(i))
                    {
                        continue;
                    }

                    notifyIndexList.Add(i);
                }
                else
                {
                    if (notifyIndexList.Contains(i))
                    {
                        notifyIndexList.Remove(i);
					}
                }
            }
        }

        void FinishInputConstraintNotify()
        {
            notifyIndexList.Clear();
		}
	}
}
