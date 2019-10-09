using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float Health = 100f;
    public Image HealthBar;
    public Canvas HealthBarCanvas;

    void Start()
    {
        HealthBarCanvas.enabled = false;
    }

    public void Hit(float attackPoint)
    {
        HealthBarCanvas.enabled = true;

        Health -= attackPoint;

        HealthBar.fillAmount = Health / 100;

        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
