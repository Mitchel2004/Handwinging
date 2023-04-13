using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ringsValue;

    private int rings;

    public void AddRing()
    {
        rings++;
        ringsValue.text = rings.ToString();
    }
}