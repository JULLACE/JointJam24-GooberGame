using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lifeManager : MonoBehaviour
{
    public GameObject gameOver, l1, l2, l3;
    public static int health = 3;
    public static int moons = 0;
    public Text moonText;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 6;
        gameOver.gameObject.SetActive(false);
        l1.gameObject.SetActive(true);
        l2.gameObject.SetActive(true);
        l3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        print(health/2);
        switch (health/2) {
            case 3:
                gameOver.gameObject.SetActive(false);
                l1.gameObject.SetActive(true);
                l2.gameObject.SetActive(true);
                l3.gameObject.SetActive(true);
                break;
            case 2:
                gameOver.gameObject.SetActive(false);
                l1.gameObject.SetActive(true);
                l2.gameObject.SetActive(true);
                l3.gameObject.SetActive(false);
                break;
            case 1:
                gameOver.gameObject.SetActive(false);
                l1.gameObject.SetActive(true);
                l2.gameObject.SetActive(false);
                l3.gameObject.SetActive(false);
                break;

            default:
                gameOver.gameObject.SetActive(true);
                l1.gameObject.SetActive(false);
                l2.gameObject.SetActive(false);
                l3.gameObject.SetActive(false);
                break;
        }
        print("Moons: " + moons.ToString());
        moonText.text = "x" + moons.ToString();
    }
}
