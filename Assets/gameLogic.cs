using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class gameLogic : MonoBehaviour
{
    public GameObject l1, l2, l3;
    public ArrayList lives = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        lives.Add(l3);
        lives.Add(l2);
        lives.Add(l1);
    }

    // Update is called once per frame
    public void LoseLife() {
        lives.RemoveAt(1);
        if(lives.Count == 0) {
            print("DEAD");
        }
    }
}
