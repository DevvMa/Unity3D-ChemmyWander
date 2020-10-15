using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jawabanB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown(){

		soal.jawabanterpilih = gameObject.name;
		soal.sudahMemilih = true;

	}
}
