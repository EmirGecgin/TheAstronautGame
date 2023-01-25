using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorController : MonoBehaviour
{
    [SerializeField] private Material groundMaterial;
    [SerializeField] private Color[] colors;
    private int _index;
    [SerializeField] private float lerpValue;
    public PlayerController _playerController;
    private int x = 50; 

    private void Awake()
    {
        _index = 0;
        
    }

    private void Update()
    {
        SetColor();
        SetGroundColorChange();
    }

    private void SetColor()
    {
        while (_playerController.score >= x)
        {
            CheckIndexValue();
            x += 50;
        }
    }

    private void CheckIndexValue()
    {
        _index++;
        if (_index >= colors.Length)
        {
            _index = 0;
        }
    }

    private void SetGroundColorChange()
    {
        groundMaterial.color = Color.Lerp(groundMaterial.color, colors[_index], lerpValue * Time.deltaTime);
    }

    private void OnDestroy()
    {
        groundMaterial.color = colors[0];
    }
}
