using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance;

    public Transform[] enemyPath;
    public Transform startPos;
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
}