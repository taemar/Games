using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(1);

        Time.timeScale = 1;
    }

    public void StartLvL(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseON()
    {
        Time.timeScale = 0;
    }

    public void PauseOff()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
