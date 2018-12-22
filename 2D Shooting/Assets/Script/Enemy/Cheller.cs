using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheller : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            GameManager.score += 100;
        }
    }
}
