using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Vfx : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] windows;
    int count=0;

    public AudioClip cansound1, cansound2;
   public  AudioSource aud;
    public AudioSource carsound;

    public void PlayCanSound1()
    {
        aud.PlayOneShot(cansound1);
    }

    public void PlayCanSound2()
    {
        aud.PlayOneShot(cansound2);

    }

    public void BreakGlass1()
    {
        if (count <= windows.Length)
        {
            //windows[count].SetActive(true);
            
            windows[count].GetComponent<BreakableWindow>().breakWindow();
            count++;
        }
    }

    public void PlayCarSound()
    {
        if(!carsound.isPlaying)
        carsound.Play();
    }
    public void StopCarSound()
    {

        carsound.Stop();

    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (carsound != null)
                Invoke("StopCarSound", 1f);
        }
    }

}
