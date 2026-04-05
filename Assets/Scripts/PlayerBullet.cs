using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Vector3 direction;
    public float speed;
    private int damage;
    public float destroyTime;
    private float currentTime;
    public void Init(Vector3 dir, int damage, Vector3 position)
    {
        this.damage = damage;
        direction = dir;
        transform.position = position;
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= destroyTime)
        {
            BulletPoolManager.instance.Return(this);
        }
        
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBody>().TakeDamage(damage);
        }
        BulletPoolManager.instance.Return(this);
    }
    
}
