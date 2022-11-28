using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rougelite.StateMachine
{
    public abstract class StateMachine<T>
        where T : Enum
    {
        public event Action<T> StateEntered;
        public event Action<T> StateExited;

        public T CurrentState { get; protected set; }

        public virtual void ChangeState(T newState)
        {
            StateExited?.Invoke(CurrentState);

            CurrentState = newState;

            StateEntered?.Invoke(newState);
        }
    }
}

