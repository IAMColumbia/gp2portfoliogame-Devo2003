using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float speed = 5f;

    public float ascend = 0.0f;
    public float XMovement;
    public float YMovement;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        //rb.AddForce(movement * speed);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    
}
