using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Vector3 astronautDirection;
    [SerializeField] private float astronautSpeed;
    public TextMeshProUGUI scoretext;
    public int score = 0;
    public Animator myAnimator;
    private float addedSpeed=0.5f;
    private int x=50;

    private void Awake()
    {
        astronautDirection = Vector3.zero;
        SetCountText();
        myAnimator = GetComponent<Animator>();
        myAnimator.SetTrigger("Idle");

    }

    private void Update()
    {
        GetAstronautInput();
        SetAstronautMovement();
        
    }

    private void GetAstronautInput()
    {
        if(transform.position.y>= 0.75 && transform.position.y <= 0.79f) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                score++;
                SetCountText();
                ChangeDirectionAstronaut();
                myAnimator.SetTrigger("Running");
            }
        }
        else
        {
            Destroy();
        }

        while (score >= x)
        {
            astronautSpeed += addedSpeed;
            x += 50;
        }
        
    }

    private void ChangeDirectionAstronaut()
    {
        if (astronautDirection.x == -1)
        {
            astronautDirection = Vector3.forward;
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        else
        {
            astronautDirection = Vector3.left;
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
    }

    private void SetAstronautMovement()
    {
        transform.position += astronautDirection * (astronautSpeed * Time.deltaTime);
    }
    private void SetCountText()
    {
        scoretext.text = score.ToString();
    }
    private void Destroy()
    {
        if (transform.position.y == -17f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
        {
            other.gameObject.SetActive(false);
            score += 2;
            SetCountText();
        }
    }

}
