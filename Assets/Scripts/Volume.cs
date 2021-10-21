using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour 
{

	public Slider volumeSlider;
	float currentVolume;
	void Start()
	{
		//PlayerPrefs.DeleteAll();
		if(!PlayerPrefs.HasKey("SliderVolumeLevel")) 
			PlayerPrefs.SetFloat("SliderVolumeLevel",1f);
		AudioListener.volume = PlayerPrefs.GetFloat("SliderVolumeLevel");
		volumeSlider.value = PlayerPrefs.GetFloat("SliderVolumeLevel");
	}
	void Update()
	{
    	AudioListener.volume = volumeSlider.value;
		PlayerPrefs.SetFloat("SliderVolumeLevel", AudioListener.volume);
 	}
}
