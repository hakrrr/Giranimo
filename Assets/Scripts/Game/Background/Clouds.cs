using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{

    [SerializeField] private float m_ScrollFactor = 0f;
    private Material m_Material;

    private void Awake()
    {
        m_Material = GetComponent<Renderer>().material;
    }

    private void FixedUpdate()
    {
        Vector2 currOffset = m_Material.GetTextureOffset("_MainTex");
        Vector2 deltaOffset = Vector2.up * Time.deltaTime * Gameloop.g_Scroll * m_ScrollFactor;
        m_Material.SetTextureOffset("_MainTex", currOffset + deltaOffset);
    }
    

}
