using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateConroller : MonoBehaviour
{
    [SerializeField] private Transform astronautTransform;
    private Vector3 _offset;
    [SerializeField] private float lerpValue;
    private Vector3 _newPlanetPosition;

    private void Awake()
    {
        _offset = transform.position - astronautTransform.position;
    }

    private void LateUpdate()
    {
        _newPlanetPosition = Vector3.Lerp(transform.position, astronautTransform.position + _offset,
        lerpValue * Time.deltaTime);
        transform.position = _newPlanetPosition;
    }

}
