using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalRandom : MonoBehaviour {
	/// <summary>
	/// This script sets the Tall zimmers across the map randomly (truly random) 
	/// </summary>
    public Terrain terOBJ;
    public GameObject prefab;
    float randValueX;
    float randValuesZ;
    private GameObject[] randOBJ = new GameObject[30];//there is a total of 30 tall zimmers scattered around the map
	// Use this for initialization
	private void Start () {
        terOBJ = GetComponent<Terrain>();
        for (int i = 0; i < randOBJ.Length; i++)
        {
			//this spawns the tall zimmers and gives them a small y offest to not spawn in the ground
            randOBJ[i] = prefab;
            randOBJ[i].transform.position = GenerateRand(terOBJ.terrainData);
            Vector3 pos = randOBJ[i].transform.position;
            pos.y = terOBJ.SampleHeight(randOBJ[i].transform.position);
            pos.y += 10f;
            randOBJ[i].transform.position = pos;

			Instantiate(randOBJ[i], randOBJ[i].transform.position, Quaternion.Euler(0f,-90f,0f));
        }
        //go to the inspector and add a rigid body and constraint the movement of the values + add more to the y
	}
    private Vector3 GenerateRand(TerrainData info)//this method allows me to spawn tall zimmers on top of the terrain
    {
        randValueX = Random.Range(0f, info.heightmapWidth+100f);
        randValuesZ = Random.Range(0f, info.heightmapHeight+100f);
        return new Vector3(randValueX, 100f, randValuesZ);
    }
}
