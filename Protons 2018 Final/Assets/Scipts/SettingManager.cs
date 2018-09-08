using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class SettingManager : MonoBehaviour {

	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown qualityDropdown;
	public Dropdown AADropdown;
	public Dropdown VSyncDropdown;
	public Slider volumeSlider;
	public Button AcceptButton;
	
	//public GameObject parent;
	//AudioSource[] sources;
	public Resolution[] resolutions;
	public GameSettings gs;
	public Buttons buttons;
	//ON START
	public void OnEnable(){
		gs = new GameSettings();
		//sources = parent.GetComponent<AudioSource>()as AudioSource[];
		//Debug.Log(sources);
		
		fullscreenToggle.onValueChanged.AddListener(delegate{ OnFullscreenToggle(); });
		resolutionDropdown.onValueChanged.AddListener(delegate{OnResolutionChange();});
		qualityDropdown.onValueChanged.AddListener(delegate{OnQualityChange();});
		AADropdown.onValueChanged.AddListener(delegate{OnAAChange();});
		VSyncDropdown.onValueChanged.AddListener(delegate{OnVSyncChange();});
		volumeSlider.onValueChanged.AddListener(delegate{OnVolumeChange();});
		AcceptButton.onClick.AddListener(delegate{OnApplyClick();});
		
		resolutions = Screen.resolutions;
		foreach(Resolution resolution in resolutions){
			resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
		}
		LoadSettings();
	}	

	public void OnFullscreenToggle(){
		gs.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}
	public void OnResolutionChange(){
		Screen.SetResolution(resolutions[resolutionDropdown.value].width,resolutions[resolutionDropdown.value].height,Screen.fullScreen);
		gs.resolution = resolutionDropdown.value;
	}
	public void OnQualityChange(){
		QualitySettings.masterTextureLimit = gs.quality = qualityDropdown.value;
	}
	public void OnAAChange(){
		QualitySettings.antiAliasing = gs.antialiasing= (int)Mathf.Pow(2f, AADropdown.value);
	}
	public void OnVSyncChange(){
		QualitySettings.vSyncCount = gs.vsync = VSyncDropdown.value;
	}
	public void OnVolumeChange(){
		AudioListener.volume = gs.volume = volumeSlider.value;
	}
	public void OnApplyClick(){
		SaveSettings();
		buttons.MainMenu();
	}
	public  void SaveSettings(){
		string jsonData = JsonUtility.ToJson(gs, true);
		File.WriteAllText(Application.persistentDataPath + "/settings.json",jsonData);
	}
	public  void LoadSettings(){
		gs = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/settings.json"));
		volumeSlider.value = gs.volume;
		AADropdown.value = gs.antialiasing;
		qualityDropdown.value = gs.quality;
		VSyncDropdown.value = gs.vsync;
		resolutionDropdown.value = gs.resolution;
		fullscreenToggle.isOn = gs.fullscreen;
		
		resolutionDropdown.RefreshShownValue();
		AudioListener.volume = gs.volume;
		//foreach(AudioSource audiosource in sources){
		//	audiosource.volume = gs.volume;
		//}
		
	}

}
