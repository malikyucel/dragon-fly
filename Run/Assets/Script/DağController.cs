using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DağController : MonoBehaviour
{
    Vector3 yön = Vector3.back;
    private float dagSpeed;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        dagSpeed = spawnManager.speedSpw;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dagSpeed * yön * Time.deltaTime);
    }
}
