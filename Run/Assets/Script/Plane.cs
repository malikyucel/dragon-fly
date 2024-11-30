using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private SpawnManager spawnManager;
    private Vector3 yön = Vector3.forward;
    Vector3 startPos;
    private float repeatingWith;
    private float planeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        planeSpeed = spawnManager.speedSpw;

        startPos = transform.position;
        repeatingWith = GetComponent<BoxCollider>().size.z / 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(planeSpeed * yön * Time.deltaTime);

        if (transform.position.z < startPos.z - repeatingWith)
        {
            transform.position = startPos;
        }
    }
}
