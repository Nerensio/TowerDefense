using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public float range = 15f;

    public string enemyTag = "Enemy";

    public Transform RotationTourelle;
    // Start is called before the first frame update


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    

    // vérouiller l'ennemi
    void UpdateTarget()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in ennemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortDistance)
            {
                shortDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;

        }Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);

        Vector3 rotation = lookRotation.eulerAngles;

        RotationTourelle.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Gizmos.DrawWireSphere(transform.position, range);

        if (target == null)
        {
            return;
        }
    }
}
