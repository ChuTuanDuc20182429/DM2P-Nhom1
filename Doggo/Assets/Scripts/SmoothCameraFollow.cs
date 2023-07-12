using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    private Vector3 finalOffset;


    private void Awake()
    {
        //_offset = transform.position - target.position;
        finalOffset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Rotation();
        transform.position = Vector3.Lerp(transform.position, (target.position + finalOffset), .25f);
        transform.LookAt(target.position - finalOffset);

    }

    private void Rotation() {
        finalOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*4f, Vector3.up) * finalOffset;
    }
}
