using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public static Rotate instance;
    [SerializeField] float speed;
    [SerializeField] bool rotate;
    bool clock;

    private void Start()
    {
        clock = false;
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (rotate && !clock)
        {
            transform.RotateAround(transform.forward, speed * Time.deltaTime); //anticlock
        }
        if(rotate && clock)
        {
            transform.RotateAround(transform.forward, -speed * Time.deltaTime);  //clock
        }
    }
  
    public void RandomValue()
    {
        var value = Random.Range(0, 2);

        if (value == 1)
        {
            clock = true;
        }
        else
            clock = false;
    }
}
