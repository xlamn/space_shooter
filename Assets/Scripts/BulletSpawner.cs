using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletSpawner : MonoBehaviour
{
    // Bullet
    private List<GameObject> bullets = new List<GameObject>();
    public GameObject bullet;
    private float _lastBulletSpawnTime = 0;
    private readonly float _spawnTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            bullets.Add(Instantiate(bullet, Vector3.zero, Quaternion.identity));
            bullet.SetActive(false);
            bullets.Add(bullet);
        }

    }

    public void SpawnBullet(GameObject ship)
    {
        if (Time.time - _lastBulletSpawnTime > _spawnTime)
        {
            // Spawn a bullet
            GameObject bullet = GetInactiveBullet();
            if (bullet != null)
            {
                bullet.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, ship.transform.position.z); ;
                bullet.transform.rotation = ship.transform.rotation * Quaternion.Euler(0, 0, -90);
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
