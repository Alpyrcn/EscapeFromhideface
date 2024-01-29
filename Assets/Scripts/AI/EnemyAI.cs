using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform player;


    [SerializeField] private float timer = 5;
    private float bulletTime;

    public GameObject enemyBullet;
    public HealthSystem enemyHealth;
    public Transform spawnPoint;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        ShootPlayer();
    }

    public void TakeDamage(float damage)
    {
        
        enemyHealth.TakeDamage(damage);
    }

    void ShootPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5f);
    }


}
