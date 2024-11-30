using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 yön = Vector3.forward;
    public float enemySpeed;
    // GameScene gameScene;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemySpeed = spawnManager.speedSpw;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(enemySpeed * yön * Time.deltaTime);
        if (transform.position.z < -16)
        {
            Destroy(gameObject);
        }
        

    }
}
