using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField]
    private string objName;
    [SerializeField]
    private string pickUpText;

    private void Start()
    {

        Orbs sphere = new Orbs(objName, pickUpText);
        //sphere.Displaytext();

    }
    public string CollectableItem;
  
}
public class Orbs 
{
    string name;
    string pickUp;

    public Orbs(string Name, string Pickup)
    {
        name = Name;
        pickUp = Pickup;

    }
    public void Displaytext()
    {
        Debug.Log(name);
        Debug.Log(pickUp);
    }

}