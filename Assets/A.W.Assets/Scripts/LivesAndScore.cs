using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LivesAndScore : MonoBehaviour
{
    [SerializeField] int score = 200; 
    [HideInInspector]public int lives = 3;
    [SerializeField] TextMeshProUGUI livesText;

    public static LivesAndScore LAS;
    // Start is called before the first frame update
    void Start()
    {
        

        if(!LAS)
        {
            LAS = this;
        }
    }

    private void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        //scoreText.text = score.ToString();
        livesText.text = lives.ToString();
    }

    //public void AddToScore(int scoreToAdd)
    //{
    //    score += scoreToAdd;
    //    UpdateText();
    //}

    public void TakeLife()
    {
        lives--;
        if(lives == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
