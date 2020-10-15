using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public Text timerCounter;
	public float second, minutes;
	public static string timerText;

	// Use this for initialization
	void Start () {
		timerCounter = GetComponent<Text> () as Text;
	}
	
	// Update is called once per frame
	void Update () {
		minutes = (int)(Time.timeSinceLevelLoad / 60f);
		second = (int)(Time.timeSinceLevelLoad % 60f);
		timerText = minutes.ToString ("00") + ":" + second.ToString ("00");
		timerCounter.text = timerText;
	}
}
