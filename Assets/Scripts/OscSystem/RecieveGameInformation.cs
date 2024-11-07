using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveGameInformation : MonoBehaviour
{
    public int score = 0;
    public int hitPoint = 0;
    public bool isGameOver = false;
    public float timeRemainf = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveStaticGameInfo(Vector3 info)
    {
        score = (int)info.x;
        hitPoint = (int)info.y;
        isGameOver = ((int)info.z > 0);
    } 

    public void RecieveRemainTimef(float info)
    {
        timeRemainf = info;
        //Debug.Log("time remain:" + info);
    }
}
