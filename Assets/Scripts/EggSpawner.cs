using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _eggPrefab;
    [SerializeField] private Player _player;
    [SerializeField] private Vector2 _rectSize;
    private float _timer;
    private Rect _spawnZone;


    private void Start()
    {
        StartCoroutine(SpawnEgg());
    }
    private void Update()
    {
        var playerPos = new Vector2(_player.transform.position.x, _player.transform.position.z);
        var rectPos = new Vector2(playerPos.x - _rectSize.x / 2, playerPos.y - _rectSize.y / 2);
        
        _spawnZone = new Rect(rectPos, _rectSize);
        
    }
    private IEnumerator SpawnEgg()
    {
        while (_player.isActiveAndEnabled)
        {
            yield return new WaitForSeconds(1);

            var randX = Random.Range(_spawnZone.xMin, _spawnZone.xMax);
            var randZ = Random.Range(_spawnZone.yMin, _spawnZone.yMax);
            var position = new Vector3(randX, 15, randZ);
            Instantiate(_eggPrefab, position, Quaternion.identity);
        }
    }
}
