using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour {
	/// <summary>
	/// This script allows me to play a sound in the menus and stop it as soop as the player hits the play
	/// </summary>
    Camera_Locations obj;
    AudioSource audio;
    public void Start() {
        obj = FindObjectOfType<Camera_Locations>();
        audio = GetComponent<AudioSource>();
    }

	public void OnClick(){
        obj.playGamePressed = true;
        audio.Stop();
        Canvas can = FindObjectOfType<Canvas>();
        can.gameObject.SetActive(false);

        }

}
