using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private float topBoundary = 15f;
    private float bottomBoundary = -15f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true){
            myRigidbody.linearVelocity = Vector2.up * 10;
            FindFirstObjectByType<AudioManagerScript>().PlayFlapSound();// Play flap sound
        }

        //checking if bird is out of bounds
        if(transform.position.y > topBoundary || transform.position.y < bottomBoundary){
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        FindFirstObjectByType<AudioManagerScript>().PlayCollisionSound(); // Play collision sound
        logic.gameOver();
        logic.gameOver();
        birdIsAlive = false;
    }
    


}
