using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverTimeVisualChanger : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] RecieveGameInformation info;
    [SerializeField] Color feverColor;
    [SerializeField] Color defaultColor;
    [SerializeField] float frequency = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color areaColor = defaultColor;

        if(info.enableFever)
        {
            float difference = this.transform.position.x;
            areaColor.r = feverColor.r * 0.75f + feverColor.r * 0.25f * Mathf.Sin(info.timeRemainf * frequency - difference);
            areaColor.g = feverColor.g * 0.75f + feverColor.g * 0.25f * Mathf.Sin(info.timeRemainf * frequency - difference);
            areaColor.b = feverColor.b * 0.75f + feverColor.b * 0.25f * Mathf.Sin(info.timeRemainf * frequency - difference);
        }

        material.color = areaColor;

    }
}
