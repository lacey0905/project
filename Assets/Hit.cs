using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    int m_HP = 100;
    public TextMesh HP;

	void Update ()
    {
        HP.text = m_HP.ToString();
    }
 
    public void SetHit()
    {
        m_HP -= 10;
    }

}
