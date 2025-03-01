using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource flapSound;
    public AudioSource collisionSound;
    public AudioSource scoreSound;

    void Start()
    {
        backgroundMusic.Play(); // Play background music on start
        
    }

    public void PlayFlapSound()
    {
        flapSound.Play();
    }

    public void PlayCollisionSound()
    {
        collisionSound.Play();
    }

    public void PlayScoreSound()
    {
        scoreSound.Play();
    }

    public void StopMusic()
    {
        backgroundMusic.Stop();
    }
}
