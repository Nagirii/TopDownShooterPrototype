
using UnityEngine;
using UnityEngine.SceneManagement; 
public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int LevelToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
    }
    public void FadeToLevel (int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("Fade Out");
    }
    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
