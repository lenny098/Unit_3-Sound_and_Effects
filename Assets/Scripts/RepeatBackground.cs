using UnityEngine;

[RequireComponent(typeof (BoxCollider))]
public class RepeatBackground : MonoBehaviour
{
    Vector3 start;
    float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < (start.x - repeatWidth))
        {
            transform.position = start;
        }
    }
}
