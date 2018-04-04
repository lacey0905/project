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
    // 컨트롤러
    CCharacterController m_Controller;

    // State 저장 
    Dictionary<CharacterState, CCharacterState> DState = new Dictionary<CharacterState, CCharacterState>();

    public CCharacterState[] StateList;         // State 오브젝트 배열

    public CharacterState CurState;             // 현재 오브젝트
    public CharacterState StartState;           // 시작 오브젝트

    [SerializeField]
    private Vector2 m_Direction = Vector2.zero;                                                         // 키 입력 방향
    public Vector2 Direction { set { m_Direction = value; }  get { return m_Direction; } }      // 키 입력 참조

    // 이동 여부
    public bool _isMove = true;
    public bool IsMove { set { _isMove = value; } get { return _isMove; } }

    void Awake()
    {
        m_Controller = GetComponent<CCharacterController>();

        // State를 상속받는 하위 오브젝트를 모두 가져옴
        StateList = GetComponentsInChildren<CCharacterState>();

        // 이넘 타입 키 값 가져옴
        CharacterState[] StateValue = (CharacterState[])System.Enum.GetValues(typeof(CharacterState));

        for (int i = 0; i < StateValue.Length; i++)
        {
            DState.Add(StateValue[i], StateList[i]);            // 템플릿에 넣음

            StateList[i].Init(this);                                    // 가져온 게임 오브젝트 생성자 실행

            // 시작 상태 빼고 모두 비활성화
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
        DState[CurState].SetUpdate();           // 각 상태 오브젝트 업데이트 실행
    }
}
