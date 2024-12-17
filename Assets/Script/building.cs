using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    public static event Action signalCandiTerbangun = delegate { };

    public GameObject candi;
    public GameObject candiInstance;

    bool modeMembangun;

    [Header("Palu")]
    public GameObject Palu;
    public bool bisaMembangun = true;
    public float cdMembangun = 0.5f;

    public AudioClip SuaraMaluSource;
    
    
    RaycastHit hit;

    private void Update()
    {
        if (modeMembangun)
        {
            candi.SetActive(true);

            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 25 ))
            {
                candi.transform.position = hit.point + new Vector3(0f, 6f, 0f);
                Debug.Log(hit.point + new Vector3(0f, 6f, 0f));

                if(Input.GetKeyDown(KeyCode.Mouse0) && bisaMembangun)
                {
                    Membangun();
                    signalCandiTerbangun();
                    StartCoroutine(ResetMaluCooldown());

                }
            }
        }
        else
        {
            candi.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            modeMembangun = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            modeMembangun = false;
        }

    }

    private void Membangun()
    {
        bisaMembangun = false;
        Animator anim = Palu.GetComponent<Animator>();
        AudioSource suaraMalu = GetComponent<AudioSource>();
        Instantiate(candiInstance, hit.point + new Vector3(0f, 6f, 0f), candi.transform.rotation);
        anim.SetTrigger("Serang");
        suaraMalu.PlayOneShot(SuaraMaluSource);
    }

    IEnumerator ResetMaluCooldown()
    {
        yield return new WaitForSeconds(cdMembangun);
        bisaMembangun = true ;
    }

}
