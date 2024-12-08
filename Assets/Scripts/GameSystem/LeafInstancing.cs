using UnityEngine;

public class LeafInstancing : MonoBehaviour
{
    [SerializeField] Transform baseTransform;
    [SerializeField] GameObject baseObject;
    [SerializeField] float spreadAreaSize = 6f;
    [SerializeField] int num = 100;
    // Start is called before the first frame update
    void Start()
    {        
        Random.InitState(10);
        for(int i = 0; i < num; i ++)
        {
            var leaf = GameObject.Instantiate(baseObject, baseTransform);

            Vector3 position = new Vector3(
                Random.Range(-spreadAreaSize * 0.5f, spreadAreaSize * 0.5f),
                0f,
                Random.Range(-spreadAreaSize * 0.5f, spreadAreaSize * 0.5f)
            );

            Quaternion rotation = Quaternion.Euler(new Vector3(90f, Random.Range(-180f, 180f), 0f));
            float scale = Random.Range(0.02f, 0.075f);

            leaf.transform.localPosition = position;
            leaf.transform.localRotation = rotation;
            leaf.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
