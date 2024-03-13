using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public UnityEngine.AI.NavMeshAgent nav;

    public float speed = 5f;

    public float ascend = 0.0f;
    public float XMovement;
    public float YMovement;
    public int TotalOrbs = 1;


    public GameObject endPointPrefab;
    private GameObject endPointInstance;
    public List<string> orbs;

    private void Start()
    {
        orbs = new List<string>();
    }


    // Update is called once per frame
    
    void Update()
    {
        OrbCount();

        ControllerMovement();
    }

    public void ControllerMovement()
    {
        XMovement = Input.GetAxis("Horizontal");
        YMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            ascend = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ascend = -1.0f;
        }
        Vector3 movement = new Vector3(XMovement, ascend, YMovement);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    //When the player hovers over the orbs they get collected
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            
            string CollectableItem = other.gameObject.GetComponent<Collectibles>().CollectableItem;

            orbs.Add(CollectableItem);
            Destroy(other.gameObject);
            //gameObject.SetActive(other.gameObject);
            //Text is sent to the console at the bottom of the screen
            //print("You gained the power of " + CollectableItem);

            

        }
    }

    public void OrbCount()
    {
        if (orbs.Count == TotalOrbs)
        {
            SpawnEndPoint();
        }
    }

    private void SpawnEndPoint()
    {
        print("END!");
        Vector3 EndPosition = new Vector3(-2f, 0.54f, -1f);
        endPointInstance = Instantiate(endPointPrefab, EndPosition, Quaternion.identity);
    }
}
