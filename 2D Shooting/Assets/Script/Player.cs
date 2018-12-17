﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Transform tr;
    // 총알
    public GameObject bullet;
    // 총알 발사좌표
    public Transform firePos;

    // Horizontal
    private float h = 0.0f;
    // Vertical
    private float v = 0.0f;

    public float moveSpeed = 10.0f;

    // 발사 유무
    public bool canShoot = true;
    // 공격 딜레이
    public float attackDelay = 0.1f;
    float attackTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Fire();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        tr.Translate(Vector2.right * moveSpeed * h * Time.deltaTime, Space.Self);
        tr.Translate(Vector2.up    * moveSpeed * v * Time.deltaTime, Space.Self);

        // 월드좌표를 뷰포트좌표로 바꾼다. 
        Vector2 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        // 0~1값으로 제한한다.
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        // 뷰포트좌표를 월드좌표로 바꾼다.
        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }

    private void Fire()
    {
        if(canShoot==true)
        {
            if(attackTimer > attackDelay)
            {
                if (Input.GetMouseButton(0))
                    StartCoroutine(this.CreateBullet());

                attackTimer = 0;
            }
            attackTimer += Time.deltaTime;
        }
    }

    IEnumerator CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        yield return null;
    }
}
