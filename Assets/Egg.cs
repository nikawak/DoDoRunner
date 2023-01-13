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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _scoreCounter.AddEgg();
            Destroy(this.gameObject);
        }
    }
}
