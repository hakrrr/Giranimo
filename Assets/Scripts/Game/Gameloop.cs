using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameloop : MonoBehaviour
{
    
    [Range(1f, 5f)][SerializeField] private float m_SpawnTime = 1f;
    [SerializeField] private GameObject m_Consumable = null;

    #region Private var

    private float m_Y = 6f;
    private float m_MaxRange = 2.3f;
    private float m_currHeight = 0;
    private TextMeshProUGUI m_heightScore = null;

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

    private void Awake()
    {
        m_heightScore = GameObject.Find("HeightScore").GetComponent<TextMeshProUGUI>();
        Debug.Log(m_heightScore.text);
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        m_currHeight += Gameloop.g_Scroll * .05f;
        m_heightScore.text = Mathf.Floor(m_currHeight) + "m";
    }


}
