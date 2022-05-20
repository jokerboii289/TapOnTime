using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributeGems : MonoBehaviour
{
    [SerializeField] GameObject gem;
    
    [SerializeField] int noOfGems;
    [SerializeField] float radius;
    float spacebetweenGems;
    [SerializeField] Transform posToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        DisplayGems();
    }

    void DisplayGems()
    {
        float count = 0;
        spacebetweenGems = 360 / noOfGems;
        print(spacebetweenGems);
        for (int i = 0; i < noOfGems; i++)
        {
            count = spacebetweenGems * i;
            transform.eulerAngles = Vector3.forward * count;
          
            Instantiate(gem,posToSpawn.position,Quaternion.identity);          
        }
    }
}
