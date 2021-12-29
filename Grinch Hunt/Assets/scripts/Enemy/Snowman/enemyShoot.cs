using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public float fireRate = 1f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;
    EnemyPatrol ep;

    private void Start() {
        ep = GetComponent<EnemyPatrol>();
    }

    private void Update() {
        if(timeUntilFire < Time.time){
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot() {
        float angle = ep.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}