using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 200.0f;
    private Vector2 _direction;
    float _maxVelocity = 5f;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        AddStartingForce();
    }

    void AddStartingForce()
    {
        float x = UnityEngine.Random.Range(-0.2f, 0.2f);
        _direction.x = x;
        _direction.y = -1;
        _rb.AddForce(_direction * _speed);
    }

    // Update is called once per frame
    void Update()
    {
        // cap ball speed
        if (_rb.velocity.magnitude > _maxVelocity)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Brick")) 
        {
            Destroy(collision.gameObject);
        }
    }

    
}
