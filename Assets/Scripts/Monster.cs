using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public static bool isHit = false;
	public static bool hitable = false;

	bool startActivate = false;
	bool startAttacking = false;
	bool isActive = false;
	Animator anim;

	float activateTime;
	float attackTime;


	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x, -2.3f, transform.position.z);
		anim = GetComponent<Animator>();
		activateTime = Random.Range (5.0f, 9.0f);
		attackTime = Random.Range (1.5f, 3.0f);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isHit) {
			Hit ();
		}
		else if (isActive) {
			attackTime -= Time.deltaTime;
			
			if(attackTime <= 0.0f)
			{
				Attack();
			}

		} else {
			activateTime -= Time.deltaTime;

			if(activateTime <= 0.0f)
			{
				StartActivate();
			}
		}
	}

	void StartActivate () {
		if (!startActivate) {
				startActivate = true;
				anim.SetTrigger ("activate");
				CameraScript.startShaking = true;
		} else if (transform.position.y < .56f) {
				transform.Translate (Vector3.up * 1.5f * Time.deltaTime);
		} else {
			transform.position =  new Vector3(transform.position.x, .56f, transform.position.z);
		}	



	}
	
	void EndActivate () {
		isActive = true;
		hitable = true;
	}


	void Attack () {
		if (!startAttacking) {
			startAttacking = true;
			anim.SetTrigger ("attack1");
		}
	}

	void AttackClimax () {
		float damage = Random.Range (5.0f, 8.0f);
		CameraScript.startHit = true;
		Hero.GetHit(damage);
	}

	void AttackLanded () {
		Reset ();
	}

	void Hit () {
		isHit = false;
		anim.SetTrigger ("hit");
	}

	void Reset () {
		startAttacking = false;
		hitable = true;
		attackTime = Random.Range (3.5f, 8.0f);
	}

	void Unhitable () {
		hitable = false;
	}

}
