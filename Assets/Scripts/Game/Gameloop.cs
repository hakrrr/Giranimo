using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameloop : MonoBehaviour
{
    
    [Range(1f, 5f)][SerializeField] private float m_SpawnTime = 1f;
    [SerializeField] private GameObject m_Consumable = null;
    private float m_Y = 6f;
    private float m_MaxRange = 2.3f;

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_SpawnTime);
            SpawnConsume();
        }

    }

    private void SpawnConsume()
    {
        Instantiate(m_Consumable, new Vector2(Random.Range(-m_MaxRange, m_MaxRange), m_Y), Quaternion.identity);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }
}
