using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappingPoints : MonoBehaviour
{
    bool canDestroy;
    float screenSize;

    private void OnEnable()
    {
        Spawn.instance.SetAngle();
    }
    private void Start()
    {
        screenSize =( Screen.height/3 )*2;
        canDestroy = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && Input.GetTouch(0).position.y<screenSize)
        {
    
            if (canDestroy)
            {
                StartCoroutine(Delay());
            }
            else if (!canDestroy)
            {
                PauseMenu.instance.Fail();// cannot destroy the charger
            }
        }
    }
    IEnumerator Delay()
    {
        AudioManager.instance.Play("tap"); //sound
        Spawn.instance.Effect(transform.position);
        TapCount.instance.UpdateTapCount(); //lvl score
        TapCount.instance.UpdateEndlessScore();//endless score
        Piviot.instance.SetSpeed();
        yield return new WaitForSeconds(0f);
        Spawn.instance.CanSpawn();
        gameObject.SetActive(false); //disable
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
            canDestroy = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
            canDestroy = false;
    }
}
