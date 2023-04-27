using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateMachine<TState> where TState : Enum
{
    private Dictionary<TState, Action> states = new Dictionary<TState, Action>(); // dictionary to hold states and their corresponding actions

    [SerializeField]
    private TState currentState;

    public TState GetState()
    {
        return currentState;
    }

    public void AddState(TState state, Action action)
    {
        states[state] = action;
    }

    public void SetState(TState state)
    {
        if (!states.ContainsKey(currentState))
        {
            Debug.LogError("Invalid state: " + state);
            return;
        }
        currentState = state;
    }

    public void UpdateState()
    {
        if (states.ContainsKey(currentState))
        {
            states[currentState]?.Invoke();
        }
    }

}
