/*
Name: Itteba Gilani
Purpose: This script is responsible for the enemies in lvl4/5 that follow you
Date: Nov 8, 2021
*/

//Import necessary package
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //private variable to be edited in editor
    [SerializeField] float transformSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //move the position of the object to the object with the tag, "Player" at a rate of transformSpeed;
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, transformSpeed);
    }
}
