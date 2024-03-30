using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBackground : MonoBehaviour {
	private float _startingPos; //This is starting position of the sprites.
	private float _lengthOfSprite;    //This is the length of the sprites.
	public float amountOfParallax;  //This is amount of parallax scroll. 
	public Camera mainCamera;   //Reference of the camera.

	void Start() {
		_startingPos = transform.position.x;
		_lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
		mainCamera = Camera.main;
	}

	void Update() {
		Vector3 pos = mainCamera.transform.position;
		float temp = pos.x * (1 - amountOfParallax);
		float dis = pos.x * amountOfParallax;

		transform.position = new Vector3(_startingPos + dis, transform.position.y, transform.position.z);

		if (temp > _startingPos + _lengthOfSprite)
		{
			_startingPos += _lengthOfSprite;
		}
		else if (temp < _startingPos - _lengthOfSprite)
		{
			_startingPos -= _lengthOfSprite;
		}
	}
}
