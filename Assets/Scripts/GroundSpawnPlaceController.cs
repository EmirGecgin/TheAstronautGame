using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawnPlaceController : MonoBehaviour
{
    private GroundSpawner _groundSpawner;
    private Rigidbody _rb;
    [SerializeField] private float endYValue;
    private int _groundDirection;
    private int _pickUpDirection;
    void Start()
    {
        _groundSpawner = FindObjectOfType<GroundSpawner>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGroundVerticalPos();
    }

    private void CheckGroundVerticalPos()
    {
        if (transform.position.y <= endYValue)
        {

            SetRigidBodyValues();
            SetGroundNewPos();

        }
    }

    private void SetGroundNewPos()
    {
        _groundDirection = Random.Range(0, 2);
        _pickUpDirection = Random.Range(0, 11);

        if (_groundDirection == 0)
        {
            var position = _groundSpawner.lastGroundObject.transform.position;
            transform.position = new Vector3(position.x - 1.25f, position.y, position.z);

        }
        else
        {
            var position = _groundSpawner.lastGroundObject.transform.position;
            transform.position = new Vector3(position.x, position.y, position.z + 1.25f);

        }

        _groundSpawner.lastGroundObject = gameObject;
        if (_pickUpDirection == 2)
        {
            _groundSpawner.lastGroundObject.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    private void SetRigidBodyValues()
    {
        _rb.isKinematic = true;
        _rb.useGravity = false;
    }




}
