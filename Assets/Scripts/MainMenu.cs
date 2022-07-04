using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{      
    private GameObject player;
    [SerializeField] private Text scoreText;
    public GameObject[] _players;

    void Start()
    {   
        int score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();
        if (SceneManager.GetSceneByName("GameScene").IsValid())
        {
            player = Instantiate(_players[PlayerPrefs.GetInt("Player")],new Vector3(0,0,0) ,Quaternion.identity).GetComponent<GameObject>();
        }
    }

    public void PlayGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }


    public void RecordsScene()
    {
        SceneManager.LoadScene("RecordScene");
    }


    public void RestartLevelScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SetPlayer(int index)
    {
        PlayerPrefs.SetInt("Player", index);
        if (PlayerPrefs.GetInt("Score")>10 )
        {
            PlayerPrefs.SetInt("Player", index);
        }
    }
}
