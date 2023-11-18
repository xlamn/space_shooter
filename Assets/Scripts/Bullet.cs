using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5.0f;

    public LogicManager logicManager;

    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (gameObject.activeSelf && transform.position.y > logicManager.maxHeight || transform.position.y < -logicManager.maxHeight || transform.position.x > logicManager.maxWidth || transform.position.x < -logicManager.maxWidth)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            logicManager.addScore(1);
            gameObject.SetActive(false);
            collider.gameObject.SetActive(false);
        }
    }
}