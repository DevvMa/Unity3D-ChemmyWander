using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	string indexBotol;
	public static int idxbotol;
	public static GameObject botol;
	public static int countBubble;
	public AudioClip poinSound;
	public CameraFollow camFol;

	AudioSource playerAS;

	//Movement Speed
	public float maxSpeed;

	Rigidbody2D myRB;
	bool facingRight;

	//JumpVariable
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	//Player Animation
	Animator myAnim;

	// Use this for initialization
	void Start () {
		countBubble = 0;
		myRB = GetComponent<Rigidbody2D> ();	
		facingRight = true;
		myAnim = GetComponent<Animator>();
		playerAS = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void update(){

	}
		
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		if (grounded && Input.GetAxis("Jump")>0) {
			grounded = false;
			myAnim.SetBool ("isGrounded", grounded);
			myRB.AddForce( new Vector2 (0, jumpHeight));
		}		 

		myAnim.SetBool ("isGrounded", grounded);
		myAnim.SetFloat ("verticalSpeed", myRB.velocity.y);


		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));
		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);


		if (move > 0 && !facingRight) {

			flip ();
		} else if(move<0 && facingRight) {

			flip ();
		}
	}

	void flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D (Collider2D other){
		
		if (other.tag == "gelasKimia") {
			
			indexBotol = other.name;
			indexBotol = indexBotol.Substring (indexBotol.Length - 1);
			idxbotol = int.Parse (indexBotol) - 1;
			Debug.Log (indexBotol);
			botol = other.gameObject;
			//Debug.Log (soal.panelSoal[soal.setSoal[idxbotol]].gameObject.activeInHierarchy);
			if (soal.panelSoal [soal.setSoal [idxbotol]].gameObject.activeInHierarchy == false) {
				soal.panelSoal [soal.setSoal [idxbotol]].gameObject.SetActive (true); 
				Time.timeScale = 0f;

			}
		} 
		if (other.tag == "bubblemin") {
			
			playerScore theScore = gameObject.GetComponent<playerScore> ();
			theScore.remScore (10);
			Destroy (other.gameObject);
		} 
		if (other.tag == "bubbleplus") {
			playerAS.PlayOneShot (poinSound);	
			playerScore theScore = gameObject.GetComponent<playerScore> ();
			theScore.addScore (10);
			countBubble++;
			Destroy (other.gameObject);
		}
		 if(other.name == "8e"){
			if (soal.countSoalTerjawab != soal.gelasKimia.Length) {
				other.isTrigger = false;
			}
			// Calculate Angle Between the collision point and the player
			//Vector2 dir = new Vector2 (transform.position.x - other.transform.position.x ,transform.position.y - other.transform.position.y);
			// We then get the opposite (-Vector3) and normalize it
			// dir = -dir.normalized;
			// And finally we add force in the direction of dir and multiply it by force. 
			// This will push back the player
			//GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			//GetComponent<Rigidbody2D>().AddForce(-dir*10,ForceMode2D.Impulse);
		}

		if (other.tag == "jurang") {
			pleyerHp.currentHealth -= 1;
			gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("xPos",0),PlayerPrefs.GetFloat("yPos",0),PlayerPrefs.GetFloat("zPos",0));
			camFol.initiateSetCam (gameObject.transform.position.x);
		}
	}
}
