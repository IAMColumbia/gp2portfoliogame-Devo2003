using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update

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
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PickUp"))
        {
            //gameObject.SetActive(false);
            Orb o = other.gameObject.GetComponent<Orb>();
            if (o != null && o.state == OrbState.Visible)
            {
                Debug.Log("Player collided with an orb!");
                o.Collect();
                om.CollectOrb();
            }

        }

        if (other.CompareTag("Finish"))
        {
            Score.CurrentScore += 600;
            SceneManager.LoadScene("Finished");
        }
    }


}

    

