using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum OrbState { Collected, Visible, Invisible }

public class Orb : MonoBehaviour
{
    public OrbState state;
    public float timer;
    public float time = 3;

    public AudioClip PickUpSound;

    public Vector3 normalScale;
    public Vector3 visibleScale = Vector3.one;
    public Vector3 InvisibleScale = Vector3.zero;
    // Start is called before the first frame update

    private MeshRenderer Orbmesh;
    void Start()
    {
        Orbmesh = GetComponent<MeshRenderer>();
        state = OrbState.Visible;
        this.timer = time;
        //normalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        timer -= Time.deltaTime;
        switch (state)
        {
            case OrbState.Visible:
                Orbmesh.enabled = true;
                //this.gameObject.GetComponent<MeshRenderer>().enabled = true;
                //UpdateScale(visibleScale);
                break;

            case OrbState.Invisible:
                Orbmesh.enabled = false;
                //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                //UpdateScale(InvisibleScale);
                break;

            case OrbState.Collected:
                Destroy(this.gameObject);

                AudioSource.PlayClipAtPoint(PickUpSound, transform.position);
                break;
        }
    }

    public void UpdateTimer()
    {
        this.timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (state == OrbState.Visible)
            {
                state = OrbState.Invisible;
            }
            else
            {
                state = OrbState.Visible;
            }
            timer = time;
        }
    }
    public void UpdateScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void Collect()
    {
        this.state = OrbState.Collected;
    }

}
