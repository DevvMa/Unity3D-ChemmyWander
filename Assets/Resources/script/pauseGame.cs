using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour {

	public GameObject menuPause;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPause(){
		Time.timeScale = 0f;
		menuPause.SetActive (true);
	}

	public void resume(){
		Time.timeScale = 1f;
		menuPause.SetActive (false);
	}

	public void exit(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (1);
	}
}
