using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SfxSlider : MonoBehaviour
{
    [SerializeField] private VolumeFader _volumeFader;
    [SerializeField] private string _audioMixerGroupName;
    
    private readonly float MinSliderValue = 0.0001f;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
        LoadPlayerVolume();
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        _volumeFader.ChangeVolume(_audioMixerGroupName, volume);
        PlayerPrefs.SetFloat(_audioMixerGroupName, volume);
    }

    private void LoadPlayerVolume()
    {
        const float MaxSliderValue = 1.0f;
        float savedSliderValue = PlayerPrefs.GetFloat(_audioMixerGroupName, MaxSliderValue);

        if (Mathf.Approximately(savedSliderValue, 0.0f))
        {
            _volumeFader.ChangeVolume(_audioMixerGroupName, MinSliderValue);
        }
        else
        {
            _volumeFader.ChangeVolume(_audioMixerGroupName, savedSliderValue);
        }
    }
}
