using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    private Animator anim;
    private float movementSpeed;
    private float smooth;
    private float tiltAngle;
    public AudioSource audioSource_bark;
    public AudioSource audioSource_grass;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movementSpeed = 5f;
        smooth = 5.0f;
        tiltAngle = 60.0f;
        audioSource_bark.Stop();
        audioSource_grass.Stop();

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

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (anim != null) {
                    anim.Play("Base Layer.StandingStill", 0 , 0.25f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) {
            if (anim != null) {
                anim.Play("Base Layer.Walk", 0, 0.25f);
                audioSource_grass.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) {
            if (anim != null) {
                anim.Play("Base Layer.StandingStill", 0, 0.25f);
                audioSource_grass.Stop();
            }
        }
        else if (Input.GetKeyDown(KeyCode.B)) {
            if (anim != null) {
                anim.Play("Base Layer.Bark", 0 , 0.25f);
                audioSource_bark.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.B)) {
            if (anim != null) {
                anim.Play("Base Layer.StandingStill", 0 , 0.25f);
                audioSource_bark.Stop();
            }
        }
        

        if (Input.GetKey(KeyCode.W)) {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
            
            // transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, 0, verticalInput * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * movementSpeed * Time.deltaTime;
            
            // transform.position = transform.position - new Vector3(horizontalInput * -movementSpeed * Time.deltaTime, 0, verticalInput * -movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            // transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        }
        Rotation();
    }

    private void Rotation(){
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*4f, 0));
    }
}
