using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 100.0f;
    private Vector2 _direction;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        AddStartingForce();
    }

    void AddStartingForce()
    {
        float x = UnityEngine.Random.Range(-1.0f, 1.0f);
        float y = UnityEngine.Random.value;
        _direction.x = x;
        _direction.y = y;
        // Debug.Log($"x = {x}, y = {y}");
        _rb.AddForce(_direction * _speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
