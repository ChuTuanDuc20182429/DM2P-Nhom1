using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telemetry : MonoBehaviour
{
    private bool is_pick = false;
    public bool isPick   // property
    {
        get { return is_pick; }   // get method
        set { is_pick = value; }  // set method
    }

    private bool is_touch = false;
    public bool isTouch   // property
    {
        get { return is_touch; }   // get method
        set { is_touch = value; }  // set method
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
