using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum CharacterState
{
    Idle = 0,
    Move,
    Attack
}

public class CCharacterHunter : CCharacterBase
{
    public CharacterState m_CurState;

    public SpriteRenderer m_Render;
    CCharacterController m_Controller;
    Animator m_Anim;

    void Awake()
    {
        m_Controller = GetComponent<CCharacterController>();
        m_Anim = m_Render.GetComponent<Animator>();
    }

    [SerializeField]
    private Vector2 m_Direction = Vector2.zero;

    void Start()
    {
        //base.SetupStat();
        //base.DecreseHealth(10);
    }

    public void SetState(CharacterState _newState)
    {
        if (m_CurState != _newState)
        {
            m_CurState = _newState;
        }
    }

    // 상태 값에 따른 액션 실행
    void StateAction(CharacterState _state)
    {
        // 상태 구분
        switch (_state)
        {
            case CharacterState.Idle:
                m_Anim.SetFloat("Move", 0.0f);                  // 애니메이터 Move 블렌드 0으로 초기화
                m_Anim.SetFloat("DirY", m_Direction.y);         // 애니메이터 Y축 파라미터 변경
                break;
            case CharacterState.Move:

                m_Controller.Movement(m_Direction);
                m_Anim.SetFloat("Move", 1.0f);                  // 애니메이터 Move 블렌드 움직임 트리로 변경
                m_Anim.SetFloat("DirY", m_Direction.y);         // 애니메이터 Y축 파라미터 변경

                // 좌우 방향키가 입력이 될 때만 스프라이트 반전
                if (m_Direction.x != 0)
                {
                    m_Render.flipX = m_Direction.x < 0;
                }
                break;
            case CharacterState.Attack:
                StartCoroutine(BaseAttack());
                break;
        }
    }


    float m_AttackTime = 2.0f;


    IEnumerator BaseAttack()
    {
        m_Anim.SetTrigger("BaseAttack");
        yield return new WaitForSeconds(m_AttackTime);
        SetState(CharacterState.Idle);
    }

    void FixedUpdate()
    {
        // 방향키 입력 받고 Direction 저장
        m_Direction = GetInput();

        // 공격 상태 전환
        if (Input.GetKey(KeyCode.Z))
        {
            SetState(CharacterState.Attack);
        }

        // 공격 상태가 아닐때
        if (m_CurState != CharacterState.Attack)
        { 
            // 방향키 입력이 있으면 Move 상태로 전환
            if (m_Direction.x != 0 || m_Direction.y != 0)
            {
                SetState(CharacterState.Move);
            }
            // 방향키 입력이 없을 때 Idle 상태로 전환
            else if (m_Direction.x == 0 || m_Direction.y == 0)
            {
                SetState(CharacterState.Idle);
            }
        }


        // 현재 상태 값에 따른 액션 실행
        StateAction(m_CurState);
        




        //Vector2 dir = base.Manager.Direction;
        //base.Manager.Controller.Movement(dir);
        //base.Manager.Animator.SetFloat("Move", 1.0f);
        //base.Manager.Animator.SetFloat("DirY", dir.y);


        //if (m_CurDirection.x != 0 || m_CurDirection.y != 0)
        //{
        //    SetState(CharState.Run);
        //}

        //if (m_CurDirection.x == 0 && m_CurDirection.y == 0)
        //{
        //    SetState(CharState.Idle);
        //}

        //if (m_CurDirection.x != 0)
        //{
        //    CharacterRender.flipX = m_CurDirection.x < 0;
        //}



    }

    // 방향키 받기
    private Vector2 GetInput()
    {
        Vector2 input = new Vector2
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical")
        };
        return input;
    }

}
