using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour {

	public Transform spawnPoint;
	public GameObject player;
	public CameraFollow camFol;

	void Start(){
//		if (!PlayerPrefs.HasKey ("xPos") && !PlayerPrefs.HasKey ("yPos") && !PlayerPrefs.HasKey ("zPos")) {
			PlayerPrefs.SetFloat ("xPos", 0);
			PlayerPrefs.SetFloat ("yPos", 20);
			PlayerPrefs.SetFloat ("zPos", 30);
//		}
		player.transform.position = new Vector3(PlayerPrefs.GetFloat("xPos",0),PlayerPrefs.GetFloat("yPos",0),PlayerPrefs.GetFloat("zPos",0));
		camFol.initiateSetCam (player.transform.position.x);
	}

	/*void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			player.transform.position = spawnPoint.position;
		}
	}*/
}
