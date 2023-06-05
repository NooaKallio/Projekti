using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public AudioSource musicAudioSource;  // Reference to the audio source playing the game music
    public Sprite unmutedIcon;            // Sprite for the unmuted button state
    public Sprite mutedIcon;              // Sprite for the muted button state

    private Image buttonImage;            // Reference to the button's Image component
    private bool isMuted = false;         // Flag indicating whether the music is currently muted

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        // Mute or unmute the audio source based on the isMuted flag
        musicAudioSource.mute = isMuted;

        // Change the button's sprite based on the isMuted flag
        buttonImage.sprite = isMuted ? mutedIcon : unmutedIcon;
    }
}
