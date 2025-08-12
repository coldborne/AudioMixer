using UnityEngine;
using UnityEngine.Audio;

public class VolumeFader : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private readonly int _volumeModifier = 20;
    private readonly float _minMixerVolume = -80.0f;
    
    public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void ChangeVolume(string audioMixerGroupName, float volume)
    {
        if (volume == 0)
        {
            _audioMixer.SetFloat(audioMixerGroupName, _minMixerVolume);
        }
        else
        {
            _audioMixer.SetFloat(audioMixerGroupName, Mathf.Log10(volume) * _volumeModifier);
        }
        
    }
}
