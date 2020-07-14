using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Vector2 bulletDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }
    private void MoveBullet()
    {
        transform.Translate(bulletDirection * Time.deltaTime * bulletSpeed, Space.World);
    }
}
