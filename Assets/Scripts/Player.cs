using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float jump = 500.0f;
    [SerializeField] float castDist;
    [SerializeField] float decayRate;

    public enum PlayerState
    {
        Grounded,
        Midair,
        Running
    }

    private PlayerState state;
    private Rigidbody2D rb;
    // IEnumerator jumpRoutine;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb.position += input * speed * Time.deltaTime;
        checkJump();
    }

    // IEnumerator DoJump()
    // {
    //     rb.AddForce(new Vector2(rb.velocity.x, jump));

    //     // Wait 5 frames until processing hold
    //     for (int i = 0; i < 5; i++) yield return null;

    //     float currentForce = jump / 2;
    //     while(Input.GetKey(KeyCode.Space) && currentForce > 0) {
    //         print("Held");
    //         rb.AddForce(Vector2.up * currentForce);
    //         currentForce -= decayRate * Time.deltaTime;
    //         yield return null;
    //     }
    // }


    void checkJump() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - transform.up, -Vector2.up, castDist);
        if (hit) {
            state = PlayerState.Grounded;
        }
        else {
            state = PlayerState.Midair;
        }

        if (Input.GetButtonDown("Jump") && state == PlayerState.Grounded) 
        {
            // if (jumpRoutine != null) StopCoroutine(jumpRoutine);
            // jumpRoutine = DoJump();
            // StartCoroutine(jumpRoutine);
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position - transform.up, transform.position - (-Vector3.up * castDist));
    }

}
