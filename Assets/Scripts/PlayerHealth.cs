using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float Health = 100f;
    public Text HealthText;

    private Canvas canvas;

    void Start()
    {
        canvas = gameObject.GetComponentInChildren<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + Health.ToString();
    }

    public void Attacked(float attack)
    {
        Health -= attack;

        canvas.enabled = Health <= 0;
    }
}
