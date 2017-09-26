using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Non_Uniform_DIstribution : MonoBehaviour {
	/// <summary>
	/// This script allows me non-unoformally spawn Gir (the green guy),
	/// Unfortunately I forgot to zero out the positions in maya and the models 
	/// will spawn a little higher abovve the ground (could not fix due to late realization)
	/// I also use a list to store all the used up positions to not reuse the same random values
	/// </summary>
    private List<Vector3> positions = new List<Vector3>();
    public GameObject prefab;
    public GameObject[] gameOBJ = new GameObject[100];
    public Terrain givenLand;
    private float randDis;
    private float z;
    private float x;
    // Use this for initialization
    void Start () {
        givenLand = GetComponent<Terrain>();//will use in  the future for setting up the girs on top of the landscape   
        for (int i = 0; i < gameOBJ.Length; i++)//spawning alg for non uniform 
        {
            gameOBJ[i] = prefab;
            while (true)
            {
                randDis = Random.Range(0f, 1f);
                z = Random.Range(20, 220f);
                if (randDis < 0.5f)
                    x = Random.Range(105f, 130f);
                if (randDis < 0.15f)
                    x = Random.Range(60f, 100f);
                else if (randDis < 0.4f)
                    x = Random.Range(30f, 50f);     
                else
                    x = Random.Range(15f, 25f);

                Vector3 save = new Vector3(x+60f, 100f, z);

                if (!positions.Contains(save))//this allows me to check whether the vector3 was reused before
                {
                    gameOBJ[i].transform.position = save;
                    positions.Add(save);
                    Vector3 pos = gameOBJ[i].transform.position;
                    pos.y = givenLand.SampleHeight(gameOBJ[i].transform.position);
					pos.y += prefab.GetComponent<CapsuleCollider> ().height / 2f;//unfortunately due to the fact that I didn't zero out the transforms in Maya, the models spawn a little higher,
					//but if you replace the model with say a cylinder, it will work perfectly fine
                    gameOBJ[i].transform.position = pos;
                    Instantiate(gameOBJ[i], gameOBJ[i].transform.position, Quaternion.identity);//spawn Gir
                    break;
                }
           }
        }	
	}
}
