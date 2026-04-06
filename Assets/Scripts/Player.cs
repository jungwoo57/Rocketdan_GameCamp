using UnityEngine;

public class Player : MonoBehaviour
{
    public int damage;
    public int speed;
    public PlayerBullet bulletPrefab;
    public float attackCoolTime;
    public float currentCoolTime;
    public Transform firePoint;

    private bool isMove;
    private EnemyBody target;
    
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
        if (h == 0)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }
        transform.position += Vector3.right * h * speed * Time.deltaTime;
    }

    private void Attack()
    {
        if (isMove)
        {
            PlayerBullet playerBullet = BulletPoolManager.instance.Get();
            playerBullet.Init(Vector3.up, damage, firePoint.position);
            // 총알 위로 발사
        }
        else
        {
            CheckTarget();
            PlayerBullet playerBullet = BulletPoolManager.instance.Get();
            Vector3 dir = (target.gameObject.transform.position - transform.position).normalized;
            playerBullet.Init(dir, damage, firePoint.position);
        }
        currentCoolTime = 0;
    }

    private void CheckTarget()
    {
        float dist = Mathf.Infinity;
        Enemy targetEnemy = StageManager.instance.enemy;
        for (int i = 0; i < targetEnemy.enemyBody.Count; i++)
        {
            float distance = Vector3.Distance(targetEnemy.enemyBody[i].transform.position, transform.position);
            if (distance < dist)
            {
                dist = distance;
                target = targetEnemy.enemyBody[i];
            }
        }
        ;
    }
}
