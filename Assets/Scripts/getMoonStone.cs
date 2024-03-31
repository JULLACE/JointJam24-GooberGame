using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getMoonStone : MonoBehaviour
{
    public GameObject flower;
    public GameObject aura;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            print("GOT STONE");
            flower.gameObject.SetActive(false);
            aura.gameObject.SetActive(false);
        }

        lifeManager.health = 6;
        lifeManager.moons++;
        gameObject.SetActive(false);
    }
}
