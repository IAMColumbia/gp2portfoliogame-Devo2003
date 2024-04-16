using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip VictorySound;
    void Start()
    {
        om = FindObjectOfType<OrbManager>();
        if (om == null)
        {
            Debug.LogError("Missing OrbManager");
        }
    }
    OrbManager om;
    // Update is called once per frame
    void Update()
    {
        //om = new OrbManager();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PickUp"))
        {
            //gameObject.SetActive(false);
            Orb o = other.gameObject.GetComponent<Orb>();
            if (o != null)
            {
                if (o.state != OrbState.Collected)
                {
                    Debug.Log("Player collided with an orb!");
                    o.Collect();
                    om.CollectOrb();
                }

            }

        }

        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Finished");
            AudioSource.PlayClipAtPoint(VictorySound, transform.position);
        }
    }


}

    

