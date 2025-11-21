using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 Direction;
    private int speed = 5;
    private Animator animator;
    private int health = 100;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (health <= 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        
        Direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        rb.linearVelocity = Direction * speed;

        if (Direction != Vector2.zero)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("death"))
        {
            health -= 1000;
        }
    }
}
