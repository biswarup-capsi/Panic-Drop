using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject circle;

    [SerializeField]
    private GameObject capsule;

    [SerializeField]
    private GameObject box;

    private float timer = 0f;
    private float baseSpawnInterval = 2.0f; // starting interval
    private float spawnInterval; // actual interval that changes with level

    private int index;
    private GameObject objectToSpawn;

    private float posX;
    private Vector3 spawnPosition;

    void Start()
    {
        spawnInterval = baseSpawnInterval;
        if (UIController.Instance.currentState==GameState.Running) SpawnRandomObject();
    }

    void Update()
    {
        if (UIController.Instance.currentState==GameState.Running)
        {

            spawnInterval = Mathf.Max(0.5f, baseSpawnInterval - (UIController.Instance.Level - 1) * 0.5f);

            if (timer < spawnInterval)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnRandomObject();
                timer = 0f;
            }
        }
    }

    private void SpawnRandomObject()
    {
        index = Random.Range(0, 3);
        switch (index)
        {
            case 0: objectToSpawn = circle; break;
            case 1: objectToSpawn = capsule; break;
            case 2: objectToSpawn = box; break;
        }

        if (objectToSpawn != null)
        {
            posX = Random.Range(-6.8f, 6.8f);
            spawnPosition = new Vector3(posX, transform.position.y, 0f);
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
