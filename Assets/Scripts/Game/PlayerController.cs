using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Range(1f, 10f)][SerializeField] protected float m_MoveSpeed;
    [Range(0f,10f)][SerializeField] protected float m_FallSpeed;
    
    protected Rigidbody2D m_RigidBody;
    protected Vector3 m_CurrPos;
    protected Transform m_MassCenter;
    protected Vector2 m_InitDirect;
    protected Vector3 m_Velocity = Vector3.zero;

    const float k_Scale = .1f;


    void moveCharacter(Touch input)
    {
        float direction = input.position.x < 500 ? 10f : -10f;
        if (m_RigidBody.transform.position.x < -2.5f) direction = direction > 0 ? 0 : direction;
        else if (m_RigidBody.transform.position.x > 2.5f) direction = direction > 0 ? direction : 0;
        m_RigidBody.transform.RotateAround(m_MassCenter.position, Vector3.forward, Time.deltaTime * direction * m_MoveSpeed);

    }

    public void OnDeath()
    {
        Destroy(this.gameObject);
        if (SceneMgr.highScore < Gameloop.m_currHeight) SceneMgr.highScore = Gameloop.m_currHeight;
        SceneMgr.Instance.switchToScene(2);
    }

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_MassCenter = GameObject.Find("MassCenter").GetComponent<Transform>();
        m_InitDirect = k_Scale * Vector2.down * m_FallSpeed;
        
    }

    private void Start()
    {
        m_RigidBody.velocity = m_InitDirect;
    }

    private void FixedUpdate()
    {
        m_CurrPos = m_RigidBody.position;
        m_RigidBody.velocity = Vector3.SmoothDamp(m_RigidBody.velocity, m_InitDirect, ref m_Velocity, .05f);
        if (m_RigidBody.transform.position.y < -5.5f) OnDeath();
        if (Input.touchCount > 0) moveCharacter(Input.GetTouch(0));
    }

}
