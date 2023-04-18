using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Restart()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SerialCommunication>().stream.Close();

        SceneManager.LoadSceneAsync(0);
    }

    public void Quit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<SerialCommunication>().stream.Close();

        Application.Quit();
    }
}