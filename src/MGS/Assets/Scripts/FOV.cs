using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FOV : MonoBehaviour
{
    public float distance =10;
    public float angle = 30;
    public float height = 1.0f;
    public Color MeshColor = Color.red;
    public int RayCount = 30;
    public int RaySize = 30;

    ScoreManager sm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RayCast();
        
    }

    

    public void RayCast()
    {
        int PlayerLayer = 1 << LayerMask.NameToLayer("Player");

        // Direction of the ray 
        Vector3 forwardDirection = transform.forward;

        // Origin point of the ray 
        Vector3 rayOrigin = transform.position;

        // Cast rays for each vertex mesh
        for (int i = 0; i < RayCount; i++)
        {
            float currentAngle = Mathf.Lerp(-angle / 2f, angle / 2f, i / (float)(RayCount - 1));
            Vector3 rayDirection = Quaternion.Euler(0, currentAngle, 0) * forwardDirection * RaySize;

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, rayDirection, out hit, distance, PlayerLayer))
            {
                Debug.DrawLine(rayOrigin, hit.point, Color.blue); // display the blue rays where the capsule was spotted from
                Debug.Log("Hit player: " + hit.collider.gameObject.name);
                //Player Found
                sm.setScore = 0;

                SceneManager.LoadScene("GameOver");
                

                // Calculate rotation to align triangle with ray direction
                Quaternion rotation = Quaternion.LookRotation(rayDirection, Vector3.up);
               
            }
            else
            {
                Debug.DrawRay(rayOrigin, rayDirection * distance, Color.red); // display the search rays
            }
        }
    }
}
