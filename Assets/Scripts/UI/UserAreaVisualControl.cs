using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAreaVisualControl : MonoBehaviour
{
    [SerializeField] Camera projectionCamera;
    [SerializeField] GameObject screenBlindObject;
    [SerializeField] float localHeight = 0.7f;
    [Range(0f, 1f)] public float blurWidthRatio = 0.5f;
    [Range(0, 40f)] public float blurScale = 40f;

    GameObject leftBlind, rightBlind;
    // Start is called before the first frame update
    void Start()
    {
        leftBlind = GameObject.Instantiate(screenBlindObject, this.transform);
        rightBlind = GameObject.Instantiate(screenBlindObject, this.transform);

        Debug.Log(projectionCamera.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        float screenWidthScaleHalf = projectionCamera.orthographicSize * 1.6f;
        float screenPostionX = screenWidthScaleHalf * blurWidthRatio;

        rightBlind.transform.localPosition = new Vector3(screenPostionX, 0, localHeight );
        leftBlind.transform.localPosition = new Vector3(-screenPostionX, 0, localHeight );

        Vector3 localScale = new Vector3(
            (1f - screenPostionX) * 2.0f,
            projectionCamera.orthographicSize * 2.0f,
            1f
        );

        rightBlind.transform.localScale = localScale;
        leftBlind.transform.localScale = localScale;
    }
}
