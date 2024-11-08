using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCountScore : MonoBehaviour
{     
    GameObject stateManagerObject = null;  
    bool isHit = false; //True:未取得状態 False:取得済み状態
    bool lastIsGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        stateManagerObject = GameObject.Find("GameStateManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(lastIsGameOver && !stateManagerObject.GetComponent<RecieveGameInformation>().isGameOver) isHit = false;

        this.gameObject.GetComponent<Renderer>().enabled = !isHit;
        this.gameObject.GetComponent<Collider>().enabled = !isHit;

        lastIsGameOver = stateManagerObject.GetComponent<RecieveGameInformation>().isGameOver;
    }

    void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.name == "Character" && stateManagerObject.GetComponent<RecieveGameInformation>().isTrackingUser)
       {            
            //コイン取得済みフラグをTrueに
            isHit = true;
       }
        
               
    }
}
