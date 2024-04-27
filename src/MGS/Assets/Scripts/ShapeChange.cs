using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeChange : MonoBehaviour
{
    ScoreManager sm;
    public GameObject NormalDisguise;
    public GameObject boxDiguise;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisguiseChange();
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
        }
        // If the box disguise is active, switch to the normal disguise
        else if (boxDiguise.activeSelf)
        {
            sm.setScore -= 250;
            // Deactivate box disguise
            boxDiguise.SetActive(false);
            // Activate normal disguise
            NormalDisguise.SetActive(true);
            // Set the position of the player's shape to its previous position
            NormalDisguise.transform.localPosition = playerShapePosition;
        }
    }
}
