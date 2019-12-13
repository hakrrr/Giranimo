using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Vector2 m_InitDirect;
    private Rigidbody2D m_RigidBody;
    private Transform m_CubeR;
    private Transform m_CubeL;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerController>().OnDeath();
        }
    }

    public void SetDist(float dist)
    {
        m_CubeR.position += new Vector3(dist / 2, 0, 0);
        m_CubeL.position -= new Vector3(dist / 2, 0, 0);
    }

    private const float k_FallSpeed = 2f;

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        m_InitDirect = Vector2.down;
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_CubeR = transform.GetChild(0);
        m_CubeL = transform.GetChild(1);
    }

    private void Start()
    {
        m_RigidBody.velocity = m_InitDirect * k_FallSpeed;
    }

    private void FixedUpdate()
    {
        if (m_RigidBody.transform.position.y < -5.5f) OnDestroy();
    }

}
