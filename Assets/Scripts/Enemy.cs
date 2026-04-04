using UnityEngine;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    public GameObject enemyHead;
    public List<EnemyBody> enemyBody= new List<EnemyBody>();
    public EnemyBody bodyPrefab;
    //public List<Transform> bodyTrasform = new List<Transform>();
    public int bodyCounts; // 몸통 갯수


    private void Start()
    {
        transform.position = StageManager.instance.startPos.position;
        
        enemyBody.Clear();
        
        // 몸통 생성 
        for (int i = 0; i < bodyCounts; i++)
        {
            EnemyBody newBody = Instantiate(bodyPrefab, Vector3.zero, Quaternion.identity, transform);

            newBody.bodyCount = i;
            newBody.enemy = this;
            Vector3 newBodyPos = transform.position + new Vector3(-i, 0, 0);
            newBody.transform.position = newBodyPos;
            //bodyTrasform.Add(newBody.transform);
            enemyBody.Add(newBody);
        }
        enemyHead.transform.position = enemyBody[0].transform.position;
    }

    private void Update()
    {
        if (bodyCounts > 0)
        {
            int firstBody = 999;
            int temp;
            for (int k = 0; k < enemyBody.Count; k++)
            {
                if (!enemyBody[k].isDead)
                {
                    if (firstBody > enemyBody[k].bodyCount)
                    {
                        firstBody = enemyBody[k].bodyCount;
                    }
                }
            }

            enemyHead.transform.position = enemyBody[firstBody].transform.position;
        }
    }

    public void BodyDie(EnemyBody body)
    {
        int deadIndex = body.bodyCount;
        // 죽은 몸통 비활성화
        //body.gameObject.SetActive(false);

        for (int j = 0; j < enemyBody.Count; j++)
        {
            if (!enemyBody[j].isDead)
            {
                break;
            }
            //게임 종료
        }
        
        // 뒤에 있는 몸통들 앞으로 당기기
        for (int i = 0; i < enemyBody.Count; i++)
        {
            if (enemyBody[i].bodyCount < deadIndex && !enemyBody[i].isDead)
            {
                //enemyBody[i].bodyCount--
                //enemyBody[i].bodyCount++;
                enemyBody[i].transform.position =
                    enemyBody[i+1].transform.position;
            }
        }
        // 당기고 죽은 몸통 비활성화
        body.gameObject.SetActive(false);
        bodyCounts--;

        // 머리 위치 정렬
        
        if (bodyCounts > 0)
        {
            int firstBody = 999;
            for (int k = 0; k < enemyBody.Count; k++)
            {
                if (!enemyBody[k].isDead)
                {
                    if (firstBody > enemyBody[k].bodyCount)
                    {
                        firstBody = enemyBody[k].bodyCount;
                    }
                }
            }
            enemyHead.transform.position = enemyBody[firstBody].transform.position;
        }
    }
}
