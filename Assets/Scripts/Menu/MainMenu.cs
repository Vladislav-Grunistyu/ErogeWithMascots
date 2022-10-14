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
        Debug.Log("� ������� ��� ������");
    }
    public void ClickSettingsButton()
    {
        Debug.Log("�����");
    }
    public void ClickExitButton()
    {
        Application.Quit();
    }
}
