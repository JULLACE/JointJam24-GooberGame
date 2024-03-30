using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BatAI : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] Transform target;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInSight()) {
            print("I HAVE YOU");
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        // Face the right direction
        if (target.position.x < transform.position.x && transform.localScale.x > 0) {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }
        else if (target.position.x > transform.position.x && transform.localScale.x < 0) {
            transform.localScale = new Vector3(transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }
    }

    private void FollowPlayer() {

    }

    private bool PlayerInSight() {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right
        , boxCollider.bounds.size * range, 0, -Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right, boxCollider.bounds.size * range);
    }
}
