using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroundSpawner : MonoBehaviour
{
    public GameObject lastGroundObject;
    [SerializeField] private GameObject groundPrefab;
    private GameObject _newGroundObject;
    private int _groundDirection;

    private int _pickUpDirection;

    private void Awake()
    {
        GenerateNewGround();
    }

    public void GenerateNewGround()
    {
        for (int i = 0; i < 75; i++)
        {
            CreateNewGround();
        }
    }

    private void CreateNewGround()
    {
        _groundDirection = Random.Range(0, 2);
        _pickUpDirection = Random.Range(0, 11);

        if (_groundDirection == 0)
        {
            Vector3 position = lastGroundObject.transform.position;
            _newGroundObject = Instantiate(groundPrefab, new Vector3(position.x - 1.25f, position.y, position.z),
                Quaternion.identity);
            lastGroundObject = _newGroundObject;


        }
        else
        {
            Vector3 position = lastGroundObject.transform.position;
            _newGroundObject = Instantiate(groundPrefab, new Vector3(position.x, position.y, position.z + 1.25f),
                Quaternion.identity);
            lastGroundObject = _newGroundObject;
        }

        if (_pickUpDirection == 2)
        {
            lastGroundObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    
  
}
