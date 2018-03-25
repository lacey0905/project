using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStateBase : MonoBehaviour {

    protected CCharacterManager _manager;
    protected CCharacterManager Manager { get { return _manager; } }

    private void Awake()
    {
        _manager = GetComponent<CCharacterManager>();
    }

    public virtual void BeginState() { }
    public virtual void EndState() { }
    public virtual void StateUpdate() { }
}
