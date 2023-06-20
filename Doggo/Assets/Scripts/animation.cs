using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private Animator anim;
    private bool flag;
    private float movementSpeed;
    private float smooth;
    private float tiltAngle;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        flag = true;
        movementSpeed = 5f;
        smooth = 5.0f;
        tiltAngle = 60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");
        float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;
        
        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, tiltAroundY, 0);

        if (Input.GetKey(KeyCode.Space)) {
            if (anim != null) {
                if (flag == true) {
                    anim.Play("Base Layer.Walk", 0 , 0.25f);
                    flag = false;
                }
                else {
                    anim.Play("Base Layer.Rest", 0, 0.25f);
                    flag = true;
                }
            }
        }
        else if (Input.GetKey(KeyCode.W)) {
            transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.position = transform.position - new Vector3(horizontalInput * -movementSpeed * Time.deltaTime, 0, verticalInput * -movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        }
    }
}
