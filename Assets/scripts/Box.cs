using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    int vida = 5;
    public void TakeDamage(int damage)
    {
        vida-= damage;
        if(vida <=0)
        {
            Destroy(this.gameObject);
        }
    }
}
