using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float Health = 100f;
    public float AttackDelay = 1.5f;
    public Image HealthBar;
    public Canvas HealthBarCanvas;
    public PlayerHealth playerHealth;

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

    void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack(){
        yield return new WaitForSeconds(AttackDelay);
        playerHealth.Attacked(5f);
        yield return new WaitForSeconds(AttackDelay);
        StartCoroutine(Attack());
    }
}
