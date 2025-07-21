using System;

namespace Basket.General
{
    public abstract class StateMachine<T> where T : IState
    {
        private T _previousState;
        private T _nextState;
        private bool _transitionInProgress;

        public T CurrentState { get; private set; }

        public void StartMachine(T state)
        {
            CurrentState = state;
            state.Enter();
        }
        public void TransitionTo(T nextState)
        {
            if (nextState != null && !nextState.Equals(CurrentState))
            {
                _transitionInProgress = true;
                CurrentState.Exit();
                _previousState = CurrentState;
                _nextState = nextState;
            }
        }
        public void TransitionToPreviousState() => TransitionTo(_previousState);
        public Type GetPreviousStateType() => _previousState.GetType();
        public void Update()
        {
            CompleteTransition();

            if (!_transitionInProgress)
                CurrentState?.Update();
        }

        private void CompleteTransition()
        {
            if (_nextState != null)
            {
                CurrentState = _nextState;

                CurrentState.Enter();
                _transitionInProgress = false;
            }
        }
    }
}