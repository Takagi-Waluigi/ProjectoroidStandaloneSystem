using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RecieveGameInformation : MonoBehaviour
{
    public int score = 0;
    public int hitPoint = 0;
    public bool isGameOver = false;
    public bool isTrackingUser = false;
    public float timeRemainf = 0f;
    public float decisionTime = 0f;
    public bool enableFever = false;
    public float feverAlpha = 0f;
    public bool isMemoryPhase = false;
    public int targetCardId = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecieveStaticGameInfo(Vector4 info)
    {
        score = (int)info.x;
        hitPoint = (int)info.y;
        isGameOver = ((int)info.z > 0);
        isTrackingUser = ((int)info.w > 0);
        
        
    } 

    public void RecieveRemainTimef(Vector4 info)
    {
        timeRemainf = info.x;
        decisionTime = info.y;

        var sceneName = SceneManager.GetActiveScene().name;

        if(sceneName == "PacMan")
        {
            enableFever = (int)info.z > 0;
            feverAlpha = info.w;
        }
        else
        {
            targetCardId = (int)info.z;
            isMemoryPhase = ((int)info.w > 0);

        }
       
        //Debug.Log("time remain:" + info);

       
    }
}
