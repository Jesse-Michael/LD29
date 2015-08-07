using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public static bool startShaking = false;
	public static bool startHit = false;
	bool isShaking = false;
	bool isHit = false;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (startShaking) {
			StartShake();
		}
		else if (startHit) {
			StartHit();
		}
	}

	void StartHit () {
		startHit = false;
		
		if (!isHit) {
			isHit = true;
			anim.SetTrigger ("hit");
		}
	}

	void EndHit () {
		isHit = false;
		
	}

	void StartShake () {
		startShaking = false;

		if (!isShaking) {
			isShaking = true;
			anim.SetTrigger ("shake");
		}
	}

	void EndShake () {
		isShaking = false;

	}
}
