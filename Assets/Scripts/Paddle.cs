using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Vector2 _direction;
    [SerializeField] private float _speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            _direction = Vector2.left;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            _direction = Vector2.right;
        } else {
            _direction = Vector2.zero;
        }
    }

    // Used for physics...basing them on framerate doesn't work.
    void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0) {
            _rb.AddForce(_direction * _speed);
        }
    }
}
