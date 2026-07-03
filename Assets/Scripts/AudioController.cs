using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;

    public AudioData audioData;

    private Image image;
    public Sprite[] sprites;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        image = GetComponent<Image>();

        if(SceneManager.GetActiveScene().name == "Menu")
            audioSource.clip = audioClips[0];
        else
            audioSource.clip = audioClips[1];

        if (audioData.som)
        {
            audioSource.Play();
            image.sprite = sprites[0];
        }
        else
        {
            audioSource.Stop();
            image.sprite = sprites[1];
        }   
    }

    public void SemAudio()
    {
        audioData.som = !audioData.som;

        if (audioData.som)
        {
            audioSource.Play();
            image.sprite = sprites[0];
        }
        else
        {
            audioSource.Stop();
            image.sprite = sprites[1];
        }
    }
}
