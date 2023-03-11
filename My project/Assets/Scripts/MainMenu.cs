using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("SelectedLevel"));
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("App has quit");
    }

    public void SelectLevel(string level)
    {
        

        PlayerPrefs.SetString("SelectedLevel", level);
    }
}
