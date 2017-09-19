using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Locations : MonoBehaviour {

    public GameObject[] cameras; // Current camera 
    public PhysicMaterial mat;
    private int currentCameraIndex; // Use this for initialization
    public bool playGamePressed = false;
    GameObject[] zimmers;
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
            if (Input.GetKeyDown(KeyCode.X))
            {
                cameras[currentCameraIndex].gameObject.SetActive(false);
                currentCameraIndex = 5;
                cameras[currentCameraIndex].gameObject.SetActive(true);
                zimmers = GameObject.FindGameObjectsWithTag("Zimmer");
                Debug.Log(zimmers.Length);
                for (int i = 0; i < zimmers.Length; i++)
                {
                    Vector3 pos = new Vector3(zimmers[i].transform.position.x, Random.Range(40f, 100f),
                        zimmers[i].transform.position.z);
                    zimmers[i].transform.position = pos;
                    zimmers[i].AddComponent<Rigidbody>();
                    zimmers[i].GetComponent<CapsuleCollider>().material = mat;
                }
                //can potentially add code to manipulate the characters in the world
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
    private void OnGUI()
    {
        if(playGamePressed)
            GUI.Box(new Rect(10f, 10f, 200f,60f), "Press C to view the Battlefield \n \n X to Begin Fight");
    }
    

}
