using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(-200)]
public class GameLoader : MonoBehaviour
{
    public void StartGame()
    {   
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMenu()
    {
        Destroy(FindObjectOfType<GameManager>().gameObject);
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        StartCoroutine(LoadGameOverDelay(1f));
    }

    IEnumerator LoadGameOverDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene("GameOver");
    }
}
