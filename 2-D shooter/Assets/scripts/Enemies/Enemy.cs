using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 factor = new Vector3(1, 0, 0);
    int sign = 1;
    Vector3 startingPos;
    int Ehealth = 2;
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + factor*sign*Time.deltaTime;
        if(transform.position.x-startingPos.x>42)
        {
            sign *= -1;
        }
        if (transform.position.x - startingPos.x < 0.1)
        {
            sign = 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Ehealth -= 1;
            if (Ehealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
