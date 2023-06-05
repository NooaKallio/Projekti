using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    private void Start()
    {
        // Set the initial volume value based on the current audio listener volume
        volumeSlider.value = AudioListener.volume;

        // Add a listener for value changes to update the volume
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float volume)
    {
        // Update the volume of the AudioListener based on the slider value
        AudioListener.volume = volume;
    }
}