using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterState : MonoBehaviour
{
    private CCharacterManager _manager;
    protected CCharacterManager Manager { get { return _manager; } }

    protected Animator Animator;
    protected Collider Collider;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Collider = GetComponent<Collider>();
        GetComponent<SpriteRenderer>().enabled = true;
    } 

    public void Init(CCharacterManager _CharManager)
    {
        _manager = _CharManager;
    }

    public virtual void SetUpdate() { }
    public virtual void BeginState() { }
    public virtual void EndState() { }
}
