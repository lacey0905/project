using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (hit)
        {
            burn += Time.deltaTime;
            if (burn < 0.3f)
            {
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.5f, 0.3f);
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                burn = 0f;
            }
            
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                hit = false;
                timer = 0f;
                GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }

    }

    float burn = 0f;
    float timer = 0f;

    bool hit = false;
    public void SetHit()
    {
        hit = true;
    }

}
