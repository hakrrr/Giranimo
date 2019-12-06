using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Range(1f, 10f)][SerializeField] protected float m_MoveSpeed;
    [Range(0f,5f)][SerializeField] protected float m_FallSpeed;
    protected Rigidbody2D m_RigidBody;
    protected Vector3 m_CurrPos;
    protected Vector2 m_Direction;
    protected Vector2 m_InitDirect;
    protected Vector3 m_Velocity = Vector3.zero;

    const float k_Scale = .1f;


    void moveCharacter(Touch input)
    {
        m_Direction = input.position.x < 500 ? Vector2.left : Vector2.right;
        m_RigidBody.velocity = Vector3.SmoothDamp(m_RigidBody.velocity, m_InitDirect + (m_Direction * m_MoveSpeed), ref m_Velocity, .1f);
    }

    void OnDeath()
    {
        Destroy(this.gameObject);
        SceneMgr.Instance.switchToScene(2);
    }

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_InitDirect = k_Scale * Vector2.down * m_FallSpeed;
    }

    private void Start()
    {
        m_RigidBody.velocity = m_InitDirect;
    }

    private void FixedUpdate()
    {
        m_CurrPos = m_RigidBody.position;
        if (m_RigidBody.transform.position.y < -5.5f) OnDeath();
        if (m_RigidBody.transform.position.x < -2.85f)
            m_RigidBody.transform.position = new Vector3(2.8f, m_CurrPos.y, 0);
        else if (m_RigidBody.transform.position.x > 2.85f)
            m_RigidBody.transform.position = new Vector3(-2.8f, m_CurrPos.y, 0);

        if (Input.touchCount > 0) moveCharacter(Input.GetTouch(0));
        else m_RigidBody.velocity = Vector3.SmoothDamp(m_RigidBody.velocity, m_InitDirect, ref m_Velocity, .05f); ;
    }
}
