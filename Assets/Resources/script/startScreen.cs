using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class startScreen : MonoBehaviour {
	
	public InputField inputFieldNama;
	private string Nama="";
	public GameObject loadingScreen;
	public GameObject welcomeScreen;
	public GameObject newGameScreen;
	public GameObject loadGameScreen;
	public Slider loadingBar;
	public Text playerName;

	void Start(){
		inputFieldNama = inputFieldNama.GetComponent<InputField> ();
		PlayerPrefs.DeleteAll ();
	}
		
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Return)){
			if (inputFieldNama.text != "") {
				Nama = inputFieldNama.text.ToUpper();
				//PlayerPrefs.SetString ("Nama",Nama);
				PlayerData.current = new PlayerData ();
				PlayerData.current.NamaPemain = Nama;
				StartCoroutine (LoadAsync (1));	
			}
		}
	}
		
	IEnumerator LoadAsync(int sceneIndex){
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);
		loadingScreen.SetActive (true);
		playerName.text = "SELAMAT DATANG, " + PlayerData.current.NamaPemain + " PETUALANGAN AKAN DATANG PERSIAPKAN DIRIMU";
		welcomeScreen.SetActive (false);
		newGameScreen.SetActive (false);
		loadGameScreen.SetActive (false);
		while (!operation.isDone){
			float progress = Mathf.Clamp01 (operation.progress/ .9f);
			Debug.Log (operation.progress);
			loadingBar.value = progress;
			yield return null;
		}
	}

	public void QuitGame(){
		Application.Quit ();
	}
		
	public void loadGame()
	{
		saveLoad.Load ();
	}

	public void loadGameAsync(){
		StartCoroutine (LoadAsync (1));
	}
		
}
