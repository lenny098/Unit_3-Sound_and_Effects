using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerController;

    private float speed = 5;
    private float xBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Keep moving until game over
        if (!playerController.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Delete out of bound obstacles
        if (transform.position.x < xBound && CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
