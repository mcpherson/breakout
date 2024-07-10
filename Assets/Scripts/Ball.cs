using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;
    float _minY = -6.5f;
    [SerializeField] private float _speed = 200.0f;
    Vector2 _direction;
    float _maxVelocity = 8f;
    float _minVelocity = 4f;
    int score = 0;
    int lives = 5;
    [SerializeField] TextMeshProUGUI scoreText;

    void AddStartingForce()
    {
        float x = UnityEngine.Random.Range(-0.2f, 0.2f);
        _direction.x = x;
        _direction.y = -1;
        _rb.AddForce(_direction * _speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        AddStartingForce();
    }

    // Update is called once per frame
    void Update()
    {
        // min/max ball speed
        if (_rb.velocity.magnitude > _maxVelocity)
        {
            Debug.Log("too fast");
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);
        } 
        else if (_rb.velocity.magnitude < _minVelocity && _rb.velocity.magnitude > 0.1) // 
        {
            Debug.Log("too slow");
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity.normalized * 5f, _maxVelocity);
        }

        // handle out-of-bounds
        if (transform.position.y < _minY)
        {
            lives--;
            transform.position = Vector3.zero;
            // nudge the ball downward to prevent soft-lock conditions
            _rb.velocity = new Vector2(0.0f, -0.01f);
            AddStartingForce();
        }

        // handle flat trajectory (soft-lock prevention, maybe clamping can be used here instead?)
        if (_rb.velocity.y == 0)
        {
            Debug.Log("Soft-lock prevented!");
            _rb.AddForce(_direction * 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Brick")) 
        {
            score += 100;
            scoreText.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }

    
}
