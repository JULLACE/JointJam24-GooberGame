using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class toEndScene : MonoBehaviour
{
    public int index;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D other) {
     if(other.CompareTag("Player")) {
        SceneManager.LoadScene(index);
    }
}

}

