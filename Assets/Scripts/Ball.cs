using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    // BALL
    Rigidbody2D _rb;
    float _minY = -6.5f;
    [SerializeField] private float _speed = 200.0f;
    Vector2 _direction;
    float _maxVelocity = 8f;
    float _minVelocity = 4f;

    // SCORE
    float _score = 0;
    float _baseScore = 100;
    [SerializeField] TextMeshProUGUI _scoreText;
    float _timeSinceLastBreak = 0f;
    float _maxTimeSinceLastBreak = 2f;

    // LIVES
    int _lives = 3;
    [SerializeField] GameObject[] _livesDisplay;

    // GAME OVER
    [SerializeField] GameObject _gameOverPanel;


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
        // update timer
        _timeSinceLastBreak += Time.deltaTime;

        // min/max ball speed
        if (_rb.velocity.magnitude > _maxVelocity)
        {
            // Debug.Log("too fast");
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxVelocity);
        } 
        else if (_rb.velocity.magnitude < _minVelocity && _rb.velocity.magnitude > 0.1) // 
        {
            // Debug.Log("too slow");
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity.normalized * 5f, _maxVelocity);
        }

        // handle out-of-bounds
        if (transform.position.y < _minY)
        {
            _lives--;

            if (_lives <= 0)
            {
                _livesDisplay[_lives].SetActive(false);
                GameOver();
            }
            else 
            {
                _livesDisplay[_lives].SetActive(false);

                transform.position = Vector3.zero;
                // nudge the ball downward to prevent soft-lock conditions
                _rb.velocity = new Vector2(0.0f, -0.01f);
                AddStartingForce();
            }
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
            // scoring
            if (_timeSinceLastBreak >= _maxTimeSinceLastBreak) // no multiplier
            {
                _score += _baseScore;
            }
            else // multiplier increases as time since last break decreases
            {
                float _scoreToAdd = _baseScore * ((_maxTimeSinceLastBreak - _timeSinceLastBreak) + 1);
                Debug.Log($"add: {_scoreToAdd}, time since last: {_timeSinceLastBreak}");
                _score += _scoreToAdd;
            } 
            

            _timeSinceLastBreak = 0;
            _scoreText.text = Mathf.Round(_score).ToString();
            Destroy(collision.gameObject);
        }
    }

    void GameOver()
    {
        Destroy(gameObject);
        Debug.Log("GAME OVER");
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    
}

// TODO: pause menu, score flashes @ brick position when brick breaks, game modes, sliders, control mapping, high score storage
