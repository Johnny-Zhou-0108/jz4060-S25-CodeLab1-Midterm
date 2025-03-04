using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            //Debug.Log("Destroying: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
