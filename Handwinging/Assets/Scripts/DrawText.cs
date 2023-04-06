using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI throttleText;
    private float throttle;

    private void Start()
    {
        throttle = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().throttle;
    }

    private void Update()
    {
        throttleText.text = $"THR: {(int)(throttle * 100)}%";
    }
}