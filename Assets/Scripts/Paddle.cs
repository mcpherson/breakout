using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody2D _rb;

    float _moveSpeed;

    float _inputHorizontal;

    // Start is called before the first frame update
    void Start()
    {

        _rb = gameObject.GetComponent<Rigidbody2D>();

        _moveSpeed = 3.5f;
        
    }

    // Update is called once per frame
    void Update()
    {

        _inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (_inputHorizontal != 0) {
            _rb.AddForce(new Vector2(_inputHorizontal * _moveSpeed, 0f));
        }
        
    }
}
