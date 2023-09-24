using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySM
{
    public EnemyState currentState { get; set; }

    public void Initialize(EnemyState startingState)
    {
        currentState = startingState;
        currentState.EnterState();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
