using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    public float jumpForce;
    private int point;

    public GameObject[] heart;
    public GameObject canvas;
    int kapSayisi = 3;

    public TextMeshProUGUI Point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput);

        if (transform.position.x > 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        if (transform.position.y < 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
        if (transform.position.y > 10)
        {
            transform.position = new Vector3(transform.position.x, 10, transform.position.z);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // health reduction
        if (collision.gameObject.CompareTag("Enemy") && kapSayisi == 1)
        {
            kapSayisi--;
            Destroy(heart[2]);
            canvas.SetActive(true);
            Time.timeScale = 0.0f;
        }
        if (collision.gameObject.CompareTag("Enemy") && kapSayisi == 2)
        {
            kapSayisi--;
            Destroy(heart[1]);
        }
        if (collision.gameObject.CompareTag("Enemy") && kapSayisi == 3)
        {
            kapSayisi --;
            Destroy(heart[0]);
        }

        // powerup
        if (collision.gameObject.CompareTag("Powerup"))
        {
            StartCoroutine(Powerup());
            Destroy(collision.gameObject);
        }

        // Point
        if (collision.gameObject.CompareTag("Point"))
        {
            point ++;
            GameManager.Instance.poin = point;
            Point.text = "Point: " + point;
            if (GameManager.Instance.poin < point)
            {
                GameManager.Instance.poin = point;
                GameManager.Instance.SaveDate();
            }
            Destroy(collision.gameObject);
        }
    }
    IEnumerator Powerup()
    {
        int RandomPowerup = Random.Range(0,2);
        if (RandomPowerup == 1)
        {
            Time.timeScale = 0.5f;
            speed *= 3;
            yield return new WaitForSeconds(10);
            speed /= 3;
            Time.timeScale = 1.0f;
        }
        else if (RandomPowerup == 0)
        {
            speed *= 2;
            yield return new WaitForSeconds(10);
            speed /= 2;
        }
    }
}
