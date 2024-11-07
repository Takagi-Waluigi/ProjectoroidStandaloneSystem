using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStandPositionVisualControl : MonoBehaviour
{
    [SerializeField] ReceiveTransform receiveTransform;
    [SerializeField] Transform projectionCameraTransform;
    [SerializeField] float baseScale = 0.2f;
    [SerializeField] float wavingRadius = 0.05f;
    [SerializeField] float wavingSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!receiveTransform.isReciveingInfo)
        {
            this.transform.position = new Vector3(
                projectionCameraTransform.transform.position.x,
                0.5f,
                projectionCameraTransform.transform.position.z
            );
        }

        float localScale = baseScale + wavingRadius * Mathf.Sin(Time.time * wavingSpeed);
        this.transform.localScale = new Vector3(localScale, localScale, 1f);
    }
}
