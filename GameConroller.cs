using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConroller : MonoBehaviour {

	public Text timer;
	float timeLeft = 50.0f;

	public GameObject Panel;
	public GameObject gameOver;
	public GameObject win;

	private AudioSource audio;

	void Start () {
		Time.timeScale = 1f;
		audio = GetComponent<AudioSource> ();
		audio.mute = false;
	}

	void Awake () {
		Panel.SetActive (false);//don't show win panel
		win.SetActive (false);//don't show win message
		gameOver.SetActive (false);//don't show gameover panel

	}

	void Update () {
		SetTimerText ();//timer
	}

	void SetTimerText ()
	{//showing timer 
		timeLeft -= Time.deltaTime;
		timer.text = "Timer: " + Mathf.Round(timeLeft);
		if(timeLeft < 0)
		{
			Time.timeScale = 0f;
			Panel.SetActive (true);//show win panel
			gameOver.SetActive (true);//show gameover panel	
			audio.mute = true;

		}}


	void  OnTriggerEnter2D(Collider2D other) 
		{
			if(other.tag == "Player"){
			Time.timeScale = 0f;
				Panel.SetActive (true);//show win panel
				win.SetActive (true);//show win panel
			audio.mute = true;

			}}

		public void PlayAgain () {
		Application.LoadLevel (Application.loadedLevel);
		}
}
