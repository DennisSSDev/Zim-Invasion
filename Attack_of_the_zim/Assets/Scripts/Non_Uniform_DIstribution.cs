using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Non_Uniform_DIstribution : MonoBehaviour {

    private List<Vector3> positions = new List<Vector3>();
    public GameObject prefab;
    public GameObject[] gameOBJ = new GameObject[100];
    Terrain givenLand;
    float randDis;
    float z;
    float x;
    // Use this for initialization
    void Start () {
        givenLand = GetComponent<Terrain>();   
        for (int i = 0; i < gameOBJ.Length; i++)
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

                if (!positions.Contains(save))
                {
                    gameOBJ[i].transform.position = save;
                    positions.Add(save);
                    Vector3 pos = gameOBJ[i].transform.position;
                    pos.y = givenLand.SampleHeight(gameOBJ[i].transform.position);
                    pos.y += 2f;
                    gameOBJ[i].transform.position = pos;
                    Instantiate(gameOBJ[i], gameOBJ[i].transform.position, Quaternion.identity);
                    break;
                }
           }
        }	
	}
}
