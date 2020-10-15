using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pleyerHp : MonoBehaviour {

	public int playerFullHealth = 3;
	public Text hpText;
	public GameObject gameOverCanvas;
	public Image damageScreen;
	public AudioClip hurtClip;

	public static int currentHealth;
	Color damagedColor = new Color(0f,0f,0f,0.5f);
	bool isDamage = false;
	float smoothColor = 5f;

	AudioSource playerAS;

	// Use this for initialization
	void Start () {
		currentHealth = playerFullHealth;
		isDamage = false;
		playerAS = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (isDamage);
		hpText.text = "x " + currentHealth;
		if (isDamage) {
			playerAS.clip = hurtClip;
			playerAS.Play ();
			damageScreen.color = damagedColor;
		} else {
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
		}

		if (currentHealth <= 0) {
			makeDead ();
		}

		if (currentHealth > playerFullHealth) {
			currentHealth = playerFullHealth;
		}
		isDamage = false;
	}

	public void addDamage(int damage){
		if (damage <= 0) {
			return;
		}
		
		currentHealth -= damage;
		isDamage = true;
	}

	public void makeDead(){
		gameObject.SetActive(false);
		gameOverCanvas.SetActive (true);
		Time.timeScale = 0f;
	}
		
		
}
