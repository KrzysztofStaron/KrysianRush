using TMPro;
using UnityEngine;

public class scoreSysten : MonoBehaviour
{
    [SerializeField]private TMP_Text scoreText;
    [SerializeField]private Transform camPos;
    [SerializeField]private gameController gc;
    public float score=0;

    void Start(){
      InvokeRepeating("UpdateScore", 0f, 0.25f);
    }

    void UpdateScore()
    {
      if (gc.isGameStarted) {
        score = Mathf.Round (camPos.position.x / 2);
        scoreText.text="Score: " + score;
      }
    }
}
