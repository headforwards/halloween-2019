using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minDistance = 5f;

    public float maxDistance = 50f;

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
            var pos = gameObject.transform.position;

            pos.x = Random.Range(minDistance, maxDistance) * (Random.value > 0.5f ? 1 : -1);
            pos.z = Random.Range(minDistance, maxDistance) * (Random.value > 0.5f ? 1 : -1);

            var enemy = Resources.Load("Enemy") as GameObject;

            var playerHealth = gameObject.GetComponent<PlayerHealth>();
            var script = enemy.GetComponent<EnemyAI>();
            var enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.playerHealth = playerHealth;
            script.Target = gameObject.transform;

            GameObject.Instantiate(enemy, pos, Quaternion.identity);
        }

        yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
        StartCoroutine(Spawn());
    }
}
