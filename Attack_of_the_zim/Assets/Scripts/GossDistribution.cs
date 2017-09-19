using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GossDistribution : MonoBehaviour {

    public GameObject prefab;
    private GameObject[] gameOBJ = new GameObject[10];
    Terrain givenLand;
    // Use this for initialization
    void Start()
    {
        givenLand = GetComponent<Terrain>();
        float distMultiplyer = 6f;
        for (int i = 0; i < gameOBJ.Length; i++)
        {   
            gameOBJ[i] = prefab;
            gameOBJ[i].transform.position = new Vector3(5f+(i*distMultiplyer), 100f, 130f+Random.Range(-5f,5f));
            //gaussian Works, but need to play around with the values to see what works
            gameOBJ[i].transform.localScale = new Vector3(Gaussian(3f, 0.5f), Gaussian(6.5f,1f), Gaussian(3f, .5f));
            Vector3 pos = gameOBJ[i].transform.position;
            pos.y = givenLand.SampleHeight(gameOBJ[i].transform.position);
            pos.y += 2f;
            gameOBJ[i].transform.position = pos;
            Instantiate(gameOBJ[i], gameOBJ[i].transform.position, Quaternion.identity);
        }    
    }
	// Update is called once per frame
    float Gaussian(float mean, float stdDev)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }
}
