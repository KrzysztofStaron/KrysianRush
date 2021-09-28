using TMPro;
using UnityEngine;

public class scoreSysten : MonoBehaviour
{
    [SerializeField]private TMP_Text scoreText;
    [SerializeField]private Transform camPos;
    public float score=0;

    void Start(){
      InvokeRepeating("UpdateScore", 0f, 0.25f);
    }

    void UpdateScore()
    {
      score = Mathf.Round (camPos.position.x / 2);
      scoreText.text="Score: " + score;
    }
}
