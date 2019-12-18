using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gameloop : MonoBehaviour
{

    [Range(1f, 5f)][SerializeField] private float m_SpawnConsum = 0.5f;
    [Range(1f, 5f)][SerializeField] private float m_SpawnObst = 0.5f;
    [SerializeField] private GameObject m_Consumable = null;
    [SerializeField] private GameObject m_Obstacle = null;

    #region Private var

    private float m_Y = 6f;
    public static float m_currHeight = 0;
    private TextMeshProUGUI m_heightScore = null;

    #endregion

    #region Constants
    private const float m_MaxRange = 2.3f;
    private const float k_minGap = 1f;
    private const float k_MaxGap = 2f;

    #endregion

    #region Global var

    public static float g_Scroll = 5f;

    #endregion

    public void SetSpawnConsum(float time)
    {
        m_SpawnConsum = time;
    }

    private IEnumerator ConsumSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_SpawnConsum);
            Instantiate(m_Consumable, new Vector2(Random.Range(-m_MaxRange, m_MaxRange), m_Y), Quaternion.identity);
        }

    }
    private IEnumerator ObstSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_SpawnObst);
            GameObject obst = Instantiate(m_Obstacle, new Vector2(Random.Range(-m_MaxRange, m_MaxRange), m_Y), Quaternion.identity);
            obst.GetComponent<Obstacle>().SetDist(Random.Range(k_minGap, k_MaxGap));
        }
    }

    private void Awake()
    {
        m_heightScore = GameObject.Find("HeightScore").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        m_currHeight = 0;
        StartCoroutine(ConsumSpawner());
        StartCoroutine(ObstSpawner());
    }

    private void FixedUpdate()
    {
        m_currHeight += Gameloop.g_Scroll * .05f;
        m_heightScore.text = Mathf.Floor(m_currHeight) + "m";
    }


}
