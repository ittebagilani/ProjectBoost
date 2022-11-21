/*
Name: Itteba Gilani
Purpose: To handle movement of the player
Date: Nov 7, 2021
*/

//Import necessary package
using UnityEngine;

//Class movement ineherits MonoBehaviour(from Unity)

public class Movement : MonoBehaviour
{
    //Private variables editable from the editor
    [SerializeField] float mainThrust = 100;
    [SerializeField] float rotateThrust = 100;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;


    //Reference variables
    Rigidbody rb;
    AudioSource audiosource;
    FuelSystem fuelSystem;


    // Start is called before the first frame update

    void Start()
    {   

        //Get respective component and assign to the reference variable
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        fuelSystem = GetComponent<FuelSystem>();
    }

    // Update is called once per frame

    void Update()
    {
        ProcessThrust();    
        ProcessRotation();
    }

    void ProcessThrust()
    {

        //If space is pressed, start Thrusting
        //Set fuel consumption rate to 15
        //Reduce fuel

        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
            fuelSystem.fuelConsumptionRate = 15f;
            fuelSystem.ReduceFuel();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        //If A is pressed, turn left
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();

        }

        //If D is pressed, turn right
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();

        }

        //Otherwise, stop rotating
        else
        {
            StopRotating();
        }
    }

    void StartThrusting()
    {   
        //Add relative force scaled by Time.deltaTime to avoid performance loss
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        //If rocket booster audio isn't playing, play it
        if (!audiosource.isPlaying)
        {
            audiosource.PlayOneShot(mainEngine);
        }
        
        //If rocket booster particles aren't playing, play it
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }

    void StopThrusting()
    {   
        //Stop the audio and the particles
        audiosource.Stop();
        mainBooster.Stop();
    }


    void RotateLeft()
    {
        //Call the apply rotation function in the positive direction
        ApplyRotation(rotateThrust);
    }

    void RotateRight()
    {   
        //Call the apply rotation function in the negative direction
        ApplyRotation(-rotateThrust);

    }

    void StopRotating()
    {
    }

    
    void ApplyRotation(float rotationThisFrame)
    {

        rb.freezeRotation = true;       //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;      //unfreezing rotation so the physics system can take over
    }
}
