using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float waktu;
    public float BatasWaktu;
    public Text WaktuTeks;
    public Image Fill;
    public bool RestartKalah = true;
    

    [Header("Intensitas Cahaya")]
    public Light cahaya;
    public Material Pagi;
    public Material Malam;


    private void Start()
    {
        
    }

    private void Update()
    {
        cahayaIntensitas();
    }

    private void cahayaIntensitas()
    {
        waktu -= Time.deltaTime;
        WaktuTeks.text = "" + (int)waktu;
        Fill.fillAmount = waktu / BatasWaktu;

        if (waktu < 0)
        {
            waktu = 0;
            if (RestartKalah)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        MagribTimer();

        if (waktu < BatasWaktu / 3)
        {

            KePagi();
        }

    }

    private void MagribTimer()
    {
        //  float inversCahaya = Mathf.InverseLerp(0, BatasWaktu, waktu);
        //print(inversCahaya);
        cahaya.intensity = 1-(waktu/BatasWaktu);
        if (cahaya.intensity < 0)
        {
            cahaya.intensity = 0;
        }
    }

    private void KeMalam()
    {
        RenderSettings.skybox = Malam;
    }
    private void KePagi()
    {
        RenderSettings.skybox = Pagi;
    }

}
