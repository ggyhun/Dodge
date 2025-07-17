using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject gameOverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameOver;
    void Start() {
        surviveTime = 0;
        isGameOver = false;
    }

    void Update() {
        if (!isGameOver) {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        } else {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame() {
        isGameOver = true;
        gameOverText.SetActive(false);
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if (surviveTime > bestTime) {
            PlayerPrefs.SetFloat("BestTime", surviveTime);
            recordText.text = "New Record: " + (int)surviveTime;
        }
        recordText.text = "Best TIme: " + (int) bestTime;
    }
}
