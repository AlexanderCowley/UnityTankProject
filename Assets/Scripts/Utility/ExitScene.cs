using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitScene : MonoBehaviour
{
    void Awake()
    {
        
    }

    void QuitBuild()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitBuild();
    }
}