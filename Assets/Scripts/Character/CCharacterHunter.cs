using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void StateAction(CharacterState _state)
    {
        switch (_state)
        {
            case CharacterState.Idle:
                m_Anim.SetFloat("Move", 0.0f);
                m_Anim.SetFloat("DirY", m_Direction.y);
                break;
            case CharacterState.Move:

                m_Controller.Movement(m_Direction);
                m_Anim.SetFloat("Move", 1.0f);
                m_Anim.SetFloat("DirY", m_Direction.y);

                if (m_Direction.x != 0)
                {
                    m_Render.flipX = m_Direction.x < 0;
                }
                break;
        }
    }

    void FixedUpdate()
    {
        // 방향키 입력 받고 Direction 저장
        m_Direction = GetInput();               

        if (m_Direction.x != 0 || m_Direction.y != 0)
        {
            SetState(CharacterState.Move);
        }
        else if (m_Direction.x == 0 || m_Direction.y == 0)
        {
            SetState(CharacterState.Idle);
        }

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
