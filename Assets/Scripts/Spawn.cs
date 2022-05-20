using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject ShockWave;//effect
    bool canSpawn;
    [SerializeField] GameObject[] typeTapPoint;
    // Start is called before the first frame update
    public static Spawn instance;
    float previousAngle;
    // Start is called before the first frame update
 
    void Start()
    {
        canSpawn = true;
        instance = this;
    }
    private void Update()
    {
        if (canSpawn && !TapCount.stop)
        {
            typeTapPoint[RandomWidthSpots()].SetActive(true);
            canSpawn = false;
        }
    }
    public void SetAngle()
    {
        var rand=RandomValue();
        transform.eulerAngles = new Vector3(0, 0,rand);
    }
    int RandomWidthSpots()
    {
        var rand = Random.Range(0,typeTapPoint.Length);
        return rand;
    }

    public void CanSpawn()
    {
        canSpawn = true;
    }
    float RandomValue()
    {
        var rand = Random.Range(0, 360);
        while(rand==previousAngle)
        {
            RandomValue();
        }
        previousAngle = rand;
        return rand;
    }
    public void Effect(Vector3 position)//effect
    {
        var obj = ObjectPooling.instance.GetFromPool(ShockWave);
        if(obj!=null)
        {
            obj.transform.position = new Vector3(position.x,position.y,-3f);
        }
    }
}
