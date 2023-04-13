using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawning : MonoBehaviour
{
    private DrawText UI;

    private void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<DrawText>();
    }

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform.position.z > transform.position.z + 10)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UI.AddRing();

        float randomX = Random.Range(-27.5f, 27.5f);
        float randomY = Random.Range(11f, 55f);

        GameObject newRing = Instantiate(gameObject);
        newRing.transform.position = new Vector3(randomX, randomY, transform.position.z + 44);

        Destroy(gameObject);
    }
}