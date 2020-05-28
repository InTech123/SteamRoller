using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
public class RollerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject startPanel;
    public GameObject gamePlayPanel;
    bool isGamestarted;
    void Start()
    {
        anim = GetComponent<Animator>();
        isGamestarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isGamestarted)
            {
                isGamestarted = true;
                startPanel.SetActive(false);
                gamePlayPanel.SetActive(true);
            }
        }
        float inp = CnInputManager.GetAxis("Horizontal");

        inp = inp.Remap(-50, 50, -1, 1);
        inp *= 5f;
        if (inp > 1)
        {
            inp = 1;
        }
        if(inp>=0)


            if (Input.GetMouseButton(0))
            {
                anim.SetFloat("speed", 0.8f);

            }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetFloat("speed", 0f);

        }
        //Debug.Log(inp);
    }

    public void NextButton()
    {
        Application.LoadLevel(Application.loadedLevel);
        PlayerPrefs.SetInt("LevelNo", PlayerPrefs.GetInt("LevelNo") + 1);

        if (PlayerPrefs.GetInt("Level") < 4)
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

        }
        else
        {
            PlayerPrefs.SetInt("Level",0);
        }
    }
}
