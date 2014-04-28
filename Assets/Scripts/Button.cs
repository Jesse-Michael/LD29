using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {


	void Start(){

	}

	void Update () {

	}

	void OnMouseUpAsButton () {
	
		switch (name) {
			case "play":
				Application.LoadLevel("Game");
				break;

			case "credits":
				Application.LoadLevel("Credits");
				break;

			case "creditstext":
				Application.LoadLevel("Menu");
				break;

			case "retry":
				Application.LoadLevel("Game");
				break;

		}
	}
}
