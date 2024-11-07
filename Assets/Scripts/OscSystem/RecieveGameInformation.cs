using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveGameInformation : MonoBehaviour
{
    public int score = 0;
    public int hitPoint = 0;
    public float timeRemainf = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveStaticGameInfo(Vector2Int info)
    {
        score = info.x;
        hitPoint = info.y;
        //Debug.Log("info log:" + info);
    } 

    public void RecieveRemainTimef(float info)
    {
        timeRemainf = info;
        //Debug.Log("time remain:" + info);
    }
}
