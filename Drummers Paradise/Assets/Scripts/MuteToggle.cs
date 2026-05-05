using UnityEngine;
using UnityEngine.Audio;

public class MuteToggle : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject mutedSprite;
    public GameObject unmutedSprite;

    private float _savedVolume;
    private bool _isMuted = false;

    void Start()
    {
        mixer.GetFloat("MasterVol", out _savedVolume);
        mutedSprite.SetActive(false);
        unmutedSprite.SetActive(true);
    }

    public void ToggleMute()
    {
        _isMuted = !_isMuted;

        if (_isMuted)
        {
            mixer.GetFloat("MasterVol", out _savedVolume);
            mixer.SetFloat("MasterVol", -80f);
        }
        else
        {
            mixer.SetFloat("MasterVol", _savedVolume);
        }

        mutedSprite.SetActive(_isMuted);
        unmutedSprite.SetActive(!_isMuted);
    }
}
