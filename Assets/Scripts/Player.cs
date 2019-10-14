using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxDistance = 50f;
    public float attackStrength = 1f;

    // Update is called once per frame
    void Update()
    {
       RaycastHit hit;
       if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance)) {
 
           var enemy = hit.collider.gameObject.GetComponent<Enemy>();

           if (enemy == null) {
               return;
           }
           
           enemy.Hit(attackStrength);
       }
    }
}
