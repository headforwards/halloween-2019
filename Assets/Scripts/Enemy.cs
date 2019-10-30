using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float Health = 100f;
    public float AttackDelay = 1.5f;

    public float AttackStrength = 5.0f;

    public float AttackSpeed = .5f;
    public Image HealthBar;
    public Canvas HealthBarCanvas;
    public PlayerHealth playerHealth;

    private Animator animator;

    private NavMeshAgent agent;

    private AudioSource audioSource;

    public float pauseBeforeDeath = 5f;

    private CapsuleCollider enemyCollider;
    private bool gameOverTriggered = false;

    void Start()
    {
        enemyCollider = GetComponent<CapsuleCollider>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        HealthBarCanvas.enabled = false;

        if (Random.Range(0, 10) == 1)
        {
            audioSource.clip = Resources.Load<AudioClip>("grumble1");
            audioSource.Play();
        }
        else
        {
            StartCoroutine(Growl());
        }
    }

    IEnumerator Growl()
    {
        yield return new WaitForSeconds(Random.Range(2f, 15f));
        audioSource.clip = Resources.Load<AudioClip>("growl1");
        audioSource.Play();
        StartCoroutine(Growl());
    }

    void Update()
    {
        if (!GameState.isPlaying && !gameOverTriggered)
        {
            gameOverTriggered = true;
            StartCoroutine(GameEnd());
        }
    }

    IEnumerator GameEnd()
    {
        animator.SetTrigger("idle");

        yield return new WaitForSeconds(1f);

        animator.SetTrigger("death");

        yield return new WaitForSeconds(1f);

        animator.SetTrigger("sink");

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }

    public void Hit(float attackPoint)
    {
        if (!GameState.isPlaying)
            return;

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
        HealthBarCanvas.enabled = false;
        enemyCollider.enabled = false;
        agent.isStopped = true;

        string clip = string.Format("die{0}", Random.Range(1, 3));
        audioSource.clip = Resources.Load<AudioClip>(clip);

        animator.SetTrigger("death");
        yield return new WaitForSeconds(pauseBeforeDeath);
        animator.SetTrigger("sink");
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
        GameState.enemyCount--;
    }

    void OnTriggerEnter(Collider collider)
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        if (GameState.isPlaying)
        {
            string attack = string.Format("attack{0}", Random.Range(1, 4));
            audioSource.clip = Resources.Load<AudioClip>(attack);
            audioSource.Play();
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(AttackSpeed);
            int attackAnimationCount = 5;
            for (int attackCount = 0; attackCount <= attackAnimationCount; attackCount++)
            {
                playerHealth.Attacked(AttackStrength / attackAnimationCount);
                yield return new WaitForSeconds(AttackSpeed);
            }
            animator.SetTrigger("idle");
            yield return new WaitForSeconds(AttackDelay);
            StartCoroutine(Attack());
        }
    }
}
