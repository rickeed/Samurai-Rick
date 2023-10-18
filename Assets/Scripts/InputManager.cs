using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerController controller;
    public Animator PlayerAnim;
    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!controller.lookleft)
            {
                PlayerAnim.SetBool("TurnLeft", true);
                controller.lookleft = true;
                Reffl();
                
                
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!controller.lookright)
            {
                PlayerAnim.SetBool("TurnLeft", true);
                controller.lookright = true;
                Reffr();
                
               
                
            }
        }
        
    } 
    

    public void Reffl()
    {
        if (controller.lookleft)
        {
            controller.lookright = false;
            PlayerAnim.SetBool("TurnLeft", true);
        }
        
    }
    public void Reffr()
    {
        if (controller.lookright)
        {
            controller.lookleft = false;
            PlayerAnim.SetBool("TurnLeft", false);
        }
    }
    
    
}
