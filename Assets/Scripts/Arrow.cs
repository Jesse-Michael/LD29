using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	float flyingTime = 0.3f;
	public bool isFlying = false;

	
	AudioSource audioPlayer;
	AudioClip arrow1;
	AudioClip arrow2;
	AudioClip arrow3;
	AudioClip[] arrowBank;

	// Use this for initialization
	void Start () {

	}

	public void Launch (Vector2 direction, float speed){
		Vector2 force = direction.normalized;
		force.x *= speed;
		force.y *= speed * 3;
		GetComponent<Rigidbody2D>().AddForce(force);
		isFlying = true;
		
		audioPlayer = gameObject.AddComponent<AudioSource>();
		arrow1 = Resources.Load<AudioClip>("arrow1");
		arrow2 = Resources.Load<AudioClip>("arrow2");
		arrow3 = Resources.Load<AudioClip>("arrow3");
		arrowBank = new AudioClip[]{ arrow1, arrow2, arrow3 };
		
		int randomHit = (int)Random.Range (0.0f, 2.99f);
		audioPlayer.PlayOneShot (arrowBank [randomHit]);
    }
    
    // Update is called once per frame
	void Update () {
		if (isFlying) {
			GetComponent<Rigidbody2D>().gravityScale = 1.11f;
			flyingTime -= Time.deltaTime;
			transform.Rotate(new Vector3(0, 0, -.25f));
			if(flyingTime <= 0.0f) {
				TryHit();
			}
		}

		if (transform.position.y < -3) {
			Destroy(gameObject);
		}

	}


	void TryHit() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll (GetComponent<Collider2D>().transform.position, .15f);

		foreach (Collider2D collider in colliders) {
			if(collider.tag == "Monster")
			{
				if(Monster.hitable)
				{
					Monster.isHit = true;
					Destroy(gameObject);
				}
			}
		}

		//isFlying = false;
	}

}
