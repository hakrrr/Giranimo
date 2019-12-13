using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : Singleton<SceneMgr>
{
    private Animator m_BlackFade;
    private int m_NextSceneId;
    public static float highScore = 0;

    public void switchToScene(int id)
    {
        m_NextSceneId = id;
        m_BlackFade.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(m_NextSceneId);
    }

    private void Awake()
    {
        m_BlackFade = GameObject.FindGameObjectWithTag("BlackFade").GetComponent<Animator>();
    }

}
