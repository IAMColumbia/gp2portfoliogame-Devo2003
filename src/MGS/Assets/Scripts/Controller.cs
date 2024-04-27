using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float speed = 5f;

    public float ascend = 0.0f;
    public float XMovement;
    public float YMovement;


    Vector3 Vec;

    
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
 
        Vec = transform.localPosition;
        Vec.x += Input.GetAxis("Horizontal") * Time.deltaTime * 5;
        Vec.z += Input.GetAxis("Vertical") * Time.deltaTime * 5;
        transform.localPosition = Vec;

    }
}
