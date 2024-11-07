using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GamePlayUIManager : MonoBehaviour
{
    [SerializeField] RecieveGameInformation info;
    [SerializeField] UIDocument _uiDocument;
    Label scoreElement, hitPointElement;
    // Start is called before the first frame update
    void Start()
    {
        scoreElement = _uiDocument.rootVisualElement.Q<Label>("Score");
        hitPointElement = _uiDocument.rootVisualElement.Q<Label>("HitPoint");
        
    }   

    // Update is called once per frame
    void Update()
    { 
        //❤ ❤ ❤ ❤ ❤ 
        scoreElement.text = info.score.ToString();

        string hitPointHeart = "";
        for(int i = 0; i < 5 - info.hitPoint; i ++)
        {
            hitPointHeart += "❤";
        }

        hitPointElement.text = hitPointHeart;
    }
}
