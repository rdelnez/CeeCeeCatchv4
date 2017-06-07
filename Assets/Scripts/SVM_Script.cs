﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SVM_Script : MonoBehaviour
{ 
	//public static GameObject advanceDifficulty;
	//public static GameObject advanceDifficultyLock;
	//public static GameObject expertDifficulty;
	//public static GameObject expertDifficultyLock;

	public static string gameDifficulty;
	public static int targetScore = 50;
	public static bool advanceIsLocked = true;
	public static bool expertIsLocked = true;
	public static bool InstructionSeen = false;
	public static bool gameSetup;
	// Make global instance, need to check if the instance is being used by external sources
	public static SVM_Script Instance
	{
		get;
		set;
	}
		
	public GameObject canvas;
	private GameObject loadingScreen;

	public int targetTime;

	public int currentTotalScore;
	public int bonusTime;


	void Awake ()
	{
		DontDestroyOnLoad (transform.gameObject);
		if (Instance == null)
		{
			Instance=this;
		}
		else if(Instance != this)
		{
			Destroy (gameObject);
		}
		//Debug.Log("Rawr means I love you in Dinosaur");
		SceneManager.sceneLoaded += SceneLoadListener;
		SetUpLoadingScreen();			//Establish the loading screen and attach it to the canvas while fixing strange value artifacts
		InitializeSavedVariables();		//Initialize variables that needs to be saved when APP is closed
		LoadSavedVariables();			//Load the variables from Playerprefs
	}

	void SetUpLoadingScreen()
	{
		canvas = GameObject.FindGameObjectWithTag("Canvas");
		loadingScreen = Instantiate(Resources.Load("prefabs/LoadingScreen"))as GameObject;
		loadingScreen.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
		loadingScreen.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
		loadingScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 450);;
		loadingScreen.transform.SetParent(canvas.transform);
		loadingScreen.GetComponent<RectTransform>().localPosition = Vector3.zero;
		loadingScreen.GetComponent<RectTransform>().localScale = Vector3.one;
		loadingScreen.SetActive(false);
	}

	void SceneLoadListener(Scene scene, LoadSceneMode loadMode)
	{
		SetUpLoadingScreen();
	}

	public void InitializeSavedVariables(){
		if (!PlayerPrefs.HasKey("EE_advance"))
		{
			PlayerPrefs.SetInt("EE_advance", 0);
		}
		if (!PlayerPrefs.HasKey("EE_expert"))
		{
			PlayerPrefs.SetInt("EE_expert", 0);
		}
		if (!PlayerPrefs.HasKey("Instructions_Dismissed"))
		{
			PlayerPrefs.SetInt("Instructions_Dismissed", 0);
		}
	}

	public void LoadSavedVariables(){
		if (PlayerPrefs.GetInt("EE_advance") == 1)
		{
			advanceIsLocked = false;
		}
		else
		{
			advanceIsLocked = true;
		}

		if (PlayerPrefs.GetInt("EE_expert") == 1)
		{
			expertIsLocked = false;
		}
		else
		{
			expertIsLocked = true;
		}
		if (PlayerPrefs.GetInt("Instructions_Dismissed") == 1)
		{
			InstructionSeen = true;
		}
		else
		{
			InstructionSeen = false;
		}
	}

	public void LoadLevel(string levelName)
	{
		loadingScreen.SetActive(true);
		StartCoroutine(LevelLoader(levelName));
	}

	IEnumerator LevelLoader(string levelName)
	{
		yield return new WaitForSeconds(0.5f);
		AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(levelName);
		yield return async;
	}
}
