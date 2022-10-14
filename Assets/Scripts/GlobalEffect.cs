using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEffect : MonoBehaviour
{
    [SerializeField] private static Animation _inFate;
    [SerializeField] private static Animation _outFate;
    public static void InFate()
    {
        _inFate.Play();
    }
    public static void OutFate()
    {
        _outFate.Play();
    }
}
