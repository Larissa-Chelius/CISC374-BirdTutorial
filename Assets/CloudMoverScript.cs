using UnityEngine;

public class CloudMoverScript : MonoBehaviour
{
    public float speed = 2f;  // Speed of the clouds

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy cloud when it moves off-screen
        if (transform.position.x < Camera.main.transform.position.x - 10f)
        {
            Destroy(gameObject);
        }
    }
}
