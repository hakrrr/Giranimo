using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : MonoBehaviour
{
    private readonly float m_PushFactor;
    private Rigidbody2D m_RigidBody;
    private Rigidbody2D m_Player;

    //Set readonly Push
    public Consumable(float push)
    {
        m_PushFactor = push;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Player = collision.gameObject.GetComponent<Rigidbody2D>();
            m_Player.AddForce(5 * Vector2.up * m_PushFactor, ForceMode2D.Impulse);
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        m_RigidBody.velocity = 0.7f * Vector2.down * Gameloop.g_Scroll;
    }

    private void FixedUpdate()
    {
        if (m_RigidBody.transform.position.y < -5.5f) OnDestroy();
    }

}
