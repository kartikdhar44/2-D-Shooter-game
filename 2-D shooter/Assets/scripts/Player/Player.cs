using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 speedfactor = new Vector3(1,0,0);
    [SerializeField] Vector3 jumpfactor = new Vector3(0,1,0);
    [SerializeField] GameObject camera;
    [SerializeField] GameObject bullet;
    [SerializeField] Quaternion rotation = new Quaternion(0, 0, 90, 0);
    [SerializeField] Vector3 offset = new Vector3(1, 0, 0);
    public GameObject asteroid;
    [SerializeField] float x = 0, y = 0;
    

    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position+offset;
        
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        
        float factor = Input.GetAxis("Horizontal");
        if (factor != 0)
        {
            gameObject.transform.position = gameObject.transform.position + speedfactor*factor;

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            rb.AddForce(jumpfactor, ForceMode2D.Impulse);
            rb.gravityScale = 1;
            
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(bullet,pos,rotation);
            
        }
       


    }
   void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hud = GameObject.FindGameObjectWithTag("hud");
        HUD hud2 = hud.GetComponent<HUD>();
        if (collision.gameObject.tag == "enemy")
        {
            hud2.health -= 25;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            hud2.health -= 50;
        }
        if (collision.gameObject.tag == "Platform")
        {
            Instantiate(asteroid, new Vector3(x, y, 0), rotation);
            
        }


    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Instantiate(asteroid, new Vector3(ScreenUtils.ScreenLeft - ScreenUtils.ScreenRight / 2, ScreenUtils.ScreenTop, 0), rotation);
            GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
            if (asteroids.Length < 5)
            {
                Instantiate(asteroid, new Vector3(x,y, 0), rotation);
            }
        }
    }

}
