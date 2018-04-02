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

    public List<ParticleSystem> EffectArr;

    public override void BeginState()
    {
        Manager.IsMove = false;
        BaseAttack();
    }

    float hit = 0f;

    void OnTriggerEnter(Collider _col)
    {
        _col.GetComponent<Hit>().SetHit();
    }
  

    void BaseAttack()
    {
        GetComponent<Collider>().enabled = true;

        if (Manager.Direction.y < 0)
        {
            Animator.Play("BaseAttackDown", -1, 0);
        }
        else if (Manager.Direction.y > 0)
        {
            Animator.Play("BaseAttackUp", -1, 0);
        }
        else
        {
            Animator.Play(BaseAttackArr[Count], -1, 0);
        }

        if (Manager.Direction.x != 0)
        {
            if (Manager.Direction.x < 0)
            {
                EffectArr[Count].startRotation3D = new Vector3(0, 3.14f, 0);
            }
            else
            {
                EffectArr[Count].startRotation3D = new Vector3(0, 0, 0);
            }
        }

        for (int i = 0; i < EffectArr.Count; i++)
        {
            if (i == Count)
            {
                EffectArr[i].gameObject.SetActive(true);
            }
            else
            {
                EffectArr[i].gameObject.SetActive(false);
            }

        }

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
