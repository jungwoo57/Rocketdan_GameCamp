using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    public Transform[] enemyPath;
    public Transform startPos;

    public GameObject endLine;    
    
    public Enemy enemyPrefab;
    public Image winUI;
    public Image loseUI;
    
    
    
    private bool isGameOver = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 넘어가도 유지
        }
        else
        {
            Destroy(gameObject); // 중복 제거
        }
    }

    public void StageInit()
    {
        isGameOver = false;
        winUI.gameObject.SetActive(false);
        loseUI.gameObject.SetActive(false);
    }
    
    public void GameStart()
    {
        Enemy stageEnemy = Instantiate(enemyPrefab);
    }
    
    public void GameOver(bool win)
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0;
        if (win)
        {
            winUI.gameObject.SetActive(true);
        }
        else
        {
            loseUI.gameObject.SetActive(true);
        }

        Time.timeScale = 0;
        
    }
    
}