using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rougelite.StateMachine
{
    public abstract class StateListener<T> : MonoBehaviour
    where T : Enum
    {
        protected StateMachine<T> StateMachine;

        protected abstract StateMachine<T> GetStateMachine();

        private void Awake()
        {
            StateMachine = GetStateMachine();
        }

        private void OnEnable()
        {
            StateMachine.StateEntered += OnStateEntered;
            StateMachine.StateExited += OnStateExited;
        }

        private void OnDisable()
        {
            StateMachine.StateEntered -= OnStateEntered;
            StateMachine.StateExited -= OnStateExited;
        }

        protected abstract void OnStateEntered(T state);
        protected abstract void OnStateExited(T state);
    }
}
