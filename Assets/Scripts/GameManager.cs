using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject endScreen;
    public GameObject startScreen;
    public GameObject gameUI;
    public TextMeshProUGUI coinsText;


    private void Start()
    {
        Time.timeScale = 0;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (playerMovement.isDead)
        {
            Time.timeScale = 0;
            endScreen.SetActive(true);
            coinsText.text = $"Coins : {playerMovement.coins}";
            gameUI.SetActive(false);
        }
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
