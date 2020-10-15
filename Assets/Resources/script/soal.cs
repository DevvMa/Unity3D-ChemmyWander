using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class soal : MonoBehaviour {

	//List<Image> pertanyaan = new List<Image>();
	List<string> jawabanBenar = new List<string>(){"B","D","C","B","C","E","C","C","C","B","A","A","B","A","D"};
	public GameObject[] reviewSoal;
	public static string jawabanterpilih;
	public static bool sudahMemilih = false;
	public GameObject dialogBenar;
	public GameObject dialogSalah;
	public static GameObject[] panelSoal;
	public static GameObject[] gelasKimia;
	public static int[] setSoal; // Menyimpan soal dalam gelas
	int [] setReview ;
	public static int randSoal ;
	private bool[] ceksoalSama ;
	public static int countSoalTerjawab;
	GameObject[] indikatorSoal;
	int ansIdxScene;

	public static int sceneIndex;


	void Start(){
		randSoal = -1;
		countSoalTerjawab = 0;
		inisialisasiIndikator ();
		inisalisasiArray ();
		randPanel ();
		disablePanelSoal ();
		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		if (sceneIndex == 2) {
			ansIdxScene = 0;
			setReview = new int[]{ 1, 2, 2, 0, 0 };
		} else if (sceneIndex == 3) {
			ansIdxScene = 5;
			setReview = new int[]{ 0, 0, 0, 1, 1 };
		} else if (sceneIndex == 4) {
			ansIdxScene = 10;
			setReview = new int[]{ 0, 1, 2, 0, 2 };
		}

	}

	void inisialisasiIndikator(){
		indikatorSoal = GameObject.FindGameObjectsWithTag ("indikatorSoal");
		for (int i = 0; i < indikatorSoal.Length;i++) {
			Debug.Log (indikatorSoal [i].name);
		}
	}

	void inisalisasiArray(){
		gelasKimia = GameObject.FindGameObjectsWithTag ("gelasKimia");
		panelSoal = GameObject.FindGameObjectsWithTag ("panelSoal");
		setSoal= new int[gelasKimia.Length];
		ceksoalSama = new bool[gelasKimia.Length];
		for (int i = 0; i < gelasKimia.Length;i++) {
			setSoal [i] = 0;
			ceksoalSama [i] = true;
			Debug.Log (panelSoal [i]);
		}

	}

	void randPanel (){
		for (int i = 0; i < gelasKimia.Length;) {
			if (setSoal [i] == 0) {
				if (SceneManager.GetActiveScene ().buildIndex == 2) {
					randSoal = Random.Range (0, 5);
				} else if (SceneManager.GetActiveScene ().buildIndex == 3) {
					randSoal = Random.Range (5, 10);
					randSoal = randSoal - 5;
				} else if (SceneManager.GetActiveScene ().buildIndex == 4) {
					randSoal = Random.Range (10, 15);
					randSoal = randSoal - 10;
				}
				//Debug.Log ("random " + randSoal);
				//Debug.Log (ceksoal [randSoal]);
				if (ceksoalSama [randSoal]) {
					setSoal [i] = randSoal;
					ceksoalSama [randSoal] = false;
					Debug.Log ("iterasi ke" + i);
					Debug.Log (setSoal [i]);
					i++;
				}
			}
		}


	}
	void disablePanelSoal(){

		for (int i = 0; i < panelSoal.Length; i++) { 
			panelSoal [i].gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (sudahMemilih == true) {
			sudahMemilih = false;
			if (jawabanterpilih == jawabanBenar [setSoal [PlayerController.idxbotol]+ ansIdxScene]) {
				panelSoal [setSoal [PlayerController.idxbotol]].gameObject.SetActive (false);
				StartCoroutine (tunggu (dialogBenar));
				Time.timeScale = 1f;
				pleyerHp.currentHealth += 1;
				playerScore score = GameObject.Find ("PLAYER").GetComponent<playerScore> ();
				score.addScore (20);
				countSoalTerjawab++;
				Destroy (PlayerController.botol);
			} else {
				panelSoal [setSoal [PlayerController.idxbotol]].gameObject.SetActive (false);
				//StartCoroutine (tunggu (dialogSalah));
				pleyerHp.currentHealth--;
				if (pleyerHp.currentHealth > 0) {
					dialogSalah.SetActive (true);
				}
				//Time.timeScale = 0f;
			}
		}
		if (countSoalTerjawab > 0) {
			indikatorSoal [countSoalTerjawab - 1].SetActive (false);
		}
	}

	IEnumerator tunggu(GameObject dialogPanel){
		dialogPanel.SetActive (true);
		yield return new WaitForSeconds(2);
		dialogPanel.SetActive (false);
	}

	public void closePanel(){	
		dialogSalah.SetActive (false);
		Time.timeScale = 1f;
	}

	public void openReview(){
		//Debug.Log (setSoal [PlayerController.idxbotol]);
		//Debug.Log (setReview [setSoal [PlayerController.idxbotol]]);
		//Debug.Log (reviewSoal [setReview [setSoal [PlayerController.idxbotol]]]);
		reviewSoal [setReview [setSoal [PlayerController.idxbotol]]].SetActive(true);
	}

	public void closeReview(){
		reviewSoal [setReview [setSoal [PlayerController.idxbotol]]].SetActive (false);
	}
}
