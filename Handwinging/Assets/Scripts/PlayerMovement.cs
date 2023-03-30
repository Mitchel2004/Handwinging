using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float throttle = 1f;
    private Vector3 gravity = new Vector3(0, -9.81f, 0);

    private Vector3 velocity;
    [SerializeField] private float speed;


    int pitch = 0; // X
    int yaw = 0; // Y
    int roll = 0; // Z

    private void Update()
    {
        ThrustHandler();
        RotateAngle();
    }

    private void ThrustHandler()
    {
        velocity += gravity * Time.deltaTime;

        Vector3 thrust = speed * Vector3.forward;
        Vector3 lift = (-gravity + -velocity) * throttle;
        
        velocity += thrust * Time.deltaTime;
        velocity += lift * Time.deltaTime;
        
        transform.position += velocity * Time.deltaTime;
        Debug.DrawRay(transform.position, velocity, Color.red);

        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, velocity, Time.deltaTime, 0));
    }

    private float GetThrottle()
    {
        return 0;
    }

    private void RotateAngle()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            
        }

        transform.Rotate(new Vector3(pitch, yaw, roll) * Time.deltaTime);
    }
}