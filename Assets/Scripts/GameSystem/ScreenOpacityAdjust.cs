using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOpacityAdjust : MonoBehaviour
{
    [SerializeField] GameObject screenBlinderObject;
    [SerializeField] RecieveGameInformation info;
    float opacity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        opacity = (info.isGameOver)? 0.85f : 0f;

        var renderer = screenBlinderObject.GetComponent<MeshRenderer>();
        renderer.material.color = new Color(
            0, 0, 0, opacity
        );
    }
}
