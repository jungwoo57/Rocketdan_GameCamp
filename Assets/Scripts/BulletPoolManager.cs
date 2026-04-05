using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager instance;

    public PlayerBullet bulletPrefab;
    public int poolSize;

    private Queue<PlayerBullet> pool = new Queue<PlayerBullet>();

    void Awake()
    {
        instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            PlayerBullet proj = Instantiate(bulletPrefab, transform);
            proj.gameObject.SetActive(false);
            pool.Enqueue(proj);
        }
    }

    public PlayerBullet Get()
    {
        if (pool.Count > 0)
        {
            PlayerBullet proj = pool.Dequeue();
            proj.gameObject.SetActive(true);
            return proj;
        }
        PlayerBullet newProj = Instantiate(bulletPrefab, transform);
        return newProj;
    }

    public void Return(PlayerBullet proj)
    {
        proj.gameObject.SetActive(false);
        pool.Enqueue(proj);
    }
}
