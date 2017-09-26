using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GossDistribution : MonoBehaviour {
	/// <summary>
	/// This script deals with zimms in the front to represent as leaders. To fit the theme of the project, these zimmers are specifically made smaller
	/// than the rest of the zimmers to make it look ironic
	/// They still use gaussian distribution to set their x, y and z values
	/// </summary>
    public GameObject prefab;//zim model
    private GameObject[] gameOBJ = new GameObject[10];
    public Terrain givenLand;//use for setting position on land
    // Use this for initialization

    private void Start()//in this method I quickly spawn all the front zimmers in a line with a gaussian distribution for the height, width and depth
    {
        givenLand = GetComponent<Terrain>();
        float distMultiplyer = 6f;
        for (int i = 0; i < gameOBJ.Length; i++)
        {   
            gameOBJ[i] = prefab;
            gameOBJ[i].transform.position = new Vector3(5f+(i*distMultiplyer), 100f, 130f+Random.Range(-5f,5f));//positioning alg
            //gaussian Works, but need to play around with the values to see what works
            gameOBJ[i].transform.localScale = new Vector3(Gaussian(.11f,.02f), Gaussian(.12f,.03f), Gaussian(.11f, .02f));
            Vector3 pos = gameOBJ[i].transform.position;
            pos.y = givenLand.SampleHeight(gameOBJ[i].transform.position);
            pos.y += 5f;//give a small offset to keep on top of the land
            gameOBJ[i].transform.position = pos;
			Instantiate(gameOBJ[i], gameOBJ[i].transform.position, Quaternion.Euler(0f,-90f,0f));//spawn the zimmers
        }    
    }
    private float Gaussian(float mean, float stdDev)//Gaussian algorithm
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);
        float gaussValue = Mathf.Sqrt(-2.0f * Mathf.Log(val1)) * Mathf.Sin(2.0f * Mathf.PI * val2);
        return mean + stdDev * gaussValue;
    }
}
