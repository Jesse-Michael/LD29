using UnityEngine;
using System.Collections;

public class HeroArm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HideHand ()
	{
		
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		
		foreach (Renderer renderer in renderers) {
			
			renderer.enabled = false;
			
		}
	}


	public void ShowHand ()
	{
		
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		
		foreach (Renderer renderer in renderers) {
			
			renderer.enabled = true;
			
		}
	}
}
