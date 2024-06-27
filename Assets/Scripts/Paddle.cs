// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Paddle : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Vector2 _direction;
    [SerializeField] private float _speed = 20.0f;
    private Vector3 _baseRotation;
    private Vector3 _curRotation;
    private float _maxRotation = -20.0f;
    private float _minRotation = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetKey(KeyCode.A)) {
            _direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.D)) {
            _direction = Vector2.right;
        } else {
            _direction = Vector2.zero;
        }

        // Rotation
        
    }

    // Used for physics...basing them on framerate doesn't work.
    void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0) {
            _rb.AddForce(_direction * _speed);
        }
    }
}
