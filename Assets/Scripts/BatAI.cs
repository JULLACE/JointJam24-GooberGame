using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class BatAI : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] Transform target;
    [SerializeField] float dashPower;
    [SerializeField] float dashCooldown;

    [SerializeField] Animator animator;

    IEnumerator dashRoutine;

    void Update()
    {   
        float diff = Mathf.Abs(transform.position.magnitude - target.position.magnitude);
        if (PlayerInSight() && diff > 1.5f) {
            animator.SetFloat("attackFloat", 1f);
            print("I HAVE YOU");
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else if (PlayerInSight() && (diff > .7f && diff < 1f)) {
            animator.SetFloat("attackFloat", -1f);
            transform.position = Vector3.MoveTowards(transform.position, target.position, dashPower * Time.deltaTime);
        }

        DirectionCheck();
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
}
