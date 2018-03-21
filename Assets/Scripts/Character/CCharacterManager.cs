using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 상태
public enum PlayerState
{
    Idle = 0,
    Run,
    Attack,
    //Dead
}

public class CCharacterManager : MonoBehaviour {

    private Dictionary<PlayerState, CCharacterState> m_State = new Dictionary<PlayerState, CCharacterState>();

    public PlayerState m_StartState;    // 시작 상태
    public PlayerState m_CurState;      // 현재 상태

    // 컨트롤러 클래스
    private CCharacterController m_Controller;
    public CCharacterController Controller { get { return m_Controller; } }

    // 애니메이션 클래스
    private CCharacterAnimation m_Animation;
    public CCharacterAnimation Animation { get { return m_Animation; } }

    [SerializeField]
    private Vector2 m_CurDirection = Vector2.zero;      // 현재 캐릭터 방향 -> 손 땠을 때 Idle 방향

    private void Awake()
    {
        m_Controller = GetComponent<CCharacterController>();
        m_Animation = GetComponent<CCharacterAnimation>();
        m_Animation.Init();

        // State 클래스를 찾아서 리스트형태로 저장함
        PlayerState[] stateValues = (PlayerState[])System.Enum.GetValues(typeof(PlayerState));
        foreach (PlayerState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("CCharacterState" + s.ToString("G"));
            CCharacterState state = (CCharacterState)GetComponent(FSMType);
            if (state == null)
                state = (CCharacterState)gameObject.AddComponent(FSMType);
            state.enabled = false;
            m_State.Add(s, state);
        }

    }

    // State 변경
    public void SetState(PlayerState _newState)
    {
        m_CurState = _newState;
        m_State[m_CurState].BeginState();
        m_State[m_CurState].enabled = true;

        m_Animation.SetAnim(m_CurState, GetInput());

    }

    void Start ()
    {
        if (Application.isPlaying)
        {
            SetState(m_StartState);
        }
    }
	
	void FixedUpdate ()
    {
        Vector2 _dir = GetInput();          // 방향키 받기

        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 공격
        }

        // 이동 키 입력이 들어 왔을 경우
        if (_dir.x != 0 || _dir.y != 0)
        {
            m_CurDirection = _dir;
            m_Controller.Movement(_dir);
            SetState(PlayerState.Run);
        }
        // 이동 키 입력이 없다
        else if (_dir.x == 0 && _dir.y == 0)
        {
            SetState(PlayerState.Idle);
        }
        
    }

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
