using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterHunter : CCharacterBase
{

    public CCharacterController m_Controller;
    public CCharacterAnimation m_Anim;

    void Awake()
    {
        m_Controller = GetComponent<CCharacterController>();
        m_Anim = GetComponent<CCharacterAnimation>();
        m_Anim.Init();
    }

    [SerializeField]
    private Vector2 m_Direction = Vector2.zero;

    void Start()
    {
        base.SetupStat();
        base.DecreseHealth(10);
    }
    
    void FixedUpdate()
    {
        m_Direction = GetInput();               // 방향키 입력 받고 Direction 저장
        m_Controller.Movement(m_Direction);     // 컨트롤러 클래스에 이동방향 전달


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
