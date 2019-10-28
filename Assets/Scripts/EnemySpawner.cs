using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float MaxDistance = 10f;

    public float MinDistance = 5f;

    public float minInterval = 0.1f;

    public float maxInterval = 1.0f;

    public int maxEnemies = 100;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    IEnumerator Spawn()
    {
        if (GameState.enemyCount <= maxEnemies && GameState.isPlaying)
        {
            GameState.enemyCount++;

            // get a random direction (360°) in radians
            float angle = Random.Range(0.0f, Mathf.PI * 2);

            // create a vector with length 1.0
            Vector3 V = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));

            // scale it to the desired length
            var range = Random.Range(MinDistance, MaxDistance);
            V *= range;

            var enemy = Resources.Load("Enemy") as GameObject;

            var playerHealth = gameObject.GetComponent<PlayerHealth>();
            var script = enemy.GetComponent<EnemyAI>();
            var enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.playerHealth = playerHealth;
            script.Target = gameObject.transform;

            GameObject.Instantiate(enemy, V, Quaternion.identity);
        }

        yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        StartCoroutine(Spawn());
    }
}
