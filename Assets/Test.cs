using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	void Start () {
		
	}
	
    Color _color = new Color(1f, 1f, 1f, 1f);
    Color _color2 = new Color(1f, 0f, 0f, 1.0f);
    float time = 0f;
    float time2 = 0f;

    bool test = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            test = true;
        }

        time2 += Time.deltaTime;

        if (time2 > 2.0f)
        {
            time2 = 0f;
            test = false;
        }

        if (test)
        {
            time += Time.deltaTime;

            if (time > 0.2f)
            {
                GetComponent<SpriteRenderer>().color = _color2;
                time = 0f;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = _color;
            }
        }
        
	}
}
