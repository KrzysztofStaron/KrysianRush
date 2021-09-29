using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
  [Header("Rb:")]
  [SerializeField]private Rigidbody2D playerRb;
  [SerializeField]private Rigidbody2D camRb;
  [Header("Time:")]
  [SerializeField]private float accereration=0.05f;
  [SerializeField]private float limit;
  [Header("Other:")]
  [SerializeField]private float speed = 5;
  public bool isGameStarted;
  [Header("Debuging:")]
  [SerializeField]private float timeScale=1;

  void Awake(){
    timeScale=1;
  }

  void Update()
  {
    //<Time scale managment>
    Time.timeScale = timeScale;
    //accereration
    if (Time.timeScale < limit){
      Time.timeScale += Time.fixedDeltaTime * accereration;
    }
      timeScale=Time.timeScale;
    //</Time scale managment>

      camRb.velocity=new Vector2(speed,0);
      playerRb.velocity=new Vector2(speed,playerRb.velocity.y);
      playerRb.angularVelocity = -200;

      if (!playerRb.gameObject.GetComponent<Renderer>().isVisible && playerRb.position != new Vector2(0,0)){
         kill();
      }
      if (Input.GetKeyDown(KeyCode.R)) {
        kill();
      }
  }

  public void kill()
  {
      SceneManager.LoadScene("game");
  }
}
