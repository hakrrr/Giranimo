using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChange : MonoBehaviour
{
    protected Animator animator;


    private void switchToScene(int id = 1)
    {
        animator.SetTrigger("FadeOut");
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.touchCount > 0) switchToScene();
    }
}
