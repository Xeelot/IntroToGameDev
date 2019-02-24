using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{
	// public variables
	public float secondsBetweenSpawning = 0.1f;
	public float xMinRange = -25.0f;
	public float xMaxRange = 25.0f;
	public float yMinRange = 8.0f;
	public float yMaxRange = 25.0f;
	public float zMinRange = -25.0f;
	public float zMaxRange = 25.0f;
	public GameObject[] spawnObjects; // what prefabs to spawn
    public float endSpawnTime = 0.0f;

	private float nextSpawnTime;
    private float startSpawnTime;

	// Use this for initialization
	void Start ()
	{
		// determine when to spawn the next object
		nextSpawnTime = Time.time+secondsBetweenSpawning;
        startSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}

        // if time to stop spawning
        if (endSpawnTime > 0.0f && Time.time > endSpawnTime) {
            return;
        }

		// if time to spawn a new game object
		if (Time.time >= nextSpawnTime) {
			// Spawn the game object through function below
			MakeThingToSpawn ();

			// determine the next time to spawn the object
			nextSpawnTime = Time.time+secondsBetweenSpawning;
		}	
	}

	void MakeThingToSpawn ()
	{
		Vector3 spawnPosition;

		// get a random position between the specified ranges
		spawnPosition.x = gameObject.transform.position.x + Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = gameObject.transform.position.y + Random.Range (yMinRange, yMaxRange);
		spawnPosition.z = gameObject.transform.position.z + Random.Range (zMinRange, zMaxRange);

		// determine which object to spawn
		int objectToSpawn = Random.Range (0, spawnObjects.Length);

		// actually spawn the game object
		GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

		// make the parent the spawner so hierarchy doesn't get super messy
		spawnedObject.transform.parent = gameObject.transform;
	}
}
