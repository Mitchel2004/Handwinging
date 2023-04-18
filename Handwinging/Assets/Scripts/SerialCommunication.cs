using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using UnityEngine;

public class SerialCommunication : MonoBehaviour
{
    public SerialPort stream = new SerialPort();

    public bool connected;
    public Vector3 acceleration;

    private void Start()
    {
        if(SerialPort.GetPortNames().Length > 0)
        {
            foreach(string port in SerialPort.GetPortNames())
            {
                stream.PortName = port;
                stream.BaudRate = 115200;

                stream.Open();

                if(stream.ReadLine().Split(',').Length == 3)
                {
                    break;
                }
                else
                {
                    stream.Close();
                }
            }
        }
        else
        {
            Debug.Log("Receiver Not Found");
        }
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
                    connected = true;
                }
                catch(FormatException)
                {
                    Debug.Log("Parsing Failed");

                    connected = false;
                }
            }
            else
            {
                connected = false;
            }
        }
    }
}