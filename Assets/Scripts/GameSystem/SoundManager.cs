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
    [SerializeField] AudioClip hitSoundEffect;
    [SerializeField] AudioClip gameOverSoundEffect;
    int lastScore = 0;
    int lastHitPoint = 0;
    bool lastGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!info.isGameOver && info.score != lastScore) audioSource.PlayOneShot(scoreUpSoundEffect);
        if(!info.isGameOver && info.hitPoint != lastHitPoint) audioSource.PlayOneShot(hitSoundEffect);
        if(info.isGameOver != lastGameOver && info.isGameOver) audioSource.PlayOneShot(gameOverSoundEffect);

        lastScore = info.score;
        lastHitPoint = info.hitPoint;
        lastGameOver = info.isGameOver;
    }
}
