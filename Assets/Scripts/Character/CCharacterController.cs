using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCharacterController : MonoBehaviour
{
    Rigidbody m_RigidBody;
    CCharacterManager Manager;

    Vector3 MovementDirection = Vector3.zero;

    public float m_fSpeed = 5.0f;

    void Awake()
    {
        Manager = GetComponent<CCharacterManager>();
        m_RigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 방향키 입력 받고 Direction 저장
        Vector2 _dir = GetInput();
        Manager.Direction = _dir;

        // 캐릭터 이동
        if (Manager.IsMove)
        {
            Movement(_dir);
        }
    }

    public void Movement(Vector2 _dir)
    {
        MovementDirection.Set(_dir.x, 0, _dir.y);
        m_RigidBody.MovePosition((MovementDirection.normalized * m_fSpeed * Time.smoothDeltaTime) + transform.position);
    }

    // 방향키 받기
    private Vector2 GetInput()
    {
        Vector2 input = new Vector2
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = Input.GetAxisRaw("Vertical")
        };
        return input;
    }

}
