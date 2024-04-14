using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OrbState { Normal, Collected, Visible, Invisible }

public class Orb : MonoBehaviour
{

    public OrbState state;

    public float VisibleTime = 3f;
    public float InvisibleTime = 3f;

    private float timer;

    //private bool isAppearing = false;
    private Coroutine appearCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        state = OrbState.Normal;
        timer = VisibleTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //appearCoroutine = StartCoroutine(OrbAppearFunction());
        switch (state)
        {
            case OrbState.Normal:
                state = OrbState.Visible;
                timer = VisibleTime;
                gameObject.SetActive(true);
                break;
            
            case OrbState.Visible:
                if (timer <= 0)
                {
                    state = OrbState.Invisible;
                    timer = InvisibleTime;
                    gameObject.SetActive(false);
                }
                break;

            case OrbState.Invisible:
                if (timer <= 0)
                {
                    state = OrbState.Visible;
                    timer = VisibleTime;
                    gameObject.SetActive(true);
                }
                break;

            case OrbState.Collected:
                Destroy(this.gameObject);
                break;
        }

        Debug.Log("Timer value: " + timer);
    }

    //IEnumerator OrbAppearFunction()
    //{
    //    if ()
    //    {
    //        Debug.Log("Orb Disappear");
    //        gameObject.SetActive(false);
    //        yield return new WaitForSeconds(InvisibleTime);


    //        Debug.Log("Orb Appear");
    //        gameObject.SetActive(true);
    //        yield return new WaitForSeconds(VisibleTime);

            

           
    //        yield return null;
    //        Debug.Log("Looping...");
    //    }
    //}

    public void Collect()
    {
        this.state = OrbState.Collected;
    }

}
