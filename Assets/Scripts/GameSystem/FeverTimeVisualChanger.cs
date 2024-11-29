using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverTimeVisualChanger : MonoBehaviour
{
    [SerializeField] Material coinMaterial;
    [SerializeField] MeshRenderer feverRenderer;
    [SerializeField] RecieveGameInformation info;
    [SerializeField] Color feverCoinColor;
    [SerializeField] Color defaultColor;
    [SerializeField] Color feverColor;
    [SerializeField] float frequency = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float alpha = (info.feverAlpha > 0)? info.feverAlpha : 0.0f;
        feverRenderer.material.color = new Color(feverColor.r, feverColor.g, feverColor.b, alpha);

        Color areaColor = defaultColor;

        if(info.enableFever)
        {
            float difference = this.transform.position.x;
            areaColor.r = feverCoinColor.r * 0.75f + feverCoinColor.r * 0.25f * Mathf.Sin(info.timeRemainf * frequency - difference);
            areaColor.g = feverCoinColor.g * 0.75f + feverCoinColor.g * 0.25f * Mathf.Sin(info.timeRemainf * frequency - difference);
            areaColor.b = feverCoinColor.b * 0.75f + feverCoinColor.b * 0.25f * Mathf.Sin(info.timeRemainf * frequency - difference);
        }

        coinMaterial.color = areaColor;

    }
}
