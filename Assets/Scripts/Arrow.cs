using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	float flyingTime = 0.6f;
	public bool isFlying = false;

	// Use this for initialization
	void Start () {

	}

	public void Launch (Vector2 direction, float speed){
		Vector2 force = direction.normalized;
		force.x *= speed;
		force.y *= speed * 3;
		GetComponent<Rigidbody2D>().AddForce(force);
		isFlying = true;

		Debug.Log("direction" + direction.ToString());
		Debug.Log("speed" + speed.ToString());
		Debug.Log("force" + force.ToString());
    }
    
    // Update is called once per frame
	void Update () {
		if (isFlying) {
			flyingTime -= Time.deltaTime;
			transform.Rotate(new Vector3(0, 0, -.25f));
			if (flyingTime <= 0.0f) {
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
