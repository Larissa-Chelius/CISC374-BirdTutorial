using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{

    public GameObject cloudPrefab;  // Assign the cloud prefab in the Inspector
    public float spawnRate = 3f;    // Time between spawns
    public float cloudSpeed = 2f;   // How fast clouds move
    public Vector2 spawnRangeY = new Vector2(2f, 5f);

    private float nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnCloud();
            nextSpawnTime = Time.time + spawnRate;
        }
    }
    void SpawnCloud()
    {
        // Randomize Y position
        float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);

        // Spawn cloud just off-screen to the right
        Vector3 spawnPosition = new Vector3(Camera.main.transform.position.x + 10f, randomY, 0f);

        GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
        
        // Add movement script to the cloud
        newCloud.AddComponent<CloudMoverScript>().speed = cloudSpeed;
    }

}
