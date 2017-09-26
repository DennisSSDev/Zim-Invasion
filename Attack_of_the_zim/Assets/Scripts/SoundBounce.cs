using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBounce : MonoBehaviour {

    public AudioSource bounce;
	/// <summary>
	/// Raises the collision enter event.
	/// This method allows us to make the bounce sound when the zimmers hit the ground
	/// I lowered the volume and made sure the zimmers occasionally make the sound as it would be crazy if I didn't
	/// 
	/// </summary>
	/// <param name="collision">Collision.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            float lastBump = 0;
            if (lastBump < Time.time)
            {
                float rand = Random.Range(0f,1f);
                if (rand<0.15f)
                {
                    
					bounce.volume = 0.15f;
                    bounce.Play();
                    Debug.Log("Played Sound");
                }
                lastBump = Time.time;
            }
                
            
        }
            

    }
}
