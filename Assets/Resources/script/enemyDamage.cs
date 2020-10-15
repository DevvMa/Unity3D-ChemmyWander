using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

	int damage = 1;
	float damageRate = 0.5f;
	float pushBackForce = 15;

	float nextDamage;
	// Use this for initialization
	void Start () {
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Player" && nextDamage < Time.time) {
			pleyerHp TheHp = other.gameObject.GetComponent<pleyerHp> ();
			TheHp.addDamage (damage);
			nextDamage = Time.time + damageRate;
			playerScore score = GameObject.Find ("PLAYER").GetComponent<playerScore> ();
			//score.remScore (3);
			pushBack (other.transform);
		}
	}

	void pushBack (Transform pushedObject){
		Vector2 pushDirection = new Vector2 ((pushedObject.position.x - transform.position.x), (pushedObject.position.y - transform.position.y)).normalized;
		pushDirection *= pushBackForce;
		Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();
		pushRB.velocity = Vector2.zero;
		pushRB.AddForce (pushDirection, ForceMode2D.Impulse);
	}
}
