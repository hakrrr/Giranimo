using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D m_RigidBody;
    protected Vector2 m_Direction;
    [SerializeField]
    protected float m_Speed;

    private void Awake()
    {
        Input.multiTouchEnabled = true;
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0) moveCharacter(Input.GetTouch(0));
    }

    void moveCharacter(Touch input)
    {
        m_Direction = input.position.x < 500 ? Vector2.left : Vector2.right;
        m_RigidBody.velocity += m_Direction * m_Speed;
    }
}
