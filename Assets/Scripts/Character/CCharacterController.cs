using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterController : MonoBehaviour
{
    Rigidbody m_RigidBody;

    Vector3 m_Direction = Vector3.zero;

    public float m_fSpeed = 5.0f;

    void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    public void Movement(Vector2 _dir)
    {
        m_Direction.Set(_dir.x, 0, _dir.y);
        m_RigidBody.MovePosition((m_Direction.normalized * m_fSpeed * Time.smoothDeltaTime) + transform.position);
    }
}
