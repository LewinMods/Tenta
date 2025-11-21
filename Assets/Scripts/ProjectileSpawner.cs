using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    private float timer = 0;
    void Start()
    {
        
    }
    
    void Update()
    {
       timer += Time.deltaTime;

       if (timer >= 1)
       {
           timer = 0;
           Instantiate(projectile, transform);
       }
    }
}
