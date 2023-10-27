using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    CharacterController _Controller;
    Transform _fpsCamera;

    [SerializeField] float _speed;
    [SerializeField] float _sensitivity = 50;
    [SerializeField] float _jumpHeight;

    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private float _sensorRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;

    private float _gravity = -9.81f;
    private Vector3 _playerGravity;

    private bool _isGrounded;

    float _XRotation = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _Controller = GetComponent<CharacterController>();
        _fpsCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _XRotation -= mouseY;
        _XRotation = Mathf.Clamp(_XRotation, -90, 90);

        _fpsCamera.localRotation = Quaternion.Euler(_XRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        float X = Input.GetAxis("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * X + transform.forward * z;

        _Controller.Move(move.normalized * _speed * Time.deltaTime);

    }   
        void Jump()
    {

        _isGrounded = Physics.CheckSphere(_sensorPosition.position, _sensorRadius, _groundLayer);

        if(_isGrounded && _playerGravity.y < 0)
        {
            _playerGravity.y = 0;

        }
        if(_isGrounded && Input.GetButtonDown("Jump"))
        {
            _playerGravity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        }

        _playerGravity.y += _gravity * Time.deltaTime;

        _Controller.Move(_playerGravity * Time.deltaTime);
    }

    
}
