using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform posisiPlayer;

    private void Update()
    {
        transform.position = posisiPlayer.position;
    }
}
