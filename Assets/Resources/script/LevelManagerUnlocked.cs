using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManagerUnlocked : MonoBehaviour {
	public int Level;
	public Image Image;

	void Start () {
		if (mainScreen.releasedLevel >= Level) {
			Levelunlocked ();
		} else {
			Levellocked ();
		}
	}

	void Levellocked()
	{
		GetComponent<Button> ().interactable = false;
		Image.enabled = true;
	}
	void Levelunlocked ()
	{
		GetComponent<Button> ().interactable = true;
		Image.enabled = false;
	}

}
