using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawning : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform.position.z > transform.position.z + 10)
        {
            Time.timeScale = 0;

            gameOverScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("UI").GetComponent<DrawText>().AddRing();

        float randomX = Random.Range(-28.6f, 28.6f);
        float randomY = Random.Range(2.2f, 57.2f);

        GameObject newRing = Instantiate(gameObject);
        newRing.transform.position = new Vector3(randomX, randomY, transform.position.z + 55);

        Destroy(gameObject);
    }
}