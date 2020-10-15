using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class mainScreen : MonoBehaviour {

	public Text playerName;
	public Text loadingText;
	public GameObject[] levelSelector;
	public GameObject[] materi;
	public GameObject loadingScreen;
	public GameObject levelScreen;
	public Slider loadingBar;
	public static int releasedLevel;


	// Use this for initialization
	void Start () {
		releasedLevel = PlayerData.current.unlockedLevel;
		Debug.Log ("Ms Level Unlocked = "+releasedLevel);
		levelSelector = GameObject.FindGameObjectsWithTag ("levelBottle");
		//materi = GameObject.FindGameObjectsWithTag ("materi");
		playerName.text = PlayerData.current.NamaPemain;
		deactivateMateri ();

	}
	
	public void onSelectLevel1(){
		StartCoroutine ( LoadAsync (2));
		//SceneManager.LoadScene(2);
	}

	public void onSelectLevel2(){
		//SceneManager.LoadScene (3);
		StartCoroutine ( LoadAsync (3));
	}

	public void onSelectLevel3(){
		StartCoroutine ( LoadAsync (4));
		//SceneManager.LoadScene (4);
	}
		
	public IEnumerator LoadAsync(int sceneIndex){
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);
		loadingScreen.SetActive (true);
		loadingText.text = "SELAMAT DATANG, " + PlayerData.current.NamaPemain + " PETUALANGAN AKAN DATANG PERSIAPKAN DIRIMU";
		levelScreen.SetActive (false);
		while (!operation.isDone){
			float progress = Mathf.Clamp01 (operation.progress/ .9f);
			Debug.Log (operation.progress);
			loadingBar.value = progress;
			yield return null;
		}
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void deactivateMateri(){
		foreach (GameObject panelMateri in materi) {
			panelMateri.SetActive (false);
		}
	}

	public void saveGame(){
		saveLoad.Save ();
	}
}
