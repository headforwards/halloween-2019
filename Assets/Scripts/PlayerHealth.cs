using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float Health = 100f;

    private float currentHealth;

    public Text HealthText;

    void Start()
    {
        currentHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = GameState.isPlaying ? "Health: " + currentHealth.ToString() : string.Empty;
    }

    public void Attacked(float attack)
    {
        if (!GameState.isPlaying)
            return;

        currentHealth -= attack;
        
        if (currentHealth < 1)
        {
            GameState.GameOver();
            currentHealth = Health;
        }
    }
}
