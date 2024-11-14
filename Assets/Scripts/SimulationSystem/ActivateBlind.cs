using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBlind : MonoBehaviour
{
   [SerializeField] bool showProjectionBlind = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F2)) showProjectionBlind = !showProjectionBlind;
        this.GetComponent<MeshRenderer>().enabled = showProjectionBlind;
    }
}
