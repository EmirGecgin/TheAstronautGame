using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform astronautTransform;
    [SerializeField] private GameObject astronaout;
    private Vector3 _offset;
    [SerializeField] private float lerpValue;
    private Vector3 _newCameraPosition;

    private void Awake()
    {
        _offset = transform.position - astronautTransform.position;
    }
    private void LateUpdate()
    {
        if (astronaout.transform.position.y<=1.5f && astronaout.transform.position.y>= 0) 
        {
            _newCameraPosition = Vector3.Lerp(transform.position, astronautTransform.position + _offset,
            lerpValue * Time.deltaTime);
            transform.position = _newCameraPosition;
        }
        else
        {
            transform.position = _newCameraPosition;
        }
    }
}
