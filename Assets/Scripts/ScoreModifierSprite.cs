﻿using UnityEngine;
using System.Collections;

public class ScoreModifierSprite : MonoBehaviour {

	private float speed;
	private SpriteRenderer spriteRend;
	private bool isMooving;
	void Awake()
	{
		spriteRend = GetComponent<SpriteRenderer>();
		speed = 10f;
	}

	public void SetNumber(int aValue, bool positiveVal, bool isMoving)
	{
		if(positiveVal)
		{
			spriteRend.sprite = Resources.Load<Sprite>("Sprites/GamePlayNum/" + aValue + "plus");
		}
		else
		{
			spriteRend.sprite = Resources.Load("Sprites/GamePlayNum/" + aValue + "minus") as Sprite;
		}
		isMooving = isMoving;
		Destroy(gameObject, 5f);
		StartCoroutine(Animate());
	}

	IEnumerator Animate()
	{

		while(true)
		{
			if(isMooving)
			{
				transform.position += Vector3.up * (speed * Time.deltaTime);
			}
			Color temp = spriteRend.color;
			temp.a -= 0.05f;
			spriteRend.color = temp;
			yield return new WaitForSeconds(0.05f);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}