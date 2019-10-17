using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float Health = 100f;
    public float AttackDelay = 1.5f;
    public Image HealthBar;
    public Canvas HealthBarCanvas;
    public PlayerHealth playerHealth;

    private Animator animator;

    private NavMeshAgent agent;

    public float pauseBeforeDeath = 5f;

    private CapsuleCollider enemyCollider;

    void Start()
    {
        enemyCollider = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        HealthBarCanvas.enabled = false;
    }

    public void Hit(float attackPoint)
    {
        HealthBarCanvas.enabled = true;

        Health -= attackPoint;

        HealthBar.fillAmount = Health / 100;

        if (Health < 0)
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        animator.SetTrigger("death");
        HealthBarCanvas.enabled = false;
        enemyCollider.enabled = false;
        agent.enabled = false;
        yield return new WaitForSeconds(pauseBeforeDeath);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack(){
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(AttackDelay);
        animator.SetTrigger("idle");
        playerHealth.Attacked(5f);
        yield return new WaitForSeconds(AttackDelay);
        StartCoroutine(Attack());
    }
}
