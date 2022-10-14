using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ClickNewGameButton() 
    {
        SceneManager.LoadScene(1);
    }
    public void ClickLoadButton()
    {
        Debug.Log("Я заебусь это делать");
    }
    public void ClickSettingsButton()
    {
        Debug.Log("Скоро");
    }
    public void ClickExitButton()
    {
        Application.Quit();
    }
}
