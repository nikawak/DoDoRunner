using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotateSpeed = 3f;
    [SerializeField] private float _floatRatio = 5f;
    [SerializeField] Vector3 _cameraOffset = new Vector3(0, 1f, -6f);
    [SerializeField] private Camera _camera;
    
    private CharacterController _controller;

    public event Action PlayerDied;

    private static float _gravity = 9.81f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        Move();
        Rotate();
        FloatInTheAir();
    }
    public void FloatInTheAir()
    {
        if (!_controller.isGrounded)
        {
            _controller.Move(-Vector3.up * Time.deltaTime * _gravity / _floatRatio);
        }
    }
    public void Move()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * _speed;

        var moveVector = transform.right * x + transform.forward * z;

        _controller.Move(moveVector);
    }
    public void Rotate()
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
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Egg")) 
        {
            Destroy(hit.gameObject); 
        }
        else if (hit.collider.CompareTag("Enemy"))
        {
            PlayerDied();
        }
    }
}
