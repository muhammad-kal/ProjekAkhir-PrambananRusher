using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Kontrol")]
    public KeyCode TombolLompat = KeyCode.L;

    [Header("Movement Player")]
    public float kecepatan;
    public Transform playerTR;

    public float groundDrag;

    public float kekuatanLompat;
    public float cooldownLompat;
    public float airMultiplier;
    bool siapLompat = true;

    [Header("Grounded-nggak?")]
    public float playerHeight;
    public LayerMask LayerTanah;
    bool diTanah;



    float inputH;
    float inputV;

    Vector3 arahBergerak;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        InputKeyboard();
        BatasKecepatan();

        //cek diTanah atau nggak
        diTanah = Physics.Raycast(transform.position,Vector3.down, playerHeight * 0.5f + 0.2f, LayerTanah);
        if (diTanah)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        Lari();
        Bergerak();
    }

    private void InputKeyboard()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        inputV = Input.GetAxisRaw("Vertical");

        //lompat
        if(Input.GetKey(TombolLompat) && siapLompat && diTanah)
        {
            siapLompat = false;

            Lompat();

            Invoke(nameof(ResetLompat), cooldownLompat);
        }
    }

    private void Bergerak()
    {
        arahBergerak = playerTR.forward * inputV + playerTR.right * inputH;
        
        //ditanah
        if(diTanah)
            rb.AddForce(arahBergerak * kecepatan * 10f, ForceMode.Force);
        else if(!diTanah)//di udara
            rb.AddForce(arahBergerak * kecepatan * 10f * airMultiplier, ForceMode.Force);
    }

    private void BatasKecepatan()
    {
        Vector3 kecepatanAwal = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (kecepatanAwal.magnitude > kecepatan)
        {
            Vector3 batasKecepatan = kecepatanAwal.normalized * kecepatan;
            rb.velocity = new Vector3(batasKecepatan.x, rb.velocity.y, batasKecepatan.z);
        }
    }

    private void Lompat()
    {
        //reset posisi y pler
        rb.velocity = new Vector3(rb.velocity.x ,0f, rb.velocity.z);

        rb.AddForce(transform.up * kekuatanLompat, ForceMode.Impulse);

    }

    private void Lari()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            kecepatan = 18f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            kecepatan = 10f;
            
        }
    }

    private void ResetLompat()
    {
        siapLompat = true;
    }

}
