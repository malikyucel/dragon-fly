using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject powerup;
    public GameObject point;
    public GameObject dag;
    public float speedSpw = 10;
    private int sny = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("point_", 1, Random.Range(5,10));
        InvokeRepeating("Spawn_Powerup", 0, 50);
        InvokeRepeating("dag_",0,20);
        StartCoroutine(SpeedController());
        StartCoroutine(SpawnController());
        StartCoroutine(SpawnController2());
        StartCoroutine(SpawnController3());
        StartCoroutine(SpawnController4());
        StartCoroutine(snyPlas());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn_Manager()
    {
        float randomX = Random.Range(-9, 12);
        float randomY = Random.Range(1, 12);
        float randomZ = Random.Range(70,80);
        Vector3 spawnPos = new Vector3(randomX,randomY, randomZ);
        int ranEnemy = Random.Range(0,enemy.Length);
        Instantiate(enemy[ranEnemy], spawnPos, enemy[ranEnemy].transform.rotation);
    }
    void Spawn_Manager2()
    {
        float randomX = Random.Range(-9, 12);
        float randomY = Random.Range(1, 12);
        float randomZ = Random.Range(80, 90);
        Vector3 spawnPos = new Vector3(randomX, randomY, randomZ);
        int ranEnemy = Random.Range(0, enemy.Length);
        Instantiate(enemy[ranEnemy], spawnPos, enemy[ranEnemy].transform.rotation);
    }
    void Spawn_Manager3()
    {
        float randomX = Random.Range(-9, 12);
        float randomY = Random.Range(1, 12);
        float randomZ = Random.Range(90, 100);
        Vector3 spawnPos = new Vector3(randomX, randomY, randomZ);
        int ranEnemy = Random.Range(0, enemy.Length);
        Instantiate(enemy[ranEnemy], spawnPos, enemy[ranEnemy].transform.rotation);
    }
    void Spawn_Manager4()
    {
        float randomX = Random.Range(-9, 12);
        float randomY = Random.Range(1, 12);
        float randomZ = Random.Range(100, 110);
        Vector3 spawnPos = new Vector3(randomX, randomY, randomZ);
        int ranEnemy = Random.Range(0, enemy.Length);
        Instantiate(enemy[ranEnemy], spawnPos, enemy[ranEnemy].transform.rotation);
    }
    void Spawn_Powerup()
    {
        float randomX = Random.Range(-10, 11);
        float randomY = Random.Range(1, 12);
        float randomZ = Random.Range(100, 110);
        Vector3 spawnPos = new Vector3(randomX, randomY, randomZ);

        Instantiate(powerup, spawnPos, powerup.transform.rotation);
    }
    void point_()
    {
        float randomX = Random.Range(-10, 11);
        float randomY = Random.Range(3, 12);
        float randomZ = Random.Range(100, 110);
        Vector3 spawnPos = new Vector3(randomX, randomY, randomZ);

        Instantiate(point, spawnPos, point.transform.rotation);
    }
    void dag_()
    {
        Vector3 spawnPos = new Vector3(52,104,472);

        Instantiate(dag, spawnPos, dag.transform.rotation);
    }
    private IEnumerator SpeedController()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            speedSpw = speedSpw + 5;

        }
    }
    private IEnumerator SpawnController()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            InvokeRepeating("Spawn_Manager", 0, sny);
        }
    }
    private IEnumerator SpawnController2()
    {
        yield return new WaitForSeconds(60);
        while (true)
        {
            yield return new WaitForSeconds(10);
            InvokeRepeating("Spawn_Manager2", 0, sny);
        }
    }

    private IEnumerator SpawnController3()
    {
        yield return new WaitForSeconds(120);
        while (true)
        {
            yield return new WaitForSeconds(10);
            InvokeRepeating("Spawn_Manager3", 0, sny);
        }
    }
    private IEnumerator SpawnController4()
    {
        yield return new WaitForSeconds(160);
        while (true)
        {
            yield return new WaitForSeconds(10);
            InvokeRepeating("Spawn_Manager4", 0, sny);
        }
    }
    private IEnumerator snyPlas()
    {
        yield return new WaitForSeconds(200);
        sny = 1;
    }
}
