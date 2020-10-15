using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class materiPlayer : MonoBehaviour {

	public MovieTexture movie;
	private AudioSource audio;
	public Text btnPlayPause;
	public GameObject videoPlayer;

	// Use this for initialization
	void Start () {
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

	public void openPlayer()
	{
		videoPlayer.SetActive (true);
	}

	public void closePlayer()
	{
		videoPlayer.SetActive (false);
	}
}
