using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChangeInform : MonoBehaviour
{
    [SerializeField] RecieveGameInformation info;
    [Header("音源設定")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip targetChangeSoundEffect;
    int lastTargetCardId  = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastTargetCardId != info.targetCardId)
        {
            audioSource.PlayOneShot(targetChangeSoundEffect);
        }
        lastTargetCardId = info.targetCardId;
    }
}
