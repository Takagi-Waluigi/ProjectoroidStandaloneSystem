using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSoundControl : MonoBehaviour
{
    [Header("ゲームオブジェクト設定")]
    [SerializeField] Transform userTransform;
    [Header("音源設定")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip footStepSoundEffect;
    [SerializeField] float frameRate = 1f;
    [SerializeField] float threshold = 0.5f;
    float lastTime = 0;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastTime > 1f/ frameRate)
        {
            float distance = Vector3.Distance(userTransform.position, lastPosition);
            if(distance > threshold)
            {
                audioSource.PlayOneShot(footStepSoundEffect);
            }
            
            lastPosition = userTransform.position;
            lastTime = Time.time;
        }
    }
}
