using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        int randx = Random.Range(-5, 1);
        int randy = Random.Range(-5, 1);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new UnityEngine.Vector2(randx, randy), ForceMode2D.Impulse);


    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Destroy(gameObject);
    }
}
