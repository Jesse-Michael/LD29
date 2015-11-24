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

	AudioSource audioPlayer;
	AudioClip activate;
	AudioClip monsterHit1;
	AudioClip monsterHit2;
	AudioClip monsterHit3;
	AudioClip[] monsterBank;
	AudioClip arrowHit1;
	AudioClip arrowHit2;
	AudioClip arrowHit3;
	AudioClip[] arrowBank;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x, -2.3f, transform.position.z);
		anim = GetComponent<Animator>();
		activateTime = Random.Range (5.0f, 9.0f);
		attackTime = Random.Range (1.5f, 3.0f);
		audioPlayer = gameObject.AddComponent<AudioSource>();
		activate = Resources.Load<AudioClip>("activate");
		monsterHit1 = Resources.Load<AudioClip>("monsterHit1");
		monsterHit2 = Resources.Load<AudioClip>("monsterHit2");
		monsterHit3 = Resources.Load<AudioClip>("monsterHit3");
		monsterBank = new AudioClip[]{ monsterHit1, monsterHit2, monsterHit3 };
		arrowHit1 = Resources.Load<AudioClip>("thunderHit1");
		arrowHit2 = Resources.Load<AudioClip>("thunderHit2");
		arrowBank = new AudioClip[]{ arrowHit1, arrowHit2 };
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
			audioPlayer.PlayOneShot(activate);
			#if(UNITY_ANDROID || UNITY_IOS || UNITY_WP8) 
				Handheld.Vibrate();
			#endif
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
		int randomHit = (int)Random.Range (0.0f, 2.99f);
		audioPlayer.PlayOneShot (monsterBank [randomHit]);
	}

	void AttackLanded () {
		Reset ();
	}

	void Hit () {
		isHit = false;
		anim.SetTrigger ("hit");
		int randomHit = (int)Random.Range (0.0f, 1.99f);
		audioPlayer.PlayOneShot (arrowBank [randomHit]);
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
