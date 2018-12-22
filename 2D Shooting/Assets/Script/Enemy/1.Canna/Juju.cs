﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juju : MonoBehaviour
{
    private Transform tr;

    float moveSpeed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            GameManager.score += 100;
        }
    }

    private void Move()
    {
        tr.Translate(Vector2.down * moveSpeed * Time.deltaTime, Space.Self);
    }
}
