using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;

    void Start()
    {
        pauseCanvas.enabled = false;
    }

    void Update()
    {
        PauseMenu();
    }

    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.enabled = true;
        }
    }

    public void EnablePauseCanvas(bool enabled)
    {
        pauseCanvas.enabled = enabled;
    }
}
