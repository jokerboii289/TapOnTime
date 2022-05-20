using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Piviot : MonoBehaviour
{
    [SerializeField] GameObject player;

    public static Piviot instance;
    
    [SerializeField] float secondRotateSpeed;
    [SerializeField] float rotateSpeed;
    float tempSpeedHolder;

    [SerializeField] GameObject ring;
    bool increaseSize;

    bool enableSwap;
    private void Start()
    {
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;
        instance = this;
        increaseSize = false;
        tempSpeedHolder = rotateSpeed;
        enableSwap = false;
    }
    void Update()
    {

        if (!enableSwap)
        {
            transform.RotateAround(transform.forward, -tempSpeedHolder * Time.deltaTime);
        }
        else
        {
            transform.RotateAround(transform.forward, tempSpeedHolder * Time.deltaTime);
        }
       
        if(increaseSize)
        {
            ring.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f),.5f);
        }
    }

    public void SetSpeed()
    {
        tempSpeedHolder = secondRotateSpeed;
        IncreaseSizeOfRing();
    }
    void IncreaseSizeOfRing()
    {
        increaseSize = true;
    }

    public void Alternate()//alternate direction and rotaion of player
    {
        player.transform.localEulerAngles = transform.forward * 24;
        enableSwap = true;
    }

    public void ReverseAlternate()
    {
        player.transform.localEulerAngles = transform.forward * -156.67f;
        enableSwap = false;
    }
}
