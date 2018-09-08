using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	public GameObject LS;
	public GameObject mm;
	public Slider slider;
	public Text ptext;
	//Start Load
	public void LoadLevel(int Index){
		LS.SetActive(true);
		mm.SetActive(false);
		StartCoroutine(LoadAsynchronously(Index));
	}
	//Load the level and update the UI
	IEnumerator LoadAsynchronously(int Index){
		AsyncOperation operation = SceneManager.LoadSceneAsync(Index);
		
		while(!operation.isDone){
			float progress = Mathf.Clamp01(operation.progress /.9f);
			slider.value = progress;
			ptext.text = progress*100f +"%";
			yield return null;
		}
	}
}
