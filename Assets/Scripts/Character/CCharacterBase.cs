using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CCharacterBase : MonoBehaviour
{
    [Serializable]
    public class Stats
    {
        public int m_MaxHP;
        public int m_HP;
    }
    
    public Stats CharacterStat = new Stats();

    public void SetupStat()
    {
        CharacterStat.m_MaxHP = 100;
        CharacterStat.m_HP = CharacterStat.m_MaxHP;
    }

    public void DecreseHealth(int _damage)
    {
        CharacterStat.m_HP -= _damage;
        if(CharacterStat.m_HP <= 0)
        {
            CharacterStat.m_HP = 0;
        }
    }

    public void IncreaseHealth(int _health)
    {
        CharacterStat.m_HP += _health;
        if (CharacterStat.m_HP >= CharacterStat.m_MaxHP)
        {
            CharacterStat.m_HP = CharacterStat.m_MaxHP;
        }
    }

}
