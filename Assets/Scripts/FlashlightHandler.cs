using UnityEngine;

public class FlashlightHandler : MonoBehaviour
{

    [SerializeField] float hurtCooldown;
    float hurtTimer = Mathf.Infinity;

    // Layout:
    // As character walks: battery goes down
    // Character stays still, it goes back up.

    [SerializeField] Light m_Light;
    [SerializeField] float drainRate;
    [SerializeField] float rechargeRate;
    float maxBrightness;
    Vector2 prevPosition;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        prevPosition = player.position;
        maxBrightness = m_Light.intensity;
    }

    void Update()
    {   
        m_Light.intensity = Mathf.Clamp(m_Light.intensity, 0, maxBrightness);
        if (m_Light.intensity > 0 && hasMoved()) {
            m_Light.intensity -= Time.deltaTime * drainRate;
        }
        else if (!hasMoved()) {
            m_Light.intensity += Time.deltaTime * rechargeRate;
        }

        hurtTimer += Time.deltaTime;
        prevPosition = player.position;
    }

    bool hasMoved() {
        return Vector2.Distance(player.position, prevPosition) > .05f;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Enemy") && hurtTimer > hurtCooldown && m_Light.intensity > 5f) {
            hurtTimer = 0;
            other.SendMessage("ApplyDamage", 1f);
        }
    }
}
