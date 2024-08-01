using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    float speed = 5;

    // Update is called once per frame
    void Update()
    {
        // Keep moving until game over
        if (!PlayerController.Instance.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
