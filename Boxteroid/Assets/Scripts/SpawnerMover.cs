using UnityEngine;
using System.Collections;

public class SpawnerMover : MonoBehaviour {

    // store the state
    public Vector3[] movePositions;
    public float moveSpeed;

    private int moveLocation = 0;
    private static float THRESHOLD = 0.1f;

	// Update is called once per frame
	void Update () {

        // if we've reached the final location, do nothing
        if (moveLocation == movePositions.Length) {
            return;
        }

        // calculate the distance to the current moveLocation and determine which direction the spawner needs to move
        float diffX = movePositions[moveLocation].x - gameObject.transform.position.x;
        float diffZ = movePositions[moveLocation].z - gameObject.transform.position.z;

        // move the spawner at constant speed toward the location
        if (diffX > THRESHOLD) {
            gameObject.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        } else if (diffX < -THRESHOLD) {
            gameObject.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        } else if (diffZ > THRESHOLD) {
            gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        } else if (diffZ < -THRESHOLD) {
            gameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        } else {
            moveLocation++;
        }
	}
}
