using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameloop : MonoBehaviour
{
    
    [Range(1f, 5f)][SerializeField] private float m_SpawnTime = 1f;
    [SerializeField] private GameObject m_Consumable = null;

    #region Private var

    private float m_Y = 6f;
    private float m_MaxRange = 2.3f;

    #endregion

    #region Global var

    public static float g_Scroll = 5f;

    #endregion


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
