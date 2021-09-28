using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class jumping : MonoBehaviour
{
    [SerializeField]private float jumpHeight;
    [SerializeField]private Rigidbody2D rb;

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)) {
        Jump();
      }
    }

    public void Jump(){
      rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
