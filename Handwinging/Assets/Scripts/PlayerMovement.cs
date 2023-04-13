using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform aircraft;
    private Vector3 acceleration;

    [SerializeField] private float speed;

    private void Start()
    {
        aircraft = GameObject.FindGameObjectWithTag("Aircraft").transform;
    }

    private void Update()
    {
        acceleration = GetComponent<SerialCommunication>().acceleration;

        RollHandler();
        PitchHandler();
        ThrustHandler();
    }

    private void RollHandler()
    {
        Vector3 direction = acceleration.x > 0 ? Vector3.right : (acceleration.x == 0 ? Vector3.zero : Vector3.left);
        Vector3 roll = Mathf.Abs(acceleration.x) * speed * direction;

        transform.position += roll * Time.deltaTime;

        aircraft.eulerAngles += new Vector3(0, 0, -acceleration.y * 10) * Time.deltaTime;
    }

    private void PitchHandler()
    {
        Vector3 direction = acceleration.y > 0 ? Vector3.down : (acceleration.y == 0 ? Vector3.zero : Vector3.up);
        Vector3 pitch = Mathf.Abs(acceleration.y) * speed * direction;

        transform.position += pitch * Time.deltaTime;

        aircraft.eulerAngles += new Vector3(-acceleration.x * 10, 0, 0) * Time.deltaTime;
    }

    private void ThrustHandler()
    {
        Vector3 thrust = Vector3.forward * speed;

        transform.position += thrust * Time.deltaTime;
    }
}