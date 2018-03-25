using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStateRun : CStateBase
{
    [SerializeField]
    Vector2 m_RunDirection = Vector2.zero;

    public override void BeginState()
    {
        
    }

    public override void EndState()
    {

    }

    public override void StateUpdate()
    {
        Vector2 dir = base.Manager.Direction;

        base.Manager.Controller.Movement(dir);
        base.Manager.Animator.SetFloat("Move", 1.0f);
        base.Manager.Animator.SetFloat("DirY", dir.y);
        
    }
}
