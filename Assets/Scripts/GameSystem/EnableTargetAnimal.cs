using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTargetAnimal : MonoBehaviour
{
    [SerializeField] RecieveGameInformation info;
    [SerializeField] SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.enabled = !info.isMemoryPhase;
    }
}
