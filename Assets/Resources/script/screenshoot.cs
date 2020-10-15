using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class screenshoot : MonoBehaviour {

	Texture2D screenCap;
	//Texture2D border;
    public Canvas allScoreCanvas;

	//bool shot = false;

	// Use this for initialization
	void Start () {
		screenCap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false); // 1
		//border = new Texture2D(2, 2, TextureFormat.ARGB32, false); // 2
		//border.Apply();
	}
		
	// Update is called once per frame
	void Update () {
        if (allScoreCanvas.isActiveAndEnabled) { 
		    if(Input.GetKeyUp(KeyCode.S)){ // 3
			    StartCoroutine("Capture");
			    //Capture();
		    }
            if (Input.GetKeyUp(KeyCode.Escape))
            { // 3
                Time.timeScale = 1f;
                SceneManager.LoadScene(1);
                //Capture();
            }
        }
	}
		
	void OnGUI(){
		/*
		GUI.DrawTexture(new Rect(0, 0,Screen.width,2 ), border, ScaleMode.StretchToFill); // top
		GUI.DrawTexture(new Rect(0, Screen.height, Screen.width, 2), border, ScaleMode.StretchToFill); // bottom
		GUI.DrawTexture(new Rect(0, 0, 2, Screen.height), border, ScaleMode.StretchToFill); // left
		GUI.DrawTexture(new Rect(Screen.width, 0 , 2, Screen.height), border, ScaleMode.StretchToFill); // right
		*/

	}
	
	IEnumerator Capture(){
		yield return new WaitForEndOfFrame();
		screenCap.ReadPixels (new Rect (0, 0, Screen.width, Screen.height), 0, 0);
		screenCap.Apply();

		// Encode texture into PNG
		byte[] bytes = screenCap.EncodeToPNG();
		//Object.Destroy(screenCap);

		if(!Directory.Exists(Application.dataPath+"/sertifikat")){
			Directory.CreateDirectory (Application.dataPath + "/sertifikat");
		}

		// For testing purposes, also write to a file in the project folder
		File.WriteAllBytes(Application.dataPath + "/sertifikat/SavedScreen.png", bytes);


		//shot = true;
	}

}
