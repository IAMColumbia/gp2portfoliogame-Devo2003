using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlCompleteTrigger : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip lvlComplete;
    public float volume;

    public bool isPlaying = true;

   

    //When the players box collider triggers this code it plays a little tune once
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")
        {
            if (isPlaying)
            {
                //soundSource.Play();
                soundSource.PlayOneShot(lvlComplete, volume);
                isPlaying = false;
            }
              


        }

        



    }

   

}
