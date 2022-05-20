using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] int gemPoints;
    Transform gemIcon;
    Vector2 pos;
    bool canAnimate;

    private void Start()
    {
        canAnimate = false;
        gemIcon= GameObject.FindGameObjectWithTag("gemIcon").transform;
        pos = Camera.main.ScreenToWorldPoint(gemIcon.transform.position);
      
    }
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.forward, -5f * Time.deltaTime);
        if(canAnimate)
        {
            Animate();
        }
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Vibration.Vibrate(30);
            AudioManager.instance.Play("gems");
            canAnimate = true;
        }
        if(collision.gameObject.CompareTag("gemiconcollider"))
        {
            GemIconCollider.instance.GemPointsUpdate(gemPoints);
            gameObject.SetActive(false);
        }
    }

    void Animate()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(pos.x, pos.y), 9*Time.deltaTime);
    }
}
