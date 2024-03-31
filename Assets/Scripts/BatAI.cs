using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class BatAI : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Transform target;
    [SerializeField] LayerMask playerLayer;

    [SerializeField] float maxHealth;
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] float dashPower;
    [SerializeField] float attackCooldown;
    [SerializeField] float chaseCooldown;


    float cooldownTimer = Mathf.Infinity; 
    float chaseTimer = Mathf.Infinity;
    float diff;
    float currHealth;

    Animator animator;
    IEnumerator dashRoutine;
    Rigidbody2D rb;

    void Awake() {
        animator = GetComponent<Animator>();
        currHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        cooldownTimer += Time.deltaTime;
        chaseTimer += Time.deltaTime;

        if (currHealth <= 0) {
            animator.SetTrigger("death");
            rb.gravityScale = 1f;
        }
        else {
            BehaviorController();
            DirectionCheck();
        }
    }

    void BehaviorController() {
        diff = Mathf.Abs((transform.position - target.position).magnitude);
        if (PlayerInSight() && diff > 1f) {
            chaseTimer = 0;
            print("I HAVE YOU");
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (PlayerInSight() && diff < 1f) {
            if (cooldownTimer >= attackCooldown) {
                chaseTimer = 0;
                cooldownTimer = 0;
                animator.SetTrigger("attackAnim");
                transform.position = Vector3.MoveTowards(transform.position, target.position, dashPower * Time.deltaTime);
            }
        }
        else if (!PlayerInSight()) {
            if (chaseTimer < chaseCooldown) {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }
    
    void DirectionCheck() {
        if (target.position.x < transform.position.x && transform.localScale.x > 0) {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }
        else if (target.position.x > transform.position.x && transform.localScale.x < 0) {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }
    }

    bool PlayerInSight() {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + (transform.right * transform.localScale.normalized.x)
        , boxCollider.bounds.size * range, 0, -Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + (transform.right * transform.localScale.normalized.x), boxCollider.bounds.size * range);
    }

    void DamagePlayer() {
        if (diff <= 1f) {
            lifeManager.health--;
            print("HIT");
        }
    }

    void ApplyDamage(float amt) {
        print("I have been hurt.");
        animator.SetTrigger("hurtAnim");
        currHealth -= amt;
    }
}
