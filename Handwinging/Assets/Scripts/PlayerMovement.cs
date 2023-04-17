using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private Transform aircraft;
    private Vector3 acceleration;

    private float currentPitch;
    private float currentRoll;

    private void Start()
    {
        aircraft = GameObject.FindGameObjectWithTag("Aircraft").transform;
    }

    private void Update()
    {
        if(GetComponent<SerialCommunication>().connected)
        {
            acceleration = GetComponent<SerialCommunication>().acceleration;

            float newPitch = currentPitch + acceleration.y * Time.deltaTime;
            float newRoll = currentRoll + acceleration.x * Time.deltaTime;

            currentPitch = Mathf.Clamp(newPitch, -45, 45);
            currentRoll = Mathf.Clamp(newRoll, -45, 45);

            transform.position += speed * Time.deltaTime * new Vector3(currentRoll, -currentPitch, rotationSpeed);
            aircraft.rotation = Quaternion.Euler(newPitch * rotationSpeed, 0, -newRoll * rotationSpeed);
        }
    }
}