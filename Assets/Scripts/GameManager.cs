using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startMusic;
    public BeatScroller bs;
    public float playerPoints = 0;
    public float electro = 100;
    public bool gameOver = false;
    public TextMeshProUGUI score;
    public TextMeshProUGUI electroText;
    public TextMeshProUGUI finalScore;
    public GameObject gameOverScreen;

    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        gameOverScreen.SetActive(gameOver);
        score.text = "Score: " + Mathf.RoundToInt(playerPoints);
        electroText.text = "Electro: " + Mathf.RoundToInt(electro) + "%";
        if(gameOver) {
            finalScore.text = "Final Score: " + Mathf.RoundToInt(playerPoints);
        }
        if(!startMusic) {
            if(Input.anyKeyDown) {
                startMusic = true;
                bs.hasStarted = true;
                music.Play();
            }
        }
        if(!music.isPlaying && startMusic) {
            Time.timeScale = 0;
            gameOver = true;
        }
        if(electro <= 0) {
            gameOver = true;
            Time.timeScale = 0;
            music.Stop();
        }
    }
}