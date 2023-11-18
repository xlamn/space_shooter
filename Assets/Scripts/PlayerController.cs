using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    // Ship
    public float rotationSpeed = 500;
    public float thrustSpeed = 5f;
    private Vector2 thrustDirection;
    private Rigidbody _rigidBody;

    // Logic
    public LogicManager logicManager;

    // Bullet Spawner
    public BulletSpawner bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        bulletSpawner = GameObject.Find("BulletSpawner").GetComponent<BulletSpawner>();
        _rigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotation = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        float thrust = Input.GetAxis("Vertical") * Time.deltaTime * thrustSpeed;

        thrustDirection = transform.right;

        transform.Rotate(Vector3.forward, -rotation);
        _rigidBody.AddForce(thrustDirection * thrust);

        CrossBorder();

        if (Input.GetKey(KeyCode.Space))
        {
            bulletSpawner.SpawnBullet(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            logicManager.saveScore();
        }
    }

    private void CrossBorder()
    {
        if (transform.position.x > logicManager.maxWidth)
        {
            transform.position = new Vector3(-logicManager.maxWidth, transform.position.y, transform.position.z);
        }
        else if (transform.position.y > logicManager.maxHeight)
        {
            transform.position = new Vector3(transform.position.x, -logicManager.maxHeight, transform.position.z);
        }
        else if (transform.position.x < -logicManager.maxWidth)
        {
            transform.position = new Vector3(logicManager.maxWidth, transform.position.y, transform.position.z);
        }
        else if (transform.position.y < -logicManager.maxHeight)
        {
            transform.position = new Vector3(transform.position.x, logicManager.maxHeight, transform.position.z);
        }
    }
}
