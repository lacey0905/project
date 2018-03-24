using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 상태
public enum CharState
{
    Idle = 0,
    Run,
    //Attack,
}

public class CCharacterManager : MonoBehaviour {

    public CharState m_CurState;      // 현재 상태

    private Dictionary<CharState, CStateBase> m_State = new Dictionary<CharState, CStateBase>();

    private CCharacterController m_Controller;

    [SerializeField]
    bool IsMove = false;


    [SerializeField]
    private Vector2 m_CurDirection = Vector2.zero;      // 현재 캐릭터 방향 -> 손 땠을 때 Idle 방향

    public void SetState(CharState _newState)
    {
        m_State[m_CurState].EndState();
        m_State[_newState].BeginState();
        m_CurState = _newState;
    }

    private void Awake()
    {
        m_Controller = GetComponent<CCharacterController>();
        this.StateSearch();
    }
    

    void Start ()
    {
        SetState(CharState.Idle);
    }
	
	void FixedUpdate ()
    {
        Vector2 _dir = GetInput();

        if (_dir.x != 0 || _dir.y != 0)
        {
            SetState(CharState.Run);
            //m_CurDirection = _dir;
            //m_Controller.Movement(_dir);
        }
      

        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 공격
        }

        // 이동 키 입력이 들어 왔을 경우
        
        // 이동 키 입력이 없다
        else if (_dir.x == 0 && _dir.y == 0)
        {
        }
        
    }

    void StateSearch()
    {
        CharState[] stateValues = (CharState[])System.Enum.GetValues(typeof(CharState));
        foreach (CharState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("CState" + s.ToString("G"));
            CStateBase state = (CStateBase)GetComponent(FSMType);
            if (state == null)
                state = (CStateBase)gameObject.AddComponent(FSMType);

            m_State.Add(s, state);
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
