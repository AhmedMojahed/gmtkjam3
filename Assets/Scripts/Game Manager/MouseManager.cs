using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{

    public Texture2D pointer;

    private bool useDefaultCursor = false;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }
    void HandleGameStateChanged(GameManager.GameState currentGameState, GameManager.GameState previousGameState)
    {
        useDefaultCursor = currentGameState == GameManager.GameState.PAUSED;
    }
    void Update()
    {
        if (useDefaultCursor)
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
            return;
        }
    }
}

