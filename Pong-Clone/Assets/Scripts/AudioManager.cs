using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource RacketSoundClip;
    public AudioSource WallSoundClip;
    public AudioSource GoalSoundClip;

    public void PlayRacketSound()
    {
        RacketSoundClip.Play();
    }

    public void PlayWallSound()
    {
        WallSoundClip.Play();
    }

    public void PlayGoalSound()
    {

        GoalSoundClip.Play();
    }
}
