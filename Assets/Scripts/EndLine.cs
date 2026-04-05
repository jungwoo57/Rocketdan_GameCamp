using UnityEngine;

public class EndLine : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StageManager.instance.GameOver(false);
        }
    }
    
}
