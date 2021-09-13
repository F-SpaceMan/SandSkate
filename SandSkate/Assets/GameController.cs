
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public TMP_Text pontuacao;
    public TMP_Text pontuacaofinal;
    public TMP_Text pontuacaoFinalCompleted;

    public int points;
    // Start is called before the first frame update
    void Start(){
        points = 0;

        pontuacao.text = ""+points;

        PlayerPrefs.SetInt("points", points);

        pontuacaofinal.text = "Game Over\n\nPontuação: "+PlayerPrefs.GetInt("points");
    
        pontuacaoFinalCompleted.text = "Game Completed\n\nPontuação: "+PlayerPrefs.GetInt("points");
    }

    // Update is called once per frame
    void Update(){

    }
/*
    public void Continue(){
        SceneManager.LoadScene("SampleScene");
    }
*/
    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }

    public void Completed(){
        SceneManager.LoadScene("Completed");
    }

    public void UpdateScore(){
        points++;
        pontuacao.text = ""+points;

        PlayerPrefs.SetInt("points", points);

        pontuacaofinal.text = "Game Over\n\nPontuação: "+PlayerPrefs.GetInt("points");
    
        pontuacaoFinalCompleted.text = "Game Completad\n\nPontuação: "+PlayerPrefs.GetInt("points");

    }
}
