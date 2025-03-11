using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; 
    
    public float minX = -7f;
    public float maxX = 7f;
    public float minY = 0f;
    public float maxY = 4f;

    public float obstacleGap = 1f;
    
    void Start()
    {
        SpawnPrefabs();
    }

    public void SpawnPrefabs()
    {
        bool validPosition = false;
        Vector2 spawnPosition = Vector2.zero;

        while (!validPosition)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            spawnPosition = new Vector2(randomX, randomY);
            
            if (Physics2D.OverlapCircle(spawnPosition, obstacleGap) == null)
            {
                validPosition = true;
            }
        } 
        
        if (validPosition)
        {
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            DebugBox(spawnPosition, new Vector2(0.35f, 0.35f));
        }
    }
    
    void DebugBox(Vector2 position, Vector2 size)
    {
        Debug.DrawLine(position + new Vector2(-size.x / 2, -size.y / 2), position + new Vector2(size.x / 2, -size.y / 2), Color.red, 20f);
        Debug.DrawLine(position + new Vector2(size.x / 2, -size.y / 2), position + new Vector2(size.x / 2, size.y / 2), Color.red, 20f);
        Debug.DrawLine(position + new Vector2(size.x / 2, size.y / 2), position + new Vector2(-size.x / 2, size.y / 2), Color.red, 20f);
        Debug.DrawLine(position + new Vector2(-size.x / 2, size.y / 2), position + new Vector2(-size.x / 2, -size.y / 2), Color.red, 20f);
    }

}