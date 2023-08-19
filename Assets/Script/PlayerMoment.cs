using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMech playerMech;
    private float playerSpeed = 5f;
    void Start()
    {
        playerMech = new PlayerMech();
        playerMech.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = playerMech.Player.Move.ReadValue<Vector2>();
       inputVector = inputVector.normalized;
       transform.position += new Vector3(inputVector.x, inputVector.y, 0) * playerSpeed * Time.deltaTime;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("correctanswer")||collision.gameObject.CompareTag("wronganswer"))
        {
            Destroy(collision.gameObject);
            MathManager.instance.QuestionGen();
            if (collision.gameObject.CompareTag("correctanswer"))
            {
                //Spawner.instance.OnEnableRPanel();
                Spawner.instance.Update_score();
            }
        }
        
    }
    
}
