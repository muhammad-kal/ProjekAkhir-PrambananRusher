using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiangMalam : MonoBehaviour
{
    public Light cahaya;
    public GameObject waktu;
    public GameObject batasWaktu;
    public Material Pagi;
    public Material Malam;

    private void Start()
    {
        //KeMalam();
    }

    private void Update()
    {
        if (cahaya.intensity > 0.5f)
        {
            KePagi();
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
