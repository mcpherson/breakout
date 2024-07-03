// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Paddle : MonoBehaviour
{

    [SerializeField] private float _speed = 30.0f;

    private Rigidbody2D _rb;
    private Vector2 _direction;

    private float _rightMaxRotation = -20.0f;
    private float _leftMaxRotation = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetKey(KeyCode.A)) 
        {
            _direction = Vector2.left;
        } 
        else if (Input.GetKey(KeyCode.D)) 
        {
            _direction = Vector2.right;
        } 
        else 
        {
            _direction = Vector2.zero;
        }   
        
    }

    // Used for physics behavior
    void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0) 
        {
            _rb.AddForce(_direction * _speed);
        }

        // Rotation
        if (Input.GetKey(KeyCode.RightArrow))  
        {
            if (_rb.rotation > _rightMaxRotation )
            {
                _rb.rotation -= 2f;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (_rb.rotation < _leftMaxRotation )
            {
                _rb.rotation += 2f;
            }
        }

    }

    void MovePlayer() 
    {

    }

    // https://forum.unity.com/threads/how-to-print-objects-data-into-unity-debugger-console.540193/
    public static void DumpToConsole(object obj)
    {
        var output = JsonUtility.ToJson(obj, true);
        Debug.Log(output);
    }
}
