﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Horizontal
    private float h = 0.0f;
    // Vertical
    private float v = 0.0f;

    private Transform tr;

    public float moveSpeed = 10.0f;

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

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        tr.Translate(Vector2.right * moveSpeed * h * Time.deltaTime, Space.Self);
        tr.Translate(Vector2.up    * moveSpeed * v * Time.deltaTime, Space.Self);
    }
}
