using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject LeftFoot;
    private bool pick = false;
    [SerializeField]
    private GameObject _telemetry;
    private Telemetry telemetry;
    // Start is called before the first frame update
    void Start()
    {
        telemetry = _telemetry.GetComponent<Telemetry>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pick && telemetry.isPick)
        {
            transform.position = LeftFoot.transform.position + transform.forward;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter " + other.name);
        if (other.tag == "Dog")
        {
            pick = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay " + other.name);
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit " + other.name);
        if (other.tag == "Dog" && telemetry.isPick == false)
        {
            pick = false;
        }
    }
}
