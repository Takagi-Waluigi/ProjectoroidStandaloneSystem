using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveScreenSize : MonoBehaviour
{
    [SerializeField] Camera camera;

    public void RecieveScreenSizeInfo(float info)
    {
        camera.orthographicSize = info;
    }
}
