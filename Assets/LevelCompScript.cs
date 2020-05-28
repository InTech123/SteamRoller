using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;
public class LevelCompScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gamePlayPanel;
    public GameObject levelCompPanel;
    bool levelcomp = false;
    public GameObject confetti;
    private void OnTriggerEnter(Collider other)
    {
        if (!levelcomp)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete,
Application.version, (PlayerPrefs.GetInt("LevelNo") + 1).ToString("00000"),100);
            StartCoroutine("LevelComplete");
            levelcomp = true;
        }
    }

    IEnumerator LevelComplete()
    {
        confetti.SetActive(true);
        yield return new WaitForSeconds(2f);
        gamePlayPanel.SetActive(false);
        levelCompPanel.SetActive(true);
    }



}
