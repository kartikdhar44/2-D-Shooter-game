using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] UnityEngine.Vector2 force = new UnityEngine.Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        gameObject.AddComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
