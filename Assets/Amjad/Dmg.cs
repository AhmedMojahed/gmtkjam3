using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dmg : MonoBehaviour
{
    public GameObject SpawnPosition;
    public Slider slider;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Acid")
        {
            Debug.Log("CColluided");
            LivesAndScore.LAS.TakeLife();
        }
    }

    private void Update()
    {
        if(this.transform.position.y < -8)
        {
            LivesAndScore.LAS.TakeLife();
        }

        if(this.transform.position.y < -8 && LivesAndScore.LAS.lives > 0)
        {
            this.transform.position = SpawnPosition.transform.position;
        }

        slider.value += 0.05f;

        /*if(slider.value >= 50)
        {
            Slider. Color.Lerp(Color.yellow, Color.red, 0.8f);
        }*/
    }
}
