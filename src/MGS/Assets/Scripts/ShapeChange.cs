using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeChange : MonoBehaviour
{
    //ScoreManager sm;
    public GameObject NormalDisguise;
    public GameObject boxDiguise;

    public bool InBoxForm = false;
    public float BoxTime = 0f;
    public float timeThreshold = 2f; //loses points every 2 secs while in box form
    // Start is called before the first frame update

   

    void Start()
    {


        //sm = GameObject.FindObjectOfType<ScoreManager>();
        //if (sm != null )
        //{
        //    Debug.LogError("No Scoremanager!");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisguiseChange();
        }

        if (InBoxForm)
        {
            BoxTime += Time.deltaTime;
            if (BoxTime >= timeThreshold)
            {
                BoxTime -= timeThreshold;
                Score.CurrentScore -= 50;
            }
        }
    }

    public void DisguiseChange()
    {
        // Get the current position of the player's shape
        Vector3 playerShapePosition = NormalDisguise.transform.localPosition;

        // If the normal disguise is active, switch to the box disguise
        if (NormalDisguise.activeSelf)
        {
            // Deactivate normal disguise
            NormalDisguise.SetActive(false);
            // Activate box disguise
            boxDiguise.SetActive(true);
            // Set the position of the player's shape to its previous position
            boxDiguise.transform.localPosition = playerShapePosition;
            InBoxForm = true;
        }
        // If the box disguise is active, switch to the normal disguise
        else if (boxDiguise.activeSelf)
        {
            Score.CurrentScore -= 250;
            // Deactivate box disguise
            boxDiguise.SetActive(false);
            // Activate normal disguise
            NormalDisguise.SetActive(true);
            // Set the position of the player's shape to its previous position
            NormalDisguise.transform.localPosition = playerShapePosition;
            InBoxForm = false;
            BoxTime = 0f; // time reset when in normal form
        }
    }
}
