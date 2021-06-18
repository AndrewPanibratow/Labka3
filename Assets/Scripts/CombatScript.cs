using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScript : MonoBehaviour
{
    // Update is called once per frame

    public Animator attackAnimation1;
    private float timeBtwAttacks;
    public float startTimeBtwAttacks;
    public Transform attackPos;
    public LayerMask enemy;
    public int damage;

    void Update()
    {
        if (timeBtwAttacks <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                timeBtwAttacks = startTimeBtwAttacks;
            }
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }
    }

    void Attack ()
    {
        attackAnimation1.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyAI>().damageFromPlayer(damage);
    }
}
