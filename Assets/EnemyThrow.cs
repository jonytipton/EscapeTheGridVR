using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrow : MonoBehaviour
{
    public GameObject enemyDisc;
    public Transform discParent;
    Transform discSpawnPoint;
    public Animator enemyAnimator;
    public float throwCountdown = 5f;
    public GameObject player;
    public bool thrown = false;
    public float speed = 5;
    public float discSpawnCountdown = 10;
    public bool discReady = true;

    // Start is called before the first frame update
    void Start()
    {
        discSpawnPoint = enemyDisc.transform;
    }

    // Update is called once per frame
    void Update()
    {
        throwCountdown -= Time.deltaTime;
        if (throwCountdown <= 0 && discReady) {
            //trigger throw animation, animation event in timeline will trigger ThrowDisc() below
            Debug.Log("Trigger anim");
            enemyAnimator.SetBool("Throw", true);
            discReady = false;
        }
        if (!discReady) {
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
        enemyAnimator.SetBool("Throw", false);
    }

    void SpawnEnemyDisc() {
        Debug.Log("Spawn Disc");
        enemyDisc.GetComponent<Rigidbody>().useGravity = false;
        enemyDisc.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemyDisc.transform.SetParent(discParent);
        enemyDisc.transform.localPosition = new Vector3(0, 0, 0); // discSpawnPoint.transform.position;
        enemyDisc.transform.localRotation = Quaternion.identity;
        throwCountdown = 10;
        discReady = true;
        discSpawnCountdown = 10;
    }
}
