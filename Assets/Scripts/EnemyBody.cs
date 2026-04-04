using System;
using UnityEngine;
using System.Collections.Generic;
public class EnemyBody : MonoBehaviour
{
    public int bodyCount; // 몇번 째 몸통인지
    public int hp;
    public float speed;
    
    public Enemy enemy;
    public bool isDead;
    public List<Transform> enemyPath = new List<Transform>();
    private int pathCount;
    
    private void Start()
    {
        //경로 초기화
        for (int i = 0; i < StageManager.instance.enemyPath.Length; i++)
        {
            enemyPath.Add(StageManager.instance.enemyPath[i]);
        }
    }

    private void Update()
    {
        BodyMove();
    }

    [ContextMenu("죽여보기")]
    private void BodyDie()
    {
        enemy.BodyDie(this);
        isDead = true;
        this.gameObject.SetActive(false);
        
    }

    private void BodyMove()
    {
        Vector3 dir = enemyPath[pathCount].position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position,enemyPath[pathCount].transform.position);
        if (distance <= 1)
        {
            pathCount++;
        }
    }
    
    
}
