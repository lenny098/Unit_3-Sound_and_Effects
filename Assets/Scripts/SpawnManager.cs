using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;

    [SerializeField] float startDelay;
    [SerializeField] float repeatRate;

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, gameObject.transform.position, obstaclePrefab.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.isGameOver && IsInvoking("SpawnObstacle"))
        {
            CancelInvoke("SpawnObstacle");
        }
    }
}
