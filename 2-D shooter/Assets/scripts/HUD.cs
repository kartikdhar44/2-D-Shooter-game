using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
   public int lives = 3;
    public int health = 100;
    

    [SerializeField] Text text1;
    [SerializeField] Text text2;
    [SerializeField] Text text3;
    
    
    
    void Start()
    {
        
    }


    void Update()
    {
        if (lives == 0)
        {
            text3.text = "GAME" + "OVER";
            Application.Quit();
            
        }
        text1.text = "LIVES:" + lives.ToString();
        text2.text = "Health:" + health.ToString();
        if (health == 0)
        {
            health = 100;
            lives = lives - 1;
        }
        

    }
}
