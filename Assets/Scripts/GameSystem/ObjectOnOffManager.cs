using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOnOffManager : MonoBehaviour
{
    [SerializeField] RecieveGameInformation info;
    [SerializeField] GameObject enemiesObject;
    [SerializeField] MeshRenderer feverObjectRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesObject.SetActive(!info.enableFever); 
        feverObjectRenderer.enabled = !info.enableFever;
    }
}
