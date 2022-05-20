using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject slider;
    int count;
    [SerializeField] GameObject winpanel;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject player;
    public static PauseMenu instance;
    // Start is called before the first frame update
    void Start()
    {
        slider.SetActive(true);
        winpanel.SetActive(false);
        failPanel.SetActive(false);
        count = 0;
        instance = this;
        if (PlayerPrefs.GetInt("Index") == SceneManager.sceneCountInBuildSettings)
        {
            levelText.text = (PlayerPrefs.GetInt("IndexNo")).ToString();
        }
        Vibration.Init();
    }

    
    public void Fail()
    {
        if (count < 1)
        {
            Vibration.Vibrate(30); 
            player.SetActive(false);
            StartCoroutine(DelayFail());
        }
        count++;
    }

    public void Win()
    {
        StartCoroutine(DelayWin());
    }

    IEnumerator DelayWin()
    {
        slider.SetActive(false);
        yield return new WaitForSeconds(4f);
        AudioManager.instance.Play("win");
        winpanel.SetActive(true);
    }

    IEnumerator DelayFail()
    {
        slider.SetActive(false);
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Play("fail");
        failPanel.SetActive(true);
    }

    public void NextLvl()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (PlayerPrefs.GetInt("Index") == SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("IndexNo", (PlayerPrefs.GetInt("IndexNo") + 1));//save index no for looping;
            SceneManager.LoadScene("FirstScene");
        }
        if (PlayerPrefs.GetInt("Index") < SceneManager.sceneCountInBuildSettings)
        {
            Time.timeScale = 1;
            //save level index
            PlayerPrefs.SetInt("Index", (SceneManager.GetActiveScene().buildIndex) + 1);
            PlayerPrefs.SetInt("IndexNo", SceneManager.GetActiveScene().buildIndex);//save index no for looping;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }
}
