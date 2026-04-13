using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource[] audioSources;
    public int selectedIndex;

    public void PlaySelected()
    {
        if (selectedIndex >= 0 && selectedIndex < clips.Length && selectedIndex < audioSources.Length)
        {
            audioSources[selectedIndex].clip = clips[selectedIndex];
            audioSources[selectedIndex].Play();
        }
    }

    public void StopSelected()
    {
        if (selectedIndex >= 0 && selectedIndex < audioSources.Length)
        {
            audioSources[selectedIndex].Stop();
        }
    }

    public void PauseSelected()
    {
        if (selectedIndex >= 0 && selectedIndex < audioSources.Length)
        {
            audioSources[selectedIndex].Pause();
        }
    }

    public void ResumeSelected()
    {
        if (selectedIndex >= 0 && selectedIndex < audioSources.Length)
        {
            audioSources[selectedIndex].UnPause();
        }
    }
}
