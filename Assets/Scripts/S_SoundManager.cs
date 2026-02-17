using UnityEngine;
using UnityEngine.UI;

public class S_SoundManager : MonoBehaviour
{
    [SerializeField] Slider volummeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volummeSlider.value;
        Save();
    }

    private void Load()
    {
        volummeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volummeSlider.value);
    }
}
