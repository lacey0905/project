using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStateBaseAttack : CCharacterState
{
    public float MaxDelay;
    public float Delay = 0f;
    public int Count = 0;

    float Reset = 0.8f;
    public float ResetTimer = 0f;

    string[] BaseAttackArr = new string[] { "BaseAttackA", "BaseAttackB", "BaseAttackC" };

    public override void BeginState()
    {
        Manager.IsMove = false;
        BaseAttack();
    }

    float hit = 0f;

    void OnTriggerEnter(Collider _col)
    {
        _col.GetComponent<Hit>().SetHit();
        GetComponent<Collider>().enabled = false;
    }

    void BaseAttack()
    {
        GetComponent<Collider>().enabled = true;
        Animator.Play(BaseAttackArr[Count], -1, 0);
        Count++;
        if (Count > 2) Count = 0;
    }

    public override void SetUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (MaxDelay <= Delay)
            {
                BaseAttack();
                Delay = 0f;
                ResetTimer = 0f;
            }
        }

        ResetTimer += Time.deltaTime;
        Delay += Time.deltaTime;

        if (ResetTimer > Reset)
        {
            Manager.SetState(CharacterState.Standard);
            ResetTimer = 0f;
            Delay = MaxDelay;
            Count = 0;
        }
    }
} 
