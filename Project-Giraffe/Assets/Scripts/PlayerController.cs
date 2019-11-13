using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] protected float m_Speed;
    protected Rigidbody2D m_RigidBody;
    protected Vector2 m_Direction;

    protected Vector3 m_Velocity = Vector3.zero;

    private void Awake()
    {
        Input.multiTouchEnabled = true;
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0) moveCharacter(Input.GetTouch(0));
        else m_RigidBody.velocity = Vector3.SmoothDamp(m_RigidBody.velocity, Vector3.zero, ref m_Velocity, .05f); ;
    }
    void moveCharacter(Touch input)
    {
        m_Direction = input.position.x < 500 ? Vector2.left : Vector2.right;
        m_RigidBody.velocity = Vector3.SmoothDamp(m_RigidBody.velocity, m_Direction * m_Speed, ref m_Velocity, .1f);
    }
}
