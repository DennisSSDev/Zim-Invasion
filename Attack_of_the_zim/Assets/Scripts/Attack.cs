using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public AudioClip[] sounds;//store all the info on the audio clips the enemy is going to play
	RaycastHit obj;//store raycast info here
	bool allower = false;//this will determine whether we can attack or not
	Camera_Locations loc;
	public Camera cama;
	private void Start(){
		
		loc = FindObjectOfType<Camera_Locations>();//store info from camera_locations script that will determine whether we can attack or not
	}
	/// <summary>
	/// Update this instance.
	/// The method checks for raycast hits from the center of the screen in first person view 
	/// If we hit a Zimmer, we destroy him and play a random sound he can make from the array of soounds
	/// </summary>

	private void Update(){
		allower = loc.invasionStarted;
		if (allower) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = cama.ScreenPointToRay(Input.mousePosition);
				Physics.Raycast (ray, out obj);//shoot a ray to where your camera is pointing and store the info of what it hits
				if (obj.transform.gameObject.tag == "Zimmer") {//if we hita  zimmer with the raytrace destroy that zimmer and play a soundeffect
					Destroy (obj.transform.gameObject);
					AudioSource source = GetComponent<AudioSource> ();
					float randomSelect = Random.Range (0f, 1f);
					if (randomSelect < 0.25f) {//determine sound effect here
						source.clip = sounds [0];
						source.Play ();
					} else if (randomSelect < 0.5f) {
						source.clip = sounds [1];
						source.Play ();
					} else if (randomSelect < 0.75f) {
						source.clip = sounds [2];
						source.Play ();
					} else if (randomSelect < 1f) {
						source.clip = sounds [3];
						source.Play ();
					}
				}
			}
		}


}
}
