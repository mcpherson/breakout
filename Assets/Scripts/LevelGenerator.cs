using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Vector2Int _levelSize;
    [SerializeField] Vector2 _brickOffset;
    [SerializeField] GameObject _brickPrefab;

    void Awake()
    {
        for (int i = 0; i < _levelSize.x; i++)
        {
            for (int j = 0; j < _levelSize.y; j++)
            {
                GameObject newBrick = Instantiate(_brickPrefab, transform);
                // https://youtu.be/jyXZ3RVe5as?t=1019
                newBrick.transform.position = transform.position + new Vector3((float)((_levelSize.x-1) * 0.5f - i) * _brickOffset.x, j * _brickOffset.y, 0);
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
}
