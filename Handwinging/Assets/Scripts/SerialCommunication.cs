using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using UnityEngine;

public class SerialCommunication : MonoBehaviour
{
    private SerialPort stream = new SerialPort();

    public Vector3 acceleration;

    private void Start()
    {
        stream.PortName = "COM4";
        stream.BaudRate = 115200;

        stream.Open();
    }

    private void Update()
    {
        if(stream.BytesToRead > 0)
        {
            string[] data = stream.ReadLine().Split(',');

            if(data.Length == 3)
            {
                try
                {
                    float accelX = float.Parse(data[0], CultureInfo.InvariantCulture);
                    float accelY = float.Parse(data[1], CultureInfo.InvariantCulture);
                    float accelZ = float.Parse(data[2], CultureInfo.InvariantCulture);

                    acceleration = new Vector3(accelX, accelY, accelZ);
                }
                catch(FormatException)
                {
                    Debug.Log("Parsing Failed");
                }
            }
        }
    }
}