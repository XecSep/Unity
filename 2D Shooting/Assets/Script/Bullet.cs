using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform tr;

    public float moveSpeed = 10.0f;
    public float destroyTime = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Destroy();
    }

    private void Move()
    {
        tr.Translate(Vector2.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    private void Destroy()
    {
        Destroy(gameObject, destroyTime);
    }
}
