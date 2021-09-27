using UnityEngine;

public class ExitScene : MonoBehaviour
{
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