using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing;
	public float maxScreen;

	Vector3 offset;

	float lowY;


	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
		lowY = transform.position.y;
	}

	public void initiateSetCam(float playerPos){
		transform.position = new Vector3(playerPos,0,0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target.transform.position.x > 0 && target.transform.position.x < maxScreen) {
			moveCam ();	
		}
	}

	void moveCam(){
		Vector3 targetCamPos = target.position + offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing*Time.deltaTime);
		if (transform.position.y < lowY || transform.position.y > lowY) {
			transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
		}
	}

}
