using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    public GameObject enemyDisc;
    public  Transform discSpawnPoint;
    public Animator enemyAnimator;
    public float throwCountdown = 5f;
    public GameObject player;
    public bool thrown = false;
    public float speed = 5;
    public float discSpawnCountdown = 10;
    bool discReady = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        throwCountdown -= Time.deltaTime;
        if (throwCountdown <= 0 && discReady) {
            //trigger throw animation, animation event in timeline will trigger ThrowDisc() below
            enemyAnimator.SetBool("Throw", true);
            discReady = false;
        }
        if (thrown) {
            discSpawnCountdown -= Time.deltaTime;

            if (discSpawnCountdown <= 0) {
                SpawnEnemyDisc();
            }
        }
    }

    void ThrowDisc() {
        Debug.Log("Throw Enemy Disc");
        enemyDisc.transform.SetParent(null);
        Vector3 direction = player.transform.position - enemyDisc.transform.position;
        direction.Normalize();
        enemyDisc.GetComponent<Rigidbody>().AddForce(direction * 1000 * speed);
        thrown = true;
    }

    void SpawnEnemyDisc() {
        enemyDisc.GetComponent<Rigidbody>().useGravity = false;
        enemyDisc.transform.position = discSpawnPoint.position;
        enemyDisc.transform.SetParent(discSpawnPoint);
        discReady = true;
        discSpawnCountdown = 10;
        throwCountdown = 10;
        thrown = false;
    }
}
