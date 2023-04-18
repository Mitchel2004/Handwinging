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

            float newPitch = currentPitch + acceleration.y * rotationSpeed * Time.deltaTime;
            float newRoll = currentRoll + acceleration.x * rotationSpeed * Time.deltaTime;

            if(acceleration.y < 1 && acceleration.y > -1 && currentPitch > 0.5f)
            {
                newPitch = currentPitch - 1 * Mathf.Pow(rotationSpeed, 2) * Time.deltaTime;
            }
            else if(acceleration.y < 1 && acceleration.y > -1 && currentPitch < -0.5f)
            {
                newPitch = currentPitch + 1 * Mathf.Pow(rotationSpeed, 2) * Time.deltaTime;
            }

            if(acceleration.x < 1 && acceleration.x > -1 && currentRoll > 0.5f)
            {
                newRoll = currentRoll - 1 * Mathf.Pow(rotationSpeed, 2) * Time.deltaTime;
            }
            else if(acceleration.x < 1 && acceleration.x > -1 && currentRoll < -0.5f)
            {
                newRoll = currentRoll + 1 * Mathf.Pow(rotationSpeed, 2) * Time.deltaTime;
            }

            currentPitch = Mathf.Clamp(newPitch, -45, 45);
            currentRoll = Mathf.Clamp(newRoll, -45, 45);

            transform.position += speed * Time.deltaTime * new Vector3(currentRoll / rotationSpeed, -currentPitch / rotationSpeed, rotationSpeed);
            aircraft.rotation = Quaternion.Euler(currentPitch, 0, -currentRoll);
        }
    }
}