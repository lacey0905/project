using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterState : MonoBehaviour
{
    protected CCharacterBase _manager;
    protected CCharacterBase Manager { get { return _manager; } }

    private void Awake()
    {
        _manager = GetComponent<CCharacterManager>();
    }

    public virtual void BeginState()
    {
    }

    public virtual void EndState()
    {
    }
}
