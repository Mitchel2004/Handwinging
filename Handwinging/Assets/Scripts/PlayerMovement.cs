using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 1)] public float throttle = 1f;
    private Vector3 gravity = new Vector3(0, -9.8f, 0);

    [SerializeField] private float speed;
    private Vector3 velocity;

    private void Update()
    {
        LiftHandler();
        RollHandler();
        PitchHandler();
        ThrustHandler();
    }

    private float GetThrottle()
    {
        return 0;
    }

    private void LiftHandler()
    {
        velocity += gravity * Time.deltaTime;

        Vector3 lift = (-gravity + -velocity) * throttle;
        
        velocity += lift * Time.deltaTime;
        
        transform.position += velocity * Time.deltaTime;

        // transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, velocity, Time.deltaTime, 0));
    }

    private void RollHandler()
    {
        Vector3 direction = (GetComponent<SerialCommunication>().acceleration.x > 0 ? Vector3.right : (GetComponent<SerialCommunication>().acceleration.x == 0 ? Vector3.zero : Vector3.left));
        Vector3 roll = Mathf.Abs(GetComponent<SerialCommunication>().acceleration.x) * speed * direction;

        transform.position += roll * Time.deltaTime;

        transform.eulerAngles += new Vector3(0, 0, -GetComponent<SerialCommunication>().acceleration.x * 10) * Time.deltaTime;
    }

    private void PitchHandler()
    {
        Vector3 direction = (GetComponent<SerialCommunication>().acceleration.y > 0 ? Vector3.down : (GetComponent<SerialCommunication>().acceleration.y == 0 ? Vector3.zero : Vector3.up));
        Vector3 pitch = Mathf.Abs(GetComponent<SerialCommunication>().acceleration.y) * speed * direction;

        transform.position += pitch * Time.deltaTime;

        transform.eulerAngles += new Vector3(GetComponent<SerialCommunication>().acceleration.y * 10, 0, 0) * Time.deltaTime;
    }

    private void ThrustHandler()
    {
        Vector3 thrust = Vector3.forward * speed;

        transform.position += thrust * Time.deltaTime;
    }
}