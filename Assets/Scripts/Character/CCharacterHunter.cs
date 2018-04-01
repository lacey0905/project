using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum CharacterState 
{ 
    Standard = 0,
    BaseAttack,
}

public class CCharacterHunter : CCharacterBase
{
    CCharacterController m_Controller;
    Dictionary<CharacterState, CCharacterState> DState = new Dictionary<CharacterState, CCharacterState>();
    public List<CCharacterState> StateList = new List<CCharacterState>();

    public CharacterState CurState;

    [SerializeField]
    private Vector2 m_Direction = Vector2.zero;

    void Awake()
    {
        m_Controller = GetComponent<CCharacterController>();
        CharacterState[] StateValue = (CharacterState[])System.Enum.GetValues(typeof(CharacterState));
        for (int i = 0; i < StateValue.Length; i++)
        {
            DState.Add(StateValue[i], StateList[i]);
        }
    }

    void Start()
    {
        CurState = CharacterState.Standard;
    }


    public void SetState(CharacterState _newState)
    {
        if (CurState != _newState)
        {
            DState[CurState].gameObject.SetActive(false);
            DState[_newState].gameObject.SetActive(true);
            CurState = _newState;
            //DState[CurState].BeginState();
        }
    }


    void FixedUpdate()
    {

        // 방향키 입력 받고 Direction 저장
        m_Direction = GetInput();


        // 방향키 입력이 있으면 Move 상태로 전환
        if (m_Direction.x != 0 || m_Direction.y != 0)
        {
            m_Controller.Movement(m_Direction);

            SetState(CharacterState.Standard);

            //Standard.GetComponent<Animator>().SetFloat("Move", 1.0f);                  // 애니메이터 Move 블렌드 움직임 트리로 변경
            //Standard.GetComponent<Animator>().SetFloat("DirY", m_Direction.y);         // 애니메이터 Y축 파라미터 변경

            // 좌우 방향키가 입력이 될 때만 스프라이트 반전
            if (m_Direction.x != 0)
            {
                //m_Render.flipX = m_Direction.x < 0;
            }
        }

        //// 방향키 입력이 없을 때 Idle 상태로 전환
        //else if (m_Direction.x == 0 || m_Direction.y == 0)
        //{
        //    Standard.GetComponent<Animator>().SetFloat("Move", 0.0f);                  // 애니메이터 Move 블렌드 0으로 초기화
        //    Standard.GetComponent<Animator>().SetFloat("DirY", m_Direction.y);         // 애니메이터 Y축 파라미터 변경
        //}


        // 공격 상태 전환
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetState(CharacterState.BaseAttack);
        }


    }

    bool temp2 = false;

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
