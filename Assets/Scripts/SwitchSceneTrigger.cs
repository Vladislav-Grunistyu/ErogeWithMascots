using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneTrigger : MonoBehaviour
{
    [SerializeField] private int _sceneId;
    private SceneSwitch _sceneSwitch = new SceneSwitch();

    private void Start()
    {
        _sceneSwitch = FindObjectOfType<SceneSwitch>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            _sceneSwitch.FadeToLevel(_sceneId);
        }
    }
}
