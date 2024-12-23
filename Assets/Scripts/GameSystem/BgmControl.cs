using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmControl : MonoBehaviour
{
    [SerializeField] RecieveGameInformation info;
    [SerializeField] AudioSource audioSource;
    bool lastIsGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.pitch = (info.enableFever)? 1.5f : 1.0f;
        if(lastIsGameOver && !info.isGameOver) audioSource.Play();
        if(info.isGameOver) audioSource.Stop();
    
        lastIsGameOver = info.isGameOver;
    }
}
