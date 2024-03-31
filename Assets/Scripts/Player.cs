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

    public enum PlayerState
    {
        Grounded,
        Midair,
        Running
    }

    private PlayerState state;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // DA ARTIST WROTE THIS :D
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        // I ALSO WROTE THIS ONE :D
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb.position += input * speed * Time.deltaTime;
        checkJump();
    }

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
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position - transform.up, (transform.position - transform.up) + (-Vector3.up * castDist));
    }

}
