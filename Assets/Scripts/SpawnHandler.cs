using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public float enemyCount = 2;
    [SerializeField] GameObject enemy;
    [SerializeField] float delay = 10f;
    [SerializeField] float spawn = 0f;
    void Start()
    {
    
    }

    void Update()
    {

        if (Time.time > spawn + delay)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            enemyCount--;

            if (enemyCount < 0)
            {
                Destroy(gameObject);
            }
            

            spawn = Time.time;
        }
    }
}
