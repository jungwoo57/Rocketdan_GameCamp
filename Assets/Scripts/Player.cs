using UnityEngine;

public class Player : MonoBehaviour
{
    public int damage;
    public int speed;
    public PlayerBullet bulletPrefab;
    public float attackCoolTime;
    public float currentCoolTime;
    public Transform firePoint;
    
    private Transform target;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        currentCoolTime += Time.deltaTime;
        if(attackCoolTime <= currentCoolTime)
        {
            Attack();
        }
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * h * speed * Time.deltaTime;
    }

    private void Attack()
    {
        if (!target)
        {
            PlayerBullet playerBullet = BulletPoolManager.instance.Get();
            playerBullet.Init(Vector3.up, damage, firePoint.position);
            // 총알 위로 발사
        }

        currentCoolTime = 0;
    }
}
