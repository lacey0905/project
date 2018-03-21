using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterState : MonoBehaviour {

    protected CCharacterManager _manager;
    protected CCharacterManager Manager { get { return _manager; } }

    private void Awake()
    {
        _manager = GetComponent<CCharacterManager>();
    }

    public virtual void BeginState()
    {
        Debug.Log(Manager.m_CurState);
    }

    public virtual void EndState()
    {
    }

}
