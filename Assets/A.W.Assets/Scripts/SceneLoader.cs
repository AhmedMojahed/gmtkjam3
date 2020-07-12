using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Image fadeOutImage;

    [SerializeField] float timeToWait = 1f;
    int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitAndLoad());
        }
        else if (currentSceneIndex == 2 && fadeOutImage)
        {
            fadeOutImage.canvasRenderer.SetAlpha(1f);
            fadeOut();
        }
    }

    private void fadeOut()
    {
        fadeOutImage.CrossFadeAlpha(0, 3, false);
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        FindObjectOfType<PauseCanvas>().EnablePauseCanvas(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
