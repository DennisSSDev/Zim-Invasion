using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Locations : MonoBehaviour {
	/// <summary>
	/// This class determines the camera locations transitions
	/// Sets the bouncyness of the zimmers 
	/// enables the extra game play for the player to explore and kill some zimmers
	/// Sets some audio sources so the zimmers get some bouncyness
	/// </summary>
    public GameObject[] cameras; // Current camera + the player controller
    public PhysicMaterial mat;
    public AudioClip cloneBounce;
    public GameObject[] wall;
    private int currentCameraIndex; // Use this for initialization
    public bool playGamePressed = false;
	public bool invasionStarted = false;
    GameObject[] zimmers;
    GameObject[] walls;
    void Start()
    {
        currentCameraIndex = 0;
        // Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
        // If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
        }
    
        }// Update is called once per frame
    void Update() {
        if (playGamePressed)
        {
            if (Input.GetKeyDown(KeyCode.X))//when the player presses this button he switches to the player controller immediatelly
            {
                cameras[currentCameraIndex].gameObject.SetActive(false);
                currentCameraIndex = 5;
                cameras[currentCameraIndex].gameObject.SetActive(true);
                zimmers = GameObject.FindGameObjectsWithTag("Zimmer");
                Debug.Log(zimmers.Length);
                //can potentially add code to manipulate the characters in the world
            }
            if (Input.GetKeyDown(KeyCode.R))//when the player hits R, the zimmers get launched into the air and the attack of teh zim begins
            {
				invasionStarted = true;
                for (int i = 0; i < zimmers.Length; i++)
                {
                    Vector3 pos = new Vector3(zimmers[i].transform.position.x, Random.Range(40f, 100f),
                        zimmers[i].transform.position.z);
                    zimmers[i].transform.position = pos;
                    zimmers[i].AddComponent<Rigidbody>();
                    zimmers[i].GetComponent<CapsuleCollider>().material = mat;//assign a bouncy material

                    zimmers[i].AddComponent<AudioSource>();
                    zimmers[i].GetComponent<AudioSource>().clip = cloneBounce;//asign a bouncy sound
                    zimmers[i].AddComponent<SoundBounce>();
                    zimmers[i].GetComponent<SoundBounce>().bounce = zimmers[i].GetComponent<AudioSource>();
                }
				for (int i = 0; i < wall.Length; i++) {
					wall [i].gameObject.SetActive (true);//activate space
				}
               
            }
            // Press the 'C' key to cycle through cameras in the array
            if (Input.GetKeyDown(KeyCode.C))
            {
                // Cycle to the next camera
                currentCameraIndex++;

                if (currentCameraIndex < cameras.Length - 1)
                {
                    cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                    cameras[currentCameraIndex].gameObject.SetActive(true);
                }
                else
                {
                    cameras[currentCameraIndex - 1].gameObject.SetActive(false);
                    currentCameraIndex = 0;
                    cameras[currentCameraIndex].gameObject.SetActive(true);
                }

            }
        }     
    }
    private void OnGUI()//GUI operations that tell the player what to do
    {
        if (playGamePressed)
        {
            if (currentCameraIndex != 5)
            {


                GUI.Box(new Rect(10f, 10f, 200f, 60f), "Press C to view the Battlefield \n \n X to Begin Fight");
                if (currentCameraIndex == 0)
                    GUI.Box(new Rect(300f, 10f, 200, 60f), "Top View \n \n Of Battlefield");
                else if (currentCameraIndex == 1)
                    GUI.Box(new Rect(300f, 10f, 200, 60f), "Side View \n \n Of Battlefield");
                else if (currentCameraIndex == 2)
                    GUI.Box(new Rect(300f, 10f, 200, 60f), "Leader Zims \n These guys \n can't take a height joke");
                else if (currentCameraIndex == 3)
                    GUI.Box(new Rect(300f, 10f, 200, 60f), "These are the pets \n Or as Zim calls them \n Giiiiiiiiirz");
                else if (currentCameraIndex == 4)
                    GUI.Box(new Rect(300f, 10f, 200, 60f), "Here is a close up \n On an \n Unsuspecting Gir");
            }
        }

        if (currentCameraIndex == 5)
        {
            GUI.Box(new Rect(10f, 10f, 200f, 60f), "Press R to launch\nthe Zim attack");
        }
    }
    

}
