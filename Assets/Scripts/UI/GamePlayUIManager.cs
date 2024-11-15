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
    Label scoreElement, subInfoElement;
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
                scoreElement.text = info.score.ToString();
                //❤ ❤ ❤ ❤ ❤ 
                string hitPointHeart = "";
                for(int i = 0; i < 5 - info.hitPoint; i ++)
                {
                    hitPointHeart += "❤";
                }

                subInfoElement.text = hitPointHeart;
            break;

            case 1:
                scoreElement.text = info.score.ToString();
                subInfoElement.text = "Time: " + info.timeRemainf.ToString("f2");
            break;

        }
        
    }
}
