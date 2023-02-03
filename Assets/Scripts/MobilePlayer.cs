using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayer : Player
{
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        //_animator = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        Rotate();
        FloatInTheAir();
    }
    protected override void Move()
    {

        var moveVector = transform.forward *  Time.deltaTime * _speed;

        _controller.Move(moveVector);
    }
    protected override void Rotate()
    {
        var yRot = Input.GetAxis("Mouse X") * _rotateSpeed;
        var isRot = yRot != 0;

        transform.Rotate(0, yRot, 0);

        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, transform.rotation, Time.deltaTime * 2);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, transform.position + _camera.transform.TransformDirection(_cameraOffset), Time.deltaTime * 2);


        var direction = transform.position - _camera.transform.position;
        var rotation = Quaternion.LookRotation(direction);
        _camera.transform.rotation = Quaternion.Lerp(_camera.transform.rotation, rotation, Time.deltaTime * 2);
    }
}
