using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Health =100f;

    public void Hit(float attackPoint){
        Health=Health-attackPoint;
        if(Health<0){
            Destroy(gameObject);
        }
    }

}
