using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStateStandard : CCharacterState
{
    public override void BeginState()
    {
        Manager.IsMove = true;
    }

    public override void SetUpdate()
    {
        // 공격 상태 전환
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Manager.SetState(CharacterState.BaseAttack);
        }

        if (Manager.Direction.x != 0 || Manager.Direction.y != 0)
        {
            Animator.SetFloat("Move", 1.0f);                  // 애니메이터 Move 블렌드 움직임 트리로 변경
            Animator.SetFloat("DirY", Manager.Direction.y);         // 애니메이터 y축 파라미터 변경
        }
        // 방향키 입력이 없을 때 Idle 상태로 전환
        else if (Manager.Direction.x == 0 || Manager.Direction.y == 0)
        {
            Animator.SetFloat("Move", 0.0f);                  // 애니메이터 Move 블렌드 0으로 초기화
            Animator.SetFloat("DirY", Manager.Direction.y);         // 애니메이터 Y축 파라미터 변경
        }
    }
}
