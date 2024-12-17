using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerCamera : MonoBehaviour
{
    public float sensiY;
    public float sensiX;

    public Transform lokasiPlayer;

    float rotasiX;
    float rotasiY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensiX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensiY;

        rotasiY += mouseX;
        rotasiX -= mouseY;
        rotasiX = Mathf.Clamp(rotasiX, -90f, 90f);

        //rotasi
        transform.rotation = Quaternion.Euler(rotasiX, rotasiY, 0);
        lokasiPlayer.rotation = Quaternion.Euler(0, rotasiY, 0);
    }

    
}
