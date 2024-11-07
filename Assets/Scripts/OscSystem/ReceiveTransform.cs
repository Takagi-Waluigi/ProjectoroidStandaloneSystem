using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveTransform : MonoBehaviour
{
    public bool isReciveingInfo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isReciveingInfo = false;
    }

    public void RecivePosition(Vector3 position)
    {
        this.gameObject.transform.position = position;
        isReciveingInfo = true;
    } 

    public void RecieveRotation(Vector3 eulerAngles)
    {
        this.gameObject.transform.rotation = Quaternion.Euler(eulerAngles);
        isReciveingInfo = true;
    }
}
