using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    void Start()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemy.transform.SetParent(transform, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
