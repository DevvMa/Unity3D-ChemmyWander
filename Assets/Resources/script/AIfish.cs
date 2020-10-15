using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIfish : MonoBehaviour {

	public float speed;
	float interval = 3f;
	float nextFlipChange= 0f;
	bool faceRight = false;

	void Update(){
		if (Time.time > nextFlipChange) {
			if(Random.Range(0,10)>= 5){
				flipIkan ();
				nextFlipChange = Time.time + interval;
			}
		}

		if (!faceRight) {
			transform.Translate (-speed * Time.deltaTime, 0, 0);
		} else {
			transform.Translate (speed * Time.deltaTime, 0, 0);
		}
	}

	// Update is called once per frame
	/*void FixedUpdate () {
		if ((int)(Time.time % 60f) % interval == 0) {
			flipIkan ();
		}
	}*/

	void flipIkan(){
		float posisiIkanX = transform.localScale.x;
		posisiIkanX *= -1f;
		transform.localScale = new Vector3 (posisiIkanX,transform.localScale.y,transform.localScale.z);
		faceRight = !faceRight;
	}
}
