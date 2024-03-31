using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class CameraFollow : MonoBehaviour
{

    [SerializeField] bool lockY;

    public float FollowSpeed = 2f;
    public Transform target;

    void Update()
    {
        float yValue = transform.position.y;
        if (!lockY) yValue = target.position.y;

        Vector3 newPos = new Vector3(target.position.x, yValue, -10f);
        transform.position = Vector3.Lerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}