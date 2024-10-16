using UnityEngine;

public class Sound_manager : MonoBehaviour
{
    [Header("---------------Audio Source---------------")]
    [SerializeField] AudioSource musicSorce;
    [SerializeField] AudioSource SFXSorce;

    [Header("---------------Audio Clip---------------")]
    public AudioClip background;
    public AudioClip mouse_sound;


    private void Start()
    {
        musicSorce.clip = background;
        musicSorce.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSorce.PlayOneShot(clip);
    }
}
