using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheller : MonoBehaviour
{
    private Transform tr;

    float moveSpeed = 4.0f;

    // 총알
    public GameObject bullet;
    // 총알 발사좌표
    public Transform firePos;

    // 발사 유무
    public bool canShoot = true;
    // 공격 딜레이
    public float attackDelay = 1.0f;
    float attackTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move();

        // 게임오브젝트를 카메라 가운데 위치 시킨다.
        //gameObject.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);

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

    private void Fire()
    {
        if (canShoot == true)
        {
            if (attackTimer > attackDelay)
            {
                StartCoroutine(this.CreateBullet());

                attackTimer = 0;
            }
            attackTimer += Time.deltaTime;
        }
    }

    IEnumerator CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);

        /*
         * null:                        다음 프레임까지 대기
         * new WaitForseconds(float):   지정된 초 만큼 대기
         * new WaitForFixedUpdate():    다음 물리 프레임까지 대기
         * new WaitForEndOfFrame():     모든 렌더링 작업이 끝날 때까지 대기
         * StartCoRoutine(string):      다른 코루틴이 끝날 때까지 대기
         * new WWW(string):             웹 통신 작업이 끝날 때까지 대기
         * new AsyncOperation:          비동기 작업이 끝날 떄까지 대기(씬로딩)
         */
        yield return null;
    }

    // 몸통박치기
    void Smash()
    {
        
    }
}
