using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] protected float m_FallSpeed;
    [SerializeField] protected float m_PushFactor;
    protected Rigidbody2D m_RigidBody;
    protected Rigidbody2D m_Player;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        m_RigidBody.velocity = 0.1f * Vector2.down * m_FallSpeed;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_Player = collision.gameObject.GetComponent<Rigidbody2D>();
            m_Player.AddForce(10 * Vector2.up * m_PushFactor);
            Destroy(this.gameObject);
        }
    }

}
