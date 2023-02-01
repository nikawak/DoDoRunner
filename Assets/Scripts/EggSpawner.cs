using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] GameObject _eggPrefab;
    [SerializeField] Rect _spawnZone;
    private float _timer;

    void Update()
    {
        if (Convert.ToInt32(Time.time) % 10 == 0)
        {
            var randX = Random.Range(_spawnZone.xMin, _spawnZone.xMax);
            var randZ = Random.Range(_spawnZone.yMin, _spawnZone.yMax);
            var position = new Vector3(randX, 15, randZ);
            Instantiate(_eggPrefab, position, Quaternion.identity);
        }
    }
}
