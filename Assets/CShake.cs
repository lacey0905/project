using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShake : MonoBehaviour
{
    public float shakes = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    public Vector3 originalPos;
    bool CameraShaking;

    void Start()
    {
        originalPos = this.transform.localPosition;
        CameraShaking = false;
    }

    public void ShakeCamera(float shaking)
    {
        shakes = shaking;
        originalPos = this.transform.localPosition;
        CameraShaking = true;
    }

    void FixedUpdate()
    {
        if (CameraShaking)
        {
            if (shakes > 0)
            {
                this.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                //gameObject.transform.position += new Vector3(0f, 0f, -1f);
                shakes -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakes = 0f;
                gameObject.transform.localPosition = originalPos;
                CameraShaking = false;
            }
        }
    }
}
