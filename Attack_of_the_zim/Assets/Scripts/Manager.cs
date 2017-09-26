using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	/// <summary>
	/// This script allows me to create a perlin noise terrrain
	/// </summary>

    private TerrainData data;
    public int width = 200; //inittal set of values for the terrain 
    public int depth = 50;
    public int height = 200;
    public float scale = 20f;
    public Vector3 worldSize; // will set this vector at the start of the game to determine the dimensions of Terrain
    public int resolution = 129; // still not sure why we need resolution hence we can generate perlin noise through the width and height 
    public float[,] heightArray; //gonna store verticy values in here 

    public float offsetX = 100f; // initial values of x and y offset
    public float offsetY = 100f;
                                      // Use this for initialization
    void Start()
    {
        offsetX = Random.Range(0f, 999f);//at the start of the game get two random values for x and y to add to the randomness
        offsetY = Random.Range(0, 999f);

        worldSize = new Vector3(width, depth, height);//set the world vector to determine initial size (height, depth, width)
        data = GetComponent<TerrainCollider>().terrainData; //retrieve terrain data 
        data.size = worldSize; // set the size of the terrain to the world vector 
        data.heightmapResolution = 129;//set the resolution
        heightArray = new float[resolution, resolution]; //se the 2d array for the terrain vertex
                                                         //CreateSteepMap(); Call this method if you want the terrain generation to be steep
    }

    // Update is called once per frame
    void Update()
    {
        worldSize = new Vector3(width, depth, height);//this will allow you to change the values of the terrain mids simulation
        data.size = worldSize;//set the changes of terrain
        PerlinNoise();//generate noise
    }
    public void PerlinNoise()//alg for setting the heights of the terrain
    {
        for (int x = 0; x < resolution; x++)//embedded loop to set each y for each x 
        {
            for (int y = 0; y < resolution; y++)
            {
                heightArray[x, y] = Mathf.PerlinNoise((float)(x / 20f) * scale, (float)(y / 20f) * scale);//use the perlin noise method and pass in the x and y divided
                //by an arbitrary number and multiply by the scaler and add the offset to simulate moving uniform terrain
            }
        }
        data.SetHeights(0, 0, heightArray);//output the result
    }
}

