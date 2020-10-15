using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScore : MonoBehaviour {

	public Text[] fieldgelembung;
	public Text[] fieldSoal;
	public Text[] fieldTotalScore;
	public Text[] fieldDurasi;
	public Text heading;

	void Start () {
		heading.text = "SELAMAT "+PlayerData.current.NamaPemain;	
		setValue ();
	}

	void setValue () {
		for (int i = 0; i < 3; i++) 
		{
			//for (int n = 0; n < 3; n++) 
			//{
				fieldgelembung [i].text = "= " + PlayerData.current.stats [i, 0].ToString();
				fieldSoal[i].text = "= " + PlayerData.current.stats [i, 1].ToString();
				fieldTotalScore[i].text = PlayerData.current.stats [i, 2].ToString();
			//}
			fieldDurasi [i].text = "= " + PlayerData.current.durasiMain[i];
		}
	}
}
