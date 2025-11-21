using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private float timer = 7;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        textMesh.text = ((int)Mathf.Ceil(timer)).ToString();

        if (timer <= 0)
        {
            textMesh.text = "Nice!";
        }
    }
}
