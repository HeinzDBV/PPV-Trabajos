using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1SM
{
    public Enemy1State CurrentState { get; private set; }

    public void Initialize(Enemy1State startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(Enemy1State newState) 
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
