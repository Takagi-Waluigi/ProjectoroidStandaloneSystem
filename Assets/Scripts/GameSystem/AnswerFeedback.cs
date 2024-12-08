using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerFeedback : MonoBehaviour
{
    [SerializeField] RecieveGameInformation info;
    [SerializeField] SpriteRenderer collectSprite;
    [SerializeField] SpriteRenderer wrongSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(info.matchStatus == 1)
        {
            wrongSprite.enabled = true;
        }
        else if(info.matchStatus == 2)
        {
            collectSprite.enabled = true;
        }
        else
        {
            wrongSprite.enabled = false;
            collectSprite.enabled = false;
        }
    }
}
