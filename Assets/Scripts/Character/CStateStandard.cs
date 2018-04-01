using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStateStandard : CCharacterState
{

    Animator Animator;

    void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {


        Animator.SetFloat("Move", 1.0f);                  // 애니메이터 Move 블렌드 움직임 트리로 변경
        //Animator.SetFloat("DirY", Manager.Direction;);         // 애니메이터 y축 파라미터 변경
    }



}
