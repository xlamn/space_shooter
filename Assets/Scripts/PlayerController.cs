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

    // Bullet
    private List<GameObject> bullets = new List<GameObject>();
    public GameObject bullet;
    private float _lastBulletSpawnTime = 0;
    private readonly float _spawnTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        _rigidBody = gameObject.GetComponent<Rigidbody>();

        for (int i = 0; i < 20; i++)
        {
            bullets.Add(Instantiate(bullet, Vector3.zero, Quaternion.identity));
            bullet.SetActive(false);
            bullets.Add(bullet);
        }

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
            SpawnBullet();
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

    private void SpawnBullet()
    {
        if (Time.time - _lastBulletSpawnTime > _spawnTime)
        {
            // Spawn a bullet
            GameObject bullet = GetInactiveBullet();
            if (bullet != null)
            {
                bullet.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z); ;
                bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
                bullet.SetActive(true);
            }

            _lastBulletSpawnTime = Time.time;
        }
    }

    private GameObject GetInactiveBullet()
    {
        foreach (var bullet in bullets)
        {
            if (!bullet.activeSelf)
            {
                return bullet;
            }
        }
        return null;
    }
}
