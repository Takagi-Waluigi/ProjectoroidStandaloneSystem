using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveTransform : MonoBehaviour
{
    [SerializeField] float deactivateTime = 2f;
    [SerializeField] bool isForScreenBlind = false;
    public bool isReciveingInfo = false;
    bool _isReciveingInfo = false;
    float falseTime = 0;
    float fixedHeight = 0f;
    // Start is called before the first frame update
    void Start()
    {
        fixedHeight = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isReciveingInfo)
        {
            falseTime += Time.deltaTime;
        }
        else
        {
            falseTime = 0f;
        }

        isReciveingInfo = falseTime < deactivateTime;
        _isReciveingInfo = false;

    }

    public void RecivePosition(Vector3 position)
    {
        if(isForScreenBlind) position.y = fixedHeight;

        this.gameObject.transform.position = position;
        _isReciveingInfo = true;
    } 

    public void RecieveRotation(Vector3 eulerAngles)
    {
        if(isForScreenBlind)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, eulerAngles.y, 0f);
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(eulerAngles);
        }
        
        _isReciveingInfo = true;
    }
}
