using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private int _sceneId;
    private Animator _animator;
    private void Start()
    {
       _animator = GetComponent<Animator>();
    }

    public void SwitchScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
    
    public void FadeToLevel(int sceneId)
    {
        _animator.SetTrigger("Fate");
        _sceneId = sceneId;
    }
    public void FadeComplete()
    {
        SwitchScene(_sceneId);
    }
}
