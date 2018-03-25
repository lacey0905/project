using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStateIdle : CStateBase
{

    public override void BeginState()
    {

    }

    public override void EndState()
    {

    }

    public override void StateUpdate()
    {
        base.Manager.Animator.SetFloat("Move", 0.0f);
    }

}
