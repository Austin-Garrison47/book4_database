using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtons : MonoBehaviour
{
    public void GoToIntro()
    {
        SceneManager.LoadScene("intro");
    }

    public void GoToShowScores()
    {
        SceneManager.LoadScene("showScores");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("game");
    }

    public void GoToExit()
    {
        SceneManager.LoadScene("exit");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}