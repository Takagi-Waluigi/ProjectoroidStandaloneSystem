using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FeverTimeVisualChanger : MonoBehaviour
{
    [Header("オブジェクト設定")]
    [SerializeField] RecieveGameInformation info;

    [Header("Fever本体関連")]
    [SerializeField] Material coinMaterial;
    [SerializeField] Transform feverTransform;
    [SerializeField] float baseScale = 0.1f;
    [SerializeField] PostProcessVolume postProcessVolume;
    [SerializeField] [ColorUsage(false, true)] Color bloomColor;    
    
    [Header("Fever周辺関連")]
    GameObject[] coinObjects;
    [SerializeField] Color feverCoinColor;
    [SerializeField] Color defaultColor;
    [SerializeField] float frequency = 2.0f;
    [SerializeField] float frameRate = 30f;
    [SerializeField] MeshRenderer pacmanRendererOpen;
    [SerializeField] MeshRenderer pacmanRendererClose;

    [SerializeField] Material defaultPacmanMaterial;
    [SerializeField] Material powerUpPacmanMaterial;
    float lastUpdateTime = 0f;
    
    Bloom bloom;
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.profile.TryGetSettings<Bloom>(out bloom);

        coinObjects = GameObject.FindGameObjectsWithTag("Coin");
        Debug.Log("coint number:" + coinObjects.Length);
    }

    // Update is called once per frame
    void Update()
    {        
        float scale = baseScale * info.feverAlpha;
        feverTransform.localScale = new Vector3(scale, scale, scale);

        float wavingColor = bloomColor.r + 0.45f * Mathf.Sin(Time.time * 5.0f);
        bloom.color.value = new Color(wavingColor, bloomColor.g, bloomColor.b);

        if(Time.time - lastUpdateTime > 1f / frameRate)
        {
            foreach(GameObject coinObject in coinObjects)
            {
                Color coinColor = defaultColor;

                if(info.enableFever)
                {
                    float position_x = coinObject.transform.position.x;
                    float diff = position_x / 4 * Mathf.PI * 8f;
                    float alpha = 0.75f + 0.25f * Mathf.Sin(info.timeRemainf * frequency  - diff);
                    coinColor = new Color(feverCoinColor.r, feverCoinColor.g, feverCoinColor.b) * alpha;;
                }

                var renderer = coinObject.GetComponent<MeshRenderer>();
                renderer.material.color = coinColor; 
            }

            pacmanRendererOpen.material = (info.enableFever)? powerUpPacmanMaterial : defaultPacmanMaterial;
            pacmanRendererClose.material = (info.enableFever)? powerUpPacmanMaterial : defaultPacmanMaterial;
            lastUpdateTime = Time.time;
        }


        
    }
}
