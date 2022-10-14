using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Renderer))]

public class SpriteSorter : MonoBehaviour
{
    [SerializeField] private float _offset = - 0.4f;
    private int _sortinOrderBase = 0;
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        _renderer.sortingOrder = (int)(_sortinOrderBase - transform.position.y + _offset);
    }
}
