using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Camera dummyCamera;
    [SerializeField] private PauseMenu pauseMenu;
    public Events.EventFadeComplete OnMainMenuFadeComplete;

    private void Start()
    {
        mainMenu.OnMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }

    private void HandleMainMenuFadeComplete(bool fadeOut)
    {
        OnMainMenuFadeComplete.Invoke(fadeOut);
    }

    void HandleGameStateChanged(GameManager.GameState currentGameState, GameManager.GameState previousGameState)
    {
        pauseMenu.gameObject.SetActive(currentGameState == GameManager.GameState.PAUSED);
    }
    private void Update()
    {
        if (GameManager.Instance.CurrentGameState != GameManager.GameState.PREGAME)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //mainMenu.FadeOut();
            GameManager.Instance.StartGame();
        }
    }


    public void SetDummyCameraActive(bool active)
    {
        dummyCamera.gameObject.SetActive(active);
    }
}
