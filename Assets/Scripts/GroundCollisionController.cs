using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundCollisionController : MonoBehaviour
{
    private Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private IEnumerator SetRigidbodyValues()
    {
        yield return new WaitForSeconds(0.75f);
        _rb.isKinematic = false;
        _rb.useGravity = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Astronaut"))
        {

            StartCoroutine(SetRigidbodyValues());
        }
    }
    
}
