using UnityEngine;
using UnityEngine.Audio;

public class VolumeFader : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private readonly int _volumeModifier = 20;
    
    public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void ChangeVolume(string audioMixerGroupName, float volume)
    {
        _audioMixer.SetFloat(audioMixerGroupName, Mathf.Log10(volume) * _volumeModifier);
    }
}
