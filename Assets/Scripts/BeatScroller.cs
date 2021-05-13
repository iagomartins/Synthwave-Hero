using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo = 100.0f;

    public bool hasStarted;
    public GameObject[] buttons;

    public static bool isButtonReady;

    private float counter;
    private int nextButton;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = 240 / beatTempo;

        for (int i = 0; i < buttons.Length; i++) {
            buttons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted) {
            PlayButtonsSequence();
        }
    }

    int RandomButton() {
        int result = Random.Range(0, buttons.Length);
        return result;
    }

    void PlayButtonsSequence() {
        if(counter < beatTempo) {
            counter += Time.deltaTime;
            if(counter > beatTempo / 2 && buttons[nextButton].activeInHierarchy) {
                buttons[nextButton].SetActive(false);
                GameManager.instance.electro -= 20;
            }
        }
        else {
            //TODO
            buttons[nextButton].SetActive(false);
            nextButton = RandomButton();
            buttons[nextButton].SetActive(true);
            counter = 0;
        }
    }

    public void CountPoint() {
        GameManager.instance.electro += GameManager.instance.electro < 100? 7 : 0;
        if (GameManager.instance.electro > 100) {
            GameManager.instance.electro = 100;
        }
        GameManager.instance.playerPoints += 15/counter;
        buttons[nextButton].SetActive(false);
    }
}
