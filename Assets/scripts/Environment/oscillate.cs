using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillate : MonoBehaviour
{
    
    [SerializeField] float period = 2f;
    float movementfactor;
    [SerializeField] Vector3 movementvector;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    
    void Update()
    {
        if (period <= Mathf.Epsilon)
        { return; }

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawsinewave = Mathf.Sin(cycles * tau);
        movementfactor = rawsinewave / 2f;
        Vector3 offset = movementvector * movementfactor;
        transform.position = startingPos + offset;

    }
        
    
}
