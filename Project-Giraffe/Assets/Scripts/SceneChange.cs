using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    protected Animator animator;

    private void switchToScene(int id = 1)
    {
        animator.SetTrigger("FadeOut");
    }

    private void OnFadeComplete()
    {
        int nextId = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextId);
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
