using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 finalOffset;
    private Vector3 _currentVelocity = Vector3.zero;


    private void Awake()
    {
        _offset = transform.position - target.position;
        finalOffset = _offset;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        // transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        Rotation();
        transform.position = Vector3.Lerp(transform.position, (targetPosition + finalOffset), .25f);
        transform.LookAt(target.transform.position);

    }

    private void Rotation() {
        finalOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*4f, Vector3.up) * finalOffset;
    }
}
