using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeControl : MonoBehaviour
{
    public Slider slider;               // Reference to the slider UI element
    public AudioSource audioSource;     // Reference to the AudioSource component

    private const string volumeKey = "MusicVolume";

    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        // Load the saved volume level from PlayerPrefs or use the default value
        float savedVolume = PlayerPrefs.GetFloat(volumeKey, 0.5f);
        slider.value = savedVolume;
        audioSource.volume = savedVolume;

        // Add a listener to the slider's OnValueChanged event
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float volume)
    {
        // Update the audio source volume
        audioSource.volume = volume;

        // Save the new volume level to PlayerPrefs
        PlayerPrefs.SetFloat(volumeKey, volume);
    }
}
