using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HurtCollision : MonoBehaviour
{

    [SerializeField] float hurtCooldown;
    float hurtTimer = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hurtTimer += Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy") && hurtTimer > hurtCooldown) {
            hurtTimer = 0;
            other.SendMessage("ApplyDamage", 1f);
        }
    }
}
