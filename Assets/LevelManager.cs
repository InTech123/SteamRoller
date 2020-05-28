using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameAnalyticsSDK;
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] levels;
    public TextMeshProUGUI LevelText;
    public Slider progress;
    void Start()
    {
        GameAnalytics.Initialize();
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 0);
            PlayerPrefs.SetInt("LevelNo", 0);
        }

        LevelText.text = "Level " + (PlayerPrefs.GetInt("LevelNo") + 1).ToString();


        if(PlayerPrefs.GetInt("LevelNo") < 5){
            levels[PlayerPrefs.GetInt("Level")].SetActive(true);

        }
        else
        {
            int rand = Random.Range(0, 5);
            levels[rand].SetActive(true);

        }
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start,
Application.version, (PlayerPrefs.GetInt("LevelNo")+1).ToString("00000"));
    }

    // Update is called once per frame
    void Update()
    {
        progress.value = Mathf.Abs(GameObject.FindGameObjectWithTag("target").transform.localPosition.x);
    }
}
