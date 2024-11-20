using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveScreenSize : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] UserAreaVisualControl userAreaVisualControl;

    public void RecieveScreenSizeInfo(Vector3 info)
    {
        camera.orthographicSize = info.x;
        userAreaVisualControl.blurWidthRatio = info.y;
        userAreaVisualControl.blurScale = info.z;
    }
}
