using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
    }
    private void OnDestroy()
    {
        _scoreCounter.AddEgg();
    }
}
