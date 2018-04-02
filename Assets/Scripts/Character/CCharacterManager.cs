using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
    Standard = 0,
    BaseAttack,
}

public class CCharacterManager : CCharacterBase
{
    CCharacterController m_Controller;
    Dictionary<CharacterState, CCharacterState> DState = new Dictionary<CharacterState, CCharacterState>();

    public CCharacterState[] StateList;

    public CharacterState CurState;
    public CharacterState StartState;

    [SerializeField]
    private Vector2 m_Direction = Vector2.zero;
    public Vector2 Direction { set { m_Direction = value; }  get { return m_Direction; } }

    public bool _isMove = true;
    public bool IsMove { set { _isMove = value; } get { return _isMove; } }

    void Awake()
    {
        m_Controller = GetComponent<CCharacterController>();

        StateList = GetComponentsInChildren<CCharacterState>();
        CharacterState[] StateValue = (CharacterState[])System.Enum.GetValues(typeof(CharacterState));

        for (int i = 0; i < StateValue.Length; i++)
        {
            DState.Add(StateValue[i], StateList[i]);

            StateList[i].Init(this);

            if (StateValue[i] == StartState) continue;

            StateList[i].gameObject.SetActive(false);
        }
    }

    public void SetState(CharacterState _newState)
    {
        if (CurState != _newState)
        {
            DState[CurState].gameObject.SetActive(false);
            DState[_newState].gameObject.SetActive(true);
            CurState = _newState;
            DState[CurState].BeginState();
        }
    }

    void FixedUpdate()
    {
        if (IsMove)
        {
            // 방향키 입력이 있으면 Move 상태로 전환
            if (m_Direction.x != 0 || m_Direction.y != 0)
            {
                SetState(CharacterState.Standard);
                // 좌우 방향키가 입력이 될 때만 스프라이트 반전
                if (m_Direction.x != 0)
                {
                    foreach (CCharacterState s in DState.Values)
                    {
                        s.GetComponent<SpriteRenderer>().flipX = m_Direction.x < 0;
                    }
                }
            }
        }
        DState[CurState].SetUpdate();
    }
}
