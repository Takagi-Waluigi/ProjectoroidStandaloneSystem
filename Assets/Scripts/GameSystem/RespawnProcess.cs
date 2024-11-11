using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnProcess : MonoBehaviour
{
    [SerializeField] GameObject buttonObject;
    [SerializeField] RecieveGameInformation info;
    [SerializeField] float defaultScale = 0.3f;
    [SerializeField] float maxTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(!info.isGameOver)
        {            
            float scale = defaultScale;
            buttonObject.transform.localScale = Vector3.zero;          
        }
        else
        {     
            float scale = defaultScale - defaultScale * (info.decisionTime / maxTime);
            buttonObject.transform.localScale = new Vector3(scale, scale, scale);
            
        }

        
    }
}
