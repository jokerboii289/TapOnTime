using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemIconCollider : MonoBehaviour
{
    public static GemIconCollider instance;
    [SerializeField] GameObject ui;
    [SerializeField] TextMeshProUGUI gemPoints;
    int points;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gemPoints.text = PlayerPrefs.GetInt("gemPoints").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.ScreenToWorldPoint(ui.transform.position);
        var x = pos.x;
        var y = pos.y;
        transform.position = new Vector2(x,y);
    }


    public void GemPointsUpdate(int pts)
    {
        //points+=pts;
        PlayerPrefs.SetInt("gemPoints",PlayerPrefs.GetInt("gemPoints") + pts);
        gemPoints.text = PlayerPrefs.GetInt("gemPoints").ToString();
    }
}
