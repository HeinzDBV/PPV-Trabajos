using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyController enemy;
    protected BossController boss;
    protected EnemySM stateMachine;

    public EnemyState(EnemyController enemy, EnemySM stateMachine)
    {
        this.stateMachine = stateMachine;
        this.enemy = enemy;
    }

    public EnemyState(BossController boss, EnemySM stateMachine)
    {
        this.stateMachine = stateMachine;
        this.boss = boss;
    }

    public virtual void EnterState() {  }
    public virtual void FrameUpdate() {  }
    public virtual void ExitState() {  }
    public virtual void OnTriggerEnter(Collider2D other) {  }
    public virtual void OnTriggerExit(Collider2D other) {  }
    public virtual void PhysicsUpdate() {  }

}
