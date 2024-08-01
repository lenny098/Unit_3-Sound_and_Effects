using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    PlayerController playerController;

    [SerializeField] float startDelay;
    [SerializeField] float repeatRate;

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, gameObject.transform.position, obstaclePrefab.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGameOver && IsInvoking("SpawnObstacle"))
        {
            CancelInvoke("SpawnObstacle");
        }
    }
}
