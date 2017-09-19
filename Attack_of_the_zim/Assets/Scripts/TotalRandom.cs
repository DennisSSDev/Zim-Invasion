using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalRandom : MonoBehaviour {

    Terrain terOBJ;
    public GameObject prefab;
    float randValueX;
    float randValuesZ;
    GameObject[] randOBJ = new GameObject[30];
	// Use this for initialization
	void Start () {
        terOBJ = GetComponent<Terrain>();
        for (int i = 0; i < randOBJ.Length; i++)
        {
            randOBJ[i] = prefab;
            randOBJ[i].transform.position = GenerateRand(terOBJ.terrainData);
            Vector3 pos = randOBJ[i].transform.position;
            pos.y = terOBJ.SampleHeight(randOBJ[i].transform.position);
            pos.y += 2f;
            randOBJ[i].transform.position = pos;
            Instantiate(randOBJ[i], randOBJ[i].transform.position, Quaternion.identity);
        }
        //go to the inspector and add a rigid body and constraint the movement of the values + add more to the y
	}
    Vector3 GenerateRand(TerrainData info)
    {
        randValueX = Random.Range(0f, info.heightmapWidth+100f);
        randValuesZ = Random.Range(0f, info.heightmapHeight+100f);
        return new Vector3(randValueX, 100f, randValuesZ);
    }


}
