using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCon : MonoBehaviour
{
    public Transform camTarget;
    public float plerp = .02f;
    public float rlerp = .01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, plerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rlerp);
    }
}
