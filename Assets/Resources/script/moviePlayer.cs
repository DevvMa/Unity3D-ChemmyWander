using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]

public class moviePlayer : MonoBehaviour {


	public MovieTexture movie;
	private AudioSource audio;
	public Text btnPlayPause;
	public GameObject videoPlayer;

	// Use this for initialization
	void Start () {
		/*
		#if UNITY_ANDROID
		Handheld.PlayFullScreenMovie("StarWars.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
		#else
		public MovieTexture movie;
		#endif
		*/
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		audio = GetComponent<AudioSource> ();
		audio.clip = movie.audioClip;
		movie.loop = true;
	}

	public void PlayPause()
	{
		if (movie.isPlaying) 
		{
			movie.Pause ();
			audio.Pause ();
			btnPlayPause.text = "Play";
		} else 
		{
			movie.Play ();
			audio.Play ();
			btnPlayPause.text = "Pause";
		}
	}

	public void closePlayer()
	{
		//Time.timeScale = 1f;
		videoPlayer.SetActive (false);
		pleyerHp.currentHealth += 1;
		//gameOverCanvas.SetActive (false);
		//player.transform.position = new Vector3(PlayerPrefs.GetFloat("xPos",0),PlayerPrefs.GetFloat("yPos",0),PlayerPrefs.GetFloat("zPos",0));
		//camFol.initiateSetCam (player.transform.position.x);

	}
}
