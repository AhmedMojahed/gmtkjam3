using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    //keep track of the game state

    public enum GameState
    {
        PREGAME,
        RUNNING,
        PAUSED
    }

    public Events.EventGameState OnGameStateChanged;


    #region Fields 
    //what level the game is currently in
    private string currentLevelName = string.Empty;
    private List<AsyncOperation> loadOperations;// to keep track of asyncOperations that happens


    public GameObject[] systemPrefabs;
    private List<GameObject> instancedSystemPrefabs;

    GameState currentGameState = GameState.PREGAME;
    public GameState CurrentGameState
    {
        get { return currentGameState; }
        private set { currentGameState = value; }
    }
    #endregion



    #region Initializations

    private void Start()
    {
        DontDestroyOnLoad(gameObject);// to make the game manager non distructable
        loadOperations = new List<AsyncOperation>();
        instancedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();

        UIManager.Instance.OnMainMenuFadeComplete.AddListener(HandleMainMenuComplete);
    }

    private void HandleMainMenuComplete(bool fadeOut)
    {
        if (!fadeOut)
        {
            Debug.Log(currentLevelName);
            UnLoadLevel(currentLevelName);
        }
    }
    #endregion

    private void Update()
    {
        if (currentGameState == GameState.PREGAME)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }


    // load and unload game levels 
    #region Level Management

    public void LoadLevel(string levelName)
    {
        // loadScene as async to let back groud operations finish
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (asyncOperation == null)
        {
            Debug.Log("unable to unload level " + levelName);
            return;
        }
        asyncOperation.completed += OnLoadOperationComplete;
        loadOperations.Add(asyncOperation);
        Debug.Log(currentLevelName);
        currentLevelName = levelName;
        Debug.Log(currentLevelName);

    }

    private void OnLoadOperationComplete(AsyncOperation asyncOperation)
    {
        if (loadOperations.Contains(asyncOperation))
        {
            loadOperations.Remove(asyncOperation);
            if (loadOperations.Count == 0)
            {
                UpdateState(GameState.RUNNING);
            }

            // things u can do 

        }
        Debug.Log("Load completed");
    }

    public void UnLoadLevel(string levelName)
    {
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(levelName);
        asyncOperation.completed += OnUnLoadOperationComplete;
    }

    private void OnUnLoadOperationComplete(AsyncOperation obj)
    {
        Debug.Log("UnLoad completed");
    }

    #endregion



    // generate other persistent systems
    #region Manage Systems

    private void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < systemPrefabs.Length; i++)
        {
            prefabInstance = Instantiate(systemPrefabs[i]);
            instancedSystemPrefabs.Add(prefabInstance);
        }
    }


    protected override void OnDestroy()
    {
        base.OnDestroy();

        for (int i = 0; i < instancedSystemPrefabs.Count; i++)
        {
            Destroy(instancedSystemPrefabs[i]);
        }

        instancedSystemPrefabs.Clear();
    }
    #endregion




    // keep track of the game state 
    #region Game States

    void UpdateState(GameState state)
    {
        GameState previeousGameState = currentGameState;
        currentGameState = state;
        switch (currentGameState)
        {
            case GameState.PREGAME:
                Time.timeScale = 1;
                break;
            case GameState.RUNNING:
                Time.timeScale = 1;
                break;
            case GameState.PAUSED:
                Time.timeScale = 0;
                break;
            default:
                break;
        }

        OnGameStateChanged.Invoke(currentGameState, previeousGameState);

        // dispatch messages
        // transitions between Scenes
    }

    public void StartGame()
    {
        LoadLevel("Main");
    }
    #endregion


    #region Pause Restart Quit
    public void TogglePause()
    {
        if (currentGameState == GameState.RUNNING)
        {
            UpdateState(GameState.PAUSED);
        }
        else if (currentGameState == GameState.PAUSED)
        {
            UpdateState(GameState.RUNNING);
        }

    }
    public void RestartGame()
    {
        UpdateState(GameState.PREGAME);
    }

    public void QuitGame()
    {
        // implement auto Save and other safeatures


        Application.Quit();
    }

    #endregion


}
