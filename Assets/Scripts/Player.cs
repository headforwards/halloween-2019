using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image CountDownImage;
    public float maxDistance = 50f;
    public float attackStrength = 1f;

    public double CountDown = 2000;

    public float SphereCastRadius = 2f;
    private DateTime? countdownStarted = null;

    void Start()
    {
        ResetCountDown();
    }

    // Update is called once per frame
    void Update()
    {
        var hits = Physics.SphereCastAll(
            transform.position += Vector3.forward * 2,
            SphereCastRadius,
            transform.TransformDirection(Vector3.forward),
            maxDistance);

        if (hits?.Length > 0)
        {
            bool gameControllerHit = false;

            foreach (var hit in hits)
            {
                var tag = hit.collider.gameObject.tag;

                if (tag == "Enemy")
                {
                    var enemy = hit.collider.gameObject.GetComponent<Enemy>();
                    enemy.Hit(attackStrength / hit.distance);
                }

                if (tag == "GameController" && !GameState.isPlaying)
                {
                    if (countdownStarted == null)
                        countdownStarted = DateTime.Now;

                    var elapsed = (DateTime.Now - countdownStarted.Value).TotalMilliseconds;

                    CountDownImage.fillAmount = (float)(elapsed / CountDown);

                    if (elapsed >= CountDown)
                        StartGame();

                        gameControllerHit = true;
                }
            }

            if(!gameControllerHit)
                ResetCountDown();
        }
        else
        {
            ResetCountDown();
        }
    }

    void ResetCountDown()
    {
        CountDownImage.fillAmount = 0;
        countdownStarted = null;
    }

    void StartGame()
    {
        GameState.StartGame();
        ResetCountDown();
    }
}
