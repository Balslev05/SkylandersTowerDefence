using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] private WaveManager waveManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && collision.GetComponent<EnemyBase>().wayPointManager == waveManager.RightWayPointManager)
        {
            collision.tag = "UnderTunnelEnemy";
            collision.GetComponent<EnemyBase>().GFX.SetActive(false);       
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "UnderTunnelEnemy")
        {
            collision.tag = "Enemy";
            collision.GetComponent <EnemyBase>().GFX.SetActive(true);
        }
    }
}
