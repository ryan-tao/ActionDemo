using System;

namespace ActionDemo
{
    public interface IStateMachine
    {
        Guid Id { get; }

        void Update(float deltaTime);
    }

    public abstract class StateMachineBase : IStateMachine
    {
        public Guid Id { get; private set; }

        public StateMachineBase()
        {
            Id = Guid.NewGuid();
        }

        public abstract void Update(float deltaTime);
    }
}
