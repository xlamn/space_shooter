using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public LogicManager logicManager;

    // Start is called before the first frame update
    void Start()
    {

        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        var rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.up * -600f);
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf && transform.position.y > logicManager.maxHeight + 10 || transform.position.y < -logicManager.maxHeight - 10 || transform.position.x > logicManager.maxWidth + 10 || transform.position.x < -logicManager.maxWidth - 10)
        {
            gameObject.SetActive(false);
        }
    }
}
