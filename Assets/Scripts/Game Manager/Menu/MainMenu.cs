using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Function that can recive animation events
    // function to play fade animations
    #region Fields

    // track the animation component
    // track animation clip for fade in/out
    [SerializeField] private Animation mainMenuAnimator;
    [SerializeField] private AnimationClip fadeOutAnimation;
    [SerializeField] private AnimationClip fadeInAnimation;
    public Events.EventFadeComplete OnMainMenuFadeComplete;
    
    #endregion

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }



    #region Animation

    public void OnFadeOutComplete()
    {
        OnMainMenuFadeComplete.Invoke(true);
    }

    public void OnFadeInComplete()
    {
        OnMainMenuFadeComplete.Invoke(false);

        UIManager.Instance.SetDummyCameraActive(true);

    }

    public void FadeIn()
    {
        mainMenuAnimator.Stop();
        mainMenuAnimator.clip = fadeInAnimation;
        mainMenuAnimator.Play();

    }

    public void FadeOut()
    {
        UIManager.Instance.SetDummyCameraActive(false);
        mainMenuAnimator.Stop();
        mainMenuAnimator.clip = fadeOutAnimation;
        mainMenuAnimator.Play();

    }
    #endregion


    #region handleEvents
    void HandleGameStateChanged(GameManager.GameState currentGameState, GameManager.GameState previousGameState)
    {
        if(previousGameState == GameManager.GameState.PREGAME && currentGameState == GameManager.GameState.RUNNING)
        {
            FadeOut();
        }
        if(previousGameState != GameManager.GameState.PREGAME && currentGameState == GameManager.GameState.PREGAME)
        {
            FadeIn();
        }
    }
    #endregion
}
