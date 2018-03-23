using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterAnimation : MonoBehaviour
{

    public SpriteRenderer m_Sprite;
    private Animator m_Anim;
    
    private PlayerState _CurState;
    
    public void SetState(PlayerState _state)
    {
        _CurState = _state;
    }

    public void SetAnim(PlayerState _curState, Vector2 _dir)
    {


        //if (_dir.x != 0 || _dir.y != 0)
        //{

        //}

        ////m_isMove = _dir.x != 0 || _dir.y != 0;




        //m_Anim.SetFloat("Move", _dir.x != 0 || _dir.y != 0 ? 1.0f : 0.0f);
        //m_Anim.SetFloat("DirY", _dir.y);

        //m_Sprite.flipX = _dir.x < 0;



        //if (_curState == PlayerState.Run)
        //{
        //    m_Anim.SetFloat("DirY", _dir.y);
        //    m_Anim.SetFloat("DirX", Mathf.Abs(_dir.x));
        //}


    

        
        //m_Anim.SetFloat("DirY", _dir.y);






        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    m_Anim.SetTrigger("Attack" +"");
        //}

        //if (_dir.x != 0)
        //{
        //    if (_dir.x >= 1.0f)
        //    {
        //        m_Sprite.flipX = false;
        //    }
        //    else if (_dir.x <= 1.0f)
        //    {
        //        m_Sprite.flipX = true;
        //    }

        //    if (_dir.y >= 1.0f)
        //    {
        //        m_Anim.SetBool("Up", true);
        //        m_Anim.SetBool("Down", false);
        //    }
        //    else if (_dir.y <= -1.0f)
        //    {
        //        m_Anim.SetBool("Up", false);
        //        m_Anim.SetBool("Down", true);
        //    }
        //    else
        //    {
        //        m_Anim.SetBool("Up", true);
        //        m_Anim.SetBool("Down", true);
        //    }
        //}
        //else if (_dir.x == 0 && _dir.y == 0)
        //{
        //    m_Anim.SetBool("Up", false);
        //    m_Anim.SetBool("Down", false);
        //}


    }

    public void Init()
    {
        m_Anim = m_Sprite.GetComponent<Animator>();
    }

    private void Awake()
    {
        
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
