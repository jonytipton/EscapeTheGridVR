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
    public GameObject[] targets;
    public bool thrown = false;
    public float speed = 5;
    public float discSpawnCountdown = 10;
    public bool discReady = true;
    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        discSpawnPoint = enemyDisc.transform;
        countdown = throwCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && discReady) {
            //trigger throw animation, animation event in timeline will trigger ThrowDisc() below
            //Debug.Log("Trigger anim");
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
        //Debug.Log("Throw Enemy Disc");
        enemyDisc.transform.SetParent(null);
        GameObject target = targets[Random.Range(0, targets.Length)];
        Vector3 direction = target.transform.position - enemyDisc.transform.position;
        direction.Normalize();
        enemyDisc.GetComponent<Rigidbody>().AddForce(direction * 1000 * speed);
        enemyDisc.GetComponent<Rigidbody>().freezeRotation = false;

        enemyDisc.GetComponent<MeshCollider>().enabled = true;
        thrown = true;
        enemyAnimator.SetBool("Throw", false);

    }

    void SpawnEnemyDisc() {
        //Debug.Log("Spawn Disc");
        enemyDisc.GetComponent<Rigidbody>().useGravity = false;
        enemyDisc.GetComponent<Rigidbody>().velocity = Vector3.zero;
        enemyDisc.GetComponent<Rigidbody>().freezeRotation = true;

        enemyDisc.GetComponent<MeshCollider>().enabled = false;
        enemyDisc.transform.SetParent(discParent);
        enemyDisc.transform.localPosition = new Vector3(0, 0, 0); // discSpawnPoint.transform.position;
        enemyDisc.transform.localRotation = Quaternion.identity;
        countdown = throwCountdown;
        discReady = true;
        discSpawnCountdown = 2;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "PlayerDisc") {
            print("HIT ENEMY");
            discSpawnCountdown = 0;
        }
        if (collision.gameObject.name == "XR Rig") {
            print("YOU'RE HIT");
        }
    }
}
