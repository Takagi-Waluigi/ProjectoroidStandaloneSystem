using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("ゲームオブジェクト設定")]
    [SerializeField] RecieveGameInformation info;
    [Header("音源設定")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip scoreUpSoundEffect;
    [SerializeField] AudioClip scoreUpFeverSoundEffect;
    [SerializeField] AudioClip hitSoundEffect;
    [SerializeField] AudioClip gameOverSoundEffect;
    [SerializeField] AudioClip wrongSoundEffect;
    int lastScore = 0;
    int lastHitPoint = 0;
    bool lastGameOver = false;
    int lastMatchStatus = 0;
    float pitch = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!info.isGameOver && info.score != lastScore) 
        {
            if(info.enableFever)
            {
                audioSource.PlayOneShot(scoreUpFeverSoundEffect);
            }
            else
            {
                audioSource.PlayOneShot(scoreUpSoundEffect);
            }            
        }
        if(!info.isGameOver && info.hitPoint != lastHitPoint) audioSource.PlayOneShot(hitSoundEffect);
        if(info.isGameOver != lastGameOver && info.isGameOver) audioSource.PlayOneShot(gameOverSoundEffect);
        if(info.matchStatus == 1 && lastMatchStatus == 0) audioSource.PlayOneShot(wrongSoundEffect);
        
        lastScore = info.score;
        lastHitPoint = info.hitPoint;
        lastGameOver = info.isGameOver;
        lastMatchStatus = info.matchStatus;
    }
}
