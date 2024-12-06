using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVisualizer : MonoBehaviour
{    [SerializeField] RecieveGameInformation info;
    [SerializeField] List<Sprite> characters = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(characters.Count > 0)
        {
            var character = this.GetComponent<SpriteRenderer>();
            character.enabled = !info.isMemoryPhase;
            character.sprite = characters[info.targetCardId];
        }
    }
}
