using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GamePlayUIManager : MonoBehaviour
{
    [SerializeField] RecieveGameInformation info;
    [SerializeField] UIDocument _uiDocument;
    [SerializeField] int channel = 0;
    float frameRate = 30f;
    float lastTime = 0;
    Label scoreElement, subInfoElement;
    int uiScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreElement = _uiDocument.rootVisualElement.Q<Label>("Score");
        subInfoElement = _uiDocument.rootVisualElement.Q<Label>("SubInfo");
        
    }   

    // Update is called once per frame
    void Update()
    { 
        //scoreElement.text = info.score.ToString();

        switch(channel)
        {
            case 0:
                if(Time.time - lastTime > 1f / frameRate)
                {
                    uiScore ++;
                    lastTime = Time.time;
                }
                
                if(uiScore > info.score) uiScore = info.score;
                float radius = (info.enableFever)? 20f : 0f;

                scoreElement.style.fontSize = 60 + radius * Mathf.Sin(Time.time * 4.0f);
                
                scoreElement.text = uiScore.ToString();
                //❤ ❤ ❤ ❤ ❤ 
                string hitPointHeart = "";
                for(int i = 0; i < 5 - info.hitPoint; i ++)
                {
                    hitPointHeart += "❤";
                }

                subInfoElement.text = hitPointHeart;
            break;

            case 1:
                scoreElement.text = info.score.ToString() + "/ 5";
                subInfoElement.text = "Time: " + ((int)info.timeRemainf).ToString();
            break;

        }
        
    }
}
