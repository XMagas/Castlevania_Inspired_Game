using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    public int AttackDamage = 20;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("r"))
        {

            Attack();


        }

        void Attack()
        {


            Collider2D[] hitenemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);

            Debug.Log("Attacking");

        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);



    }
}
