using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private GameObject audioObject;
    private AudioSource audioSource;
    private Slider slider;

    void Start()
    {
        audioObject = GameObject.Find("2DMusic");
        if (audioObject != null)
        {
            audioSource = audioObject.GetComponentInChildren<AudioSource>();

            slider = GetComponent<Slider>();
        }
    }

    void Update()
    {
        if (audioSource != null && slider != null)
        {
            audioSource.volume = slider.value;
        }
    }
}