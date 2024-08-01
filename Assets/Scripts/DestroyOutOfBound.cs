using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    float xBound;

    private void Awake()
    {
        xBound = GameObject.Find("Destroy Bound").GetComponent<Renderer>().bounds.center.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }
    }
}
