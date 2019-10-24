using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light flickeringLight;

    public float MinFlicker = 0.02f;

    public float MaxFlicker = 0.5f;

    void Start()
    {
        flickeringLight = GetComponent<Light>();

        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        yield return new WaitForSeconds(Random.Range(MinFlicker,MaxFlicker));

        flickeringLight.enabled = Random.value > 0.5f;

        StartCoroutine(Flicker());
    }
}
