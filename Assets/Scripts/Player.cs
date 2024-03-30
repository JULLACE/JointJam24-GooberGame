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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb.position += input * speed * Time.deltaTime;
        checkJump();
    }

    void checkJump() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - transform.up, -Vector2.up, castDist);
        if (hit) {
            state = PlayerState.Grounded;
            print("Hit " + hit.distance);
        }
        else {
            state = PlayerState.Midair;
            print("Unhit");
        }

        if (Input.GetButtonDown("Jump") && state == PlayerState.Grounded) 
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position - transform.up * castDist, new Vector2(1, 1));
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if (other.gameObject.CompareTag("Ground")) {
    //         state = PlayerState.Grounded;
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D other) {
    //     if (other.gameObject.CompareTag("Ground")) {
    //         state = PlayerState.Midair;
    //     }
    // }

}
