using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    [SerializeField] private float _speed;

    [SerializeField] private float _inputHorizontal;

    private float _maxX = 7.85f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _speed = 6;
        _inputHorizontal = Input.GetAxis("Horizontal");

        if ((_inputHorizontal > 0 && transform.position.x < _maxX) || (_inputHorizontal < 0 && transform.position.x > -_maxX)) {
            // https://www.youtube.com/watch?v=jyXZ3RVe5as
            // deltaTime basically normalizes speed at different frame rates
            transform.position +=Vector3.right*_inputHorizontal*_speed*Time.deltaTime;
        }
       
    }
}
