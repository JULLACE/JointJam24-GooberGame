using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightDirection : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
		//mousePos.z = 5.23f;

		Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		mousePos.x = mousePos.x - objectPos.x;
		mousePos.y = mousePos.y - objectPos.y;

		float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(-angle, 90, 90));
    }
}
