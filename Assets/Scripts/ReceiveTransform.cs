using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveTransform : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RecivePosition(Vector3 position)
    {
        targetObject.transform.position = position;
    } 

    public void RecieveRotation(Vector3 eulerAngles)
    {
        targetObject.transform.rotation = Quaternion.Euler(eulerAngles);
    }
}
