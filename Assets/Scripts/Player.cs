using UnityEngine;

public class Player : MonoBehaviour
{
    public int damage;
    public int speed;
    public PlayerBullet bulletPrefab;
    private Transform target;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
            // 총알 위로 발사
        }
    }
}
