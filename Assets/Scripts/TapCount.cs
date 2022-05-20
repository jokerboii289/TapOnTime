using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TapCount : MonoBehaviour
{
    [SerializeField] GameObject parentPivot;
    public bool rotationSwapingInlvl;
    public static bool swap;
    int previous;

    [SerializeField] GameObject gemHolder;


    [SerializeField] GameObject endLess;
    [SerializeField] GameObject nonEndlessPanel;
    bool endless;
    [SerializeField] GameObject buttons;
    [SerializeField] TextMeshProUGUI endlessScore;
    int count;
    [SerializeField] TextMeshProUGUI highScore;


    [SerializeField] Slider slider;
    public static TapCount instance;
    [SerializeField] int tapCount;
    [SerializeField] TextMeshProUGUI textOfTapCount;
    [SerializeField] TextMeshProUGUI targetToTap;
    public static bool stop;
    float original;
    // Start is called before the first frame update
    void Start()
    {
        swap = false;
        nonEndlessPanel.SetActive(true);
        highScore.text = PlayerPrefs.GetInt("highscore").ToString();
        endLess.SetActive(false);
        count = 0;
        buttons.SetActive(true);
        endless = false;
        original = tapCount;
        stop = false;
        instance = this;
        targetToTap.text = tapCount.ToString();
        textOfTapCount.text = tapCount.ToString();
        slider.minValue = 0;
        slider.maxValue = tapCount;    
    }

    public void UpdateTapCount()  //levels
    {
        if(!endless)   // if not endless and it is played as levels
            tapCount--; 
        if (tapCount >= 0)
        {
            textOfTapCount.text = tapCount.ToString();
            slider.value =original-tapCount;
        }

        if(tapCount<=0)
        {
            PauseMenu.instance.Win();
            stop = true;
        }
        if(slider.value>0 )
        {
            buttons.SetActive(false);
        }
       
        if(tapCount==0)
        {
            gemHolder.SetActive(true);
        }

        SwapRotation();
    }

    //for endliess
    public void Endless()
    {
        endless = true;
        nonEndlessPanel.SetActive(false);
        endLess.SetActive(true);
    }

    public void UpdateEndlessScore()
    {
        if (endless)
        {
            count++;
            endlessScore.text = count.ToString();
            if (count > PlayerPrefs.GetInt("highscore"))
            {
                PlayerPrefs.SetInt("highscore", count);
                highScore.text = PlayerPrefs.GetInt("highscore").ToString();
            }

            if (count >0)
            {
                buttons.SetActive(false);
            }
        }
    }

    public void Levels()
    {
        endless = false;
        endLess.SetActive(false);
        nonEndlessPanel.SetActive(true);
    }

    void SwapRotation()
    {
        if(rotationSwapingInlvl)
        {
            if(RandomValue()==1)
            {
                swap = true;
                Piviot.instance.Alternate();
                parentPivot.GetComponent<Rotate>().enabled = false;

            }
            else
            {
                Piviot.instance.ReverseAlternate();
                parentPivot.GetComponent<Rotate>().enabled = true;
            }
        }

        Rotate.instance.RandomValue();
    }

    int RandomValue()
    {
        var value= Random.Range(0, 2);
       // print(value);
        if(previous==value)
        {
            RandomValue();
        }
        previous = value;
        return value;
    }
}
