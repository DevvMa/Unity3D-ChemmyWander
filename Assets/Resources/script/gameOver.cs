using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {

	public GameObject gameOverCanvas;
	public GameObject menuPause;
	public GameObject extraLifeCanvas;
	public GameObject playerCanvas;
	public GameObject alScoreCanvas;
	public GameObject UIcanvas;
	public GameObject pauseBtn;
	bool isExtra = false;
	AudioSource audioCam;
	Button soundBtn;
	public GameObject player;
	public CameraFollow camFol;


	void Start(){
		audioCam = GameObject.Find ("Main Camera").GetComponent<AudioSource>();
		soundBtn = GameObject.Find ("sound").GetComponent<Button>();
		if (audioCam.mute) {
			soundBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprites/UI/soundOff") as Sprite;
		} else {
			soundBtn.GetComponent<Image> ().sprite = Resources.Load<Sprite> ("sprites/UI/soundOn") as Sprite;
		}
	}

	public void restartLevel(){
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		PlayerPrefs.SetFloat ("xPos", 0);
		PlayerPrefs.SetFloat ("yPos", 20);
		PlayerPrefs.SetFloat ("zPos", 30);
		//alScoreCanvas.SetActive (false);
	}

	public void playAgain(){
		Time.timeScale = 1f;
		player.SetActive (true);
		gameOverCanvas.SetActive (false);
		player.transform.position = new Vector3(PlayerPrefs.GetFloat("xPos",0),PlayerPrefs.GetFloat("yPos",20),PlayerPrefs.GetFloat("zPos",30));
		camFol.initiateSetCam (player.transform.position.x);
	}

	public void nextLevel(){
		//Debug.Log (SceneManager.GetActiveScene ().buildIndex+1);
		mainScreen.releasedLevel += 1;
		Debug.Log ("Level Unlocked = " +mainScreen.releasedLevel);
		//PlayerPrefs.SetInt ("Level", mainScreen.releasedLevel);
		PlayerData.current.unlockedLevel = mainScreen.releasedLevel;
		Time.timeScale = 1f;
		SceneManager.LoadScene (soal.sceneIndex+1);
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
		//alScoreCanvas.SetActive (false);
	}

	void Update()
	{
		if (SceneManager.GetActiveScene ().buildIndex != 1) {
			if (pleyerHp.currentHealth <= 0 && !isExtra) {
				extraLifeCanvas.SetActive (true);
			}
		}
	}

	public void openPlayer()
	{
		extraLifeCanvas.SetActive (false);
		playerCanvas.SetActive (true);
		isExtra = true;
	}

	public void openScore()
	{
		alScoreCanvas.SetActive (true);	
		UIcanvas.SetActive (false);
		pauseBtn.SetActive (false);
	}

	public void closeScore(){
		alScoreCanvas.SetActive (false);
		UIcanvas.SetActive (true);
		pauseBtn.SetActive (true);
	}

	public void MuteSound(){
		if (audioCam.mute) {
			audioCam.mute = false;
			soundBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprites/UI/soundOn") as Sprite;
		} else {
			audioCam.mute = true;
			soundBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("sprites/UI/soundOff") as Sprite;
		}

	}
		
}
