﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimeManagerScript : MonoBehaviour {

	public float timeStarted;
	public int elapsedTime;
	public string timeInString;
	public char tempChar;
	public int tempLength;
	public GameObject tempNumDisplay;
	public GameObject timeCanvas;

	public int tempNum;
	public int tempNumV2;
	public Image firstNum;
	public Image secondNum;
	public Image thirdNum;
	public Image fourthNum;

	public string minutesStr;
	public string secondsStr;

	public Sprite num0;
	public Sprite num1;
	public Sprite num2;
	public Sprite num3;
	public Sprite num4;
	public Sprite num5;
	public Sprite num6;
	public Sprite num7;
	public Sprite num8;
	public Sprite num9;
	public Sprite period;

	public List<Sprite> listNumImages;
	public List<Image> listDisplayImages;

	public Object timePrefabNum;
	public GameObject timeStartingPos;


	// Use this for initialization

	void Awake(){
		InitializeTime();
	}

	void Start () {

		listNumImages = new List<Sprite>();
		listNumImages.Add (num0);
		listNumImages.Add (num1);
		listNumImages.Add (num2);
		listNumImages.Add (num3);
		listNumImages.Add (num4);
		listNumImages.Add (num5);
		listNumImages.Add (num6);
		listNumImages.Add (num7);
		listNumImages.Add (num8);
		listNumImages.Add (num9);
		listNumImages.Add (period);

		listDisplayImages = new List<Image>();
		listDisplayImages.Add (firstNum);
		listDisplayImages.Add (secondNum);
		listDisplayImages.Add (thirdNum);
		listDisplayImages.Add (fourthNum);


		StartCoroutine (UpdateTime ());

	}

	public void InitializeTime()
	{
		timeStarted = Time.time;
	}

	IEnumerator UpdateTime()
	{
		int minutes;
		int seconds;
		while(true){

			elapsedTime = (int)(Time.time - timeStarted);
			minutes = elapsedTime / 60;
			seconds = elapsedTime % 60;
			/*if(seconds> 9)
			{
				timeInString = minutes.ToString() + seconds.ToString();
			}
			else
			{
				timeInString = minutes.ToString() + "0" + seconds.ToString();
			}
			tempChar = timeInString [0];
			tempLength = timeInString.Length;
			tempNumV2 = 3;
			for(int x=timeInString.Length; x>0; x--){
				tempNum = (int)char.GetNumericValue(timeInString[x-1]);
				listDisplayImages[tempNumV2].sprite = listNumImages[tempNum];
				tempNumV2--;
			}*/
			//Debug.Log ("Minutes: " + minutes);
			//Debug.Log ("Seconds: " + seconds);
			/*tempNumV2 = 3;
			for(int x=0; x<timeInString.Length; x++){
				tempNum = (int)char.GetNumericValue(timeInString[x]);
				listDisplayImages[tempNumV2].sprite = listNumImages[tempNum];
				tempNumV2--;
			}*/
			/* ---------------Start RUSS CODE TIME DISPLAY--- Remove this comment and other codes that are not needed once it's finalised-------------- */
			if(seconds> 9)
			{

				secondsStr = seconds.ToString();
			}
			else
			{
				secondsStr = "0"+seconds.ToString();
			}

			if(minutes>9){
				if(minutes>99){
					minutes = 99;	// temporary fix for exceeding 99 minutes
				}
				minutesStr = minutes.ToString ();
			}
			else{
				minutesStr = "0"+minutes.ToString ();
			}


			tempNum = (int)char.GetNumericValue(secondsStr[1]);
			listDisplayImages[3].sprite = listNumImages[tempNum];

			tempNum = (int)char.GetNumericValue(secondsStr[0]);
			listDisplayImages[2].sprite = listNumImages[tempNum];

			tempNum = (int)char.GetNumericValue(minutesStr[1]);
			listDisplayImages[1].sprite = listNumImages[tempNum];

			tempNum = (int)char.GetNumericValue(minutesStr[0]);
			listDisplayImages[0].sprite = listNumImages[tempNum];

			/* ---------------END RUSS CODE TIME DISPLAY--- Remove this comment and other codes that are not needed once it's finalised-------------- */

			yield return new WaitForSeconds(0.5f);
		}
	}



	public void DisplayTime(){

	}
}
