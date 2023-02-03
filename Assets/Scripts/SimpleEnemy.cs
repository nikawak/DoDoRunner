using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [SerializeField] private Player _player;
    void Update()
    {
        var goal = new Vector3(_player.transform.position.x , 0, _player.transform.position.z);
        transform.LookAt(goal);
        transform.Rotate(0,180,0);
        //var direction = (_player.transform.position - _controller.transform.position).normalized;
        //direction.y = 0;
        //transform.Translate(0,0,10000000);
    }
}
