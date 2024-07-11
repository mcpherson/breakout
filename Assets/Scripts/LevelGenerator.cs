using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    Vector2Int _levelSize = new Vector2Int(8, 4); // num rows+cols, 2x1 grid size
    Vector2 _levelOffset = new Vector2(-7f, 1.25f);
    Vector2 _brickOffset = new Vector2(2, 1);
    [SerializeField] GameObject _brickPrefab;

    void Awake()
    {
        for (int i = 0; i < _levelSize.x; i++)
        {
            for (int j = 0; j < _levelSize.y; j++)
            {
                GameObject newBrick = Instantiate(_brickPrefab, new Vector3(
                    (i * _brickOffset.x) + _levelOffset.x, 
                    (j * _brickOffset.y) + _levelOffset.y, 
                    0), 
                    _brickPrefab.transform.rotation
                );
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
