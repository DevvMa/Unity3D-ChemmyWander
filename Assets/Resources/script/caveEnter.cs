using UnityEngine;
using UnityEngine.UI;

public class caveEnter : MonoBehaviour {
	public GameObject gameWinCanvas;
	public Text winText;
	public Text bubleCount;
	public Text soalCount ;
	public Text totalScore ;
	public Text durasi;
	bool isGameOver;
	void Start(){
		isGameOver = false;
	}
	void OnTriggerEnter2D (Collider2D other){
		if (soal.countSoalTerjawab == soal.gelasKimia.Length && !isGameOver && other.tag == "Player") {
			gameWinCanvas.SetActive (true);
			Time.timeScale = 0f;
			winText.text = "CONGRATULATION " + PlayerPrefs.GetString ("Nama", "");
			bubleCount.text = "= " + PlayerController.countBubble;
			soalCount.text = "= " + soal.countSoalTerjawab;
			totalScore.text = "= " + playerScore.currentScore;
			durasi.text = "= " + timer.timerText;
			isGameOver = true;
			PlayerPrefs.SetFloat ("xPos", 0);
			PlayerPrefs.SetFloat ("yPos", 20);
			PlayerPrefs.SetFloat ("zPos", 30);
			if (soal.sceneIndex == 2) {
				PlayerData.current.stats [0, 0] = PlayerController.countBubble;
				PlayerData.current.stats [0, 1] = soal.countSoalTerjawab;
				PlayerData.current.stats [0, 2] = playerScore.currentScore;
				PlayerData.current.durasiMain [0] = timer.timerText;
			} else if (soal.sceneIndex == 3) {
				PlayerData.current.stats [1, 0] = PlayerController.countBubble;
				PlayerData.current.stats [1, 1] = soal.countSoalTerjawab;
				PlayerData.current.stats [1, 2] = playerScore.currentScore;
				PlayerData.current.durasiMain [1] = timer.timerText;
			} else if (soal.sceneIndex == 4) {
				PlayerData.current.stats [2, 0] = PlayerController.countBubble;
				PlayerData.current.stats [2, 1] = soal.countSoalTerjawab;
				PlayerData.current.stats [2, 2] = playerScore.currentScore;
				PlayerData.current.durasiMain [2] = timer.timerText;
			}
		} 
		/*if (other.tag == "Player" && soal.countSoalTerjawab != soal.gelasKimia.Length){
			pushBack (other.transform);
		}*/
	}

	/*void pushBack (Transform pushedObject){
		Vector2 pushDirection = new Vector2 ((pushedObject.position.x - transform.position.x), (pushedObject.position.y - transform.position.y)).normalized;
		pushDirection *= 30;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}*/


}
