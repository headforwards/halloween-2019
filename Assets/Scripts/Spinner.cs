using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float Spin = 90;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Spin * Time.deltaTime);
    }

    public void ChangeDirection()
    {
        Spin = -Spin;
    }
}
