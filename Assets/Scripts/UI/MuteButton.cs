using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteButton : MonoBehaviour
{
    [SerializeField] private VolumeFader _volumeFader;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleMute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleMute);
    }

    private void ToggleMute()
    {
        _volumeFader.ToggleMute();
    }
}