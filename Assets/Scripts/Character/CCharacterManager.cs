using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 캐릭터 상태
public enum CharState
{
    Idle = 0,
    Run,
}

public class CCharacterManager : MonoBehaviour {

    public CharState m_CurState;      // 현재 상태

    private Dictionary<CharState, CStateBase> m_State = new Dictionary<CharState, CStateBase>();

    CCharacterController m_Controller;
    public CCharacterController Controller { get { return m_Controller; } }

    public SpriteRenderer m_Sprite;
    public SpriteRenderer CharacterRender { get { return m_Sprite; } }

    Animator m_Animator;
    public Animator Animator { get { return m_Animator; } }

    [SerializeField]
    private Vector2 m_CurDirection = Vector2.zero;      // 현재 캐릭터 방향 -> 손 땠을 때 Idle 방향
    public Vector2 Direction { get { return m_CurDirection; } }

    private void Awake()
    {
        m_Controller = GetComponent<CCharacterController>();
        m_Animator = m_Sprite.GetComponent<Animator>();
        this.AddState();
    }

    void Start ()
    {
        SetState(CharState.Idle);
    }
	
	void FixedUpdate ()
    {
        m_State[m_CurState].StateUpdate();
        m_CurDirection = GetInput();


        if (m_CurDirection.x != 0 || m_CurDirection.y != 0)
        {
            SetState(CharState.Run);
        }

        if (m_CurDirection.x == 0 && m_CurDirection.y == 0)
        {
            SetState(CharState.Idle);
        }

        if (m_CurDirection.x != 0)
        {
            CharacterRender.flipX = m_CurDirection.x < 0;
        }


        //Animator.SetFloat("DirY", dir.y);

        //if (dir.x != 0 || dir.y != 0)
        //{
        //    SetState(CharState.Run);
        //     = dir;
        //    m_Controller.Movement(dir);
        //    Animator.SetFloat("Move", 1.0f);
        //}
        //else
        //{
        //    SetState(CharState.Idle);
        //    Animator.SetFloat("Move", 0.0f);
        //}

        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    // 공격
        //}

    }

    void AddState()
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

    public void SetState(CharState _newState)
    {
        if (m_CurState != _newState)
        {
            m_State[m_CurState].EndState();
            m_State[_newState].BeginState();
            m_CurState = _newState;
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
