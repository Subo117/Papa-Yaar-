using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        AudioManager.Instance.PlayAudio();

        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlayAudio();

        Application.Quit();
    }
}
