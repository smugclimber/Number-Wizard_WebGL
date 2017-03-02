using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NumberWizard : MonoBehaviour {

    public Text guessText;
    public int maxGuessesAllowed = 12;

    int max = 1000;
	int min = 1;
	int guess = 500;
    List<int> guessed = new List<int>();

	void Start () {
        StartGame();
    }
	
	void StartGame () {
        max = max + 1;
        NextGuess();
	}

	public void GuessHigher(){
		min = guess;
        guessed.Add(guess);
        NextGuess();
	}

	public void GuessLower(){
		max = guess;
        guessed.Add(guess);
        NextGuess();
	}

    void NextGuess() {
        guess = Random.Range(min, max);
        int i = 0;
        while (guessed.Contains(guess) & i != 100)
            {
            guess = Random.Range(min, max);
            i++;
            if(i == 99) { Debug.Log("Overcalculated!"); }
            }
        guessed.Add(guess);
        Debug.Log("Guessed " + guessed.Count + "times");
        Debug.Log("Guessed = " + string.Join(", ", new List<int>(guessed).ConvertAll(x => x.ToString()).ToArray()));
        guessText.text = guess.ToString();
        maxGuessesAllowed = maxGuessesAllowed - 1;
        if (maxGuessesAllowed <= 0) {
            Application.LoadLevel("Lose");
            max = 1000;
            min = 1;
            guess = 500;
            }
	}
}
