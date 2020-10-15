using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {

	public Transform spawnPoint;

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			PlayerPrefs.SetFloat ("xPos", transform.position.x);
			PlayerPrefs.SetFloat ("yPos", transform.position.y);
			PlayerPrefs.SetFloat ("zPos", transform.position.z);
			spawnPoint.position = new Vector3(PlayerPrefs.GetFloat("xPos",0),PlayerPrefs.GetFloat("yPos",0),PlayerPrefs.GetFloat("zPos",0));
		}
	}
}
