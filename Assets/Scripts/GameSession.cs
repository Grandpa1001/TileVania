using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour {

[SerializeField] int playerLives = 3;
[SerializeField] int score =	0;
[SerializeField] int levelNumber;
// UI
[SerializeField] Text livesText;
[SerializeField] Text scoreText;


	private void Awake(){
		int numGameSessions = FindObjectsOfType<GameSession>().Length;
		if( numGameSessions > 1){
			Destroy(gameObject);
		}else{
			DontDestroyOnLoad(gameObject);
		}
	}



	void Start () {
		livesText.text = playerLives.ToString();
		scoreText.text = score.ToString();

	}

public void AddToScore(int pointsToAdd){
	score += pointsToAdd;
	scoreText.text = score.ToString();
}


	public void ProcessPlayerDeath(){
		if( playerLives > 0){
			TakeLife();
		}else{
			//var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
			//SceneManager.LoadScene(currentSceneIndex);
			ResetGameSession();
		}
	}

private void TakeLife(){
	playerLives--;

	livesText.text = playerLives.ToString();
}

	private void ResetGameSession(){
		//StartCoroutine(LoadNextLevel());
		SceneManager.LoadScene(0);
		Destroy(gameObject);
	}

/*
	IEnumerator DeathAnimation(){

			Time.timeScale = LevelExitSlowMoFactor;
			yield return new WaitForSecondsRealtime(LevelLoadDelay);
			Time.timeScale = 1f;
			var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(currentSceneIndex+ 1 );
	} */



}
