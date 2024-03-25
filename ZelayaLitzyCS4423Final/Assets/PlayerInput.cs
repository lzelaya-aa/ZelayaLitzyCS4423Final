using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{

    [SerializeField] Libriarian playerCreature;
    ProjectileThrower projectileThrower;
    Rigidbody2D rb;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        projectileThrower = playerCreature.GetComponent<ProjectileThrower>();
    }

    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 input = Vector3.zero;

        if(Input.GetKey(KeyCode.A)){
            input.x += -1;
        }

        if(Input.GetKey(KeyCode.D)){
            input.x += 1;
        }

        if (horizontalInput < 0)
        {
            input.x = -1;
        }
        else if (horizontalInput > 0)
        {
            input.x = 1;
        }

        playerCreature.MovePlayer(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerCreature.Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            projectileThrower.Launch(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        
   

    }
}