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

           var tag = hit.collider.gameObject.tag;

           if (tag == "Enemy") {
               var enemy = hit.collider.gameObject.GetComponent<Enemy>();
               enemy.Hit(attackStrength);
           }

           if(tag == "GameController")
           {
               GameState.isPlaying = true;
           }
       }
    }
}
