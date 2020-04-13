using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    // variable to hold Mario sprite
    public Player goMario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses SPACE bar we'll make Mario Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("SPACE");
        }

        // If Move Mario right
        if ( ( Input.GetKeyDown(KeyCode.Keypad6) ) || (Input.GetKeyDown(KeyCode.RightArrow) ) )
        {
            //print("Keypad6 - Right");
            goMario.newGear = Movement.WALKING_RIGHT;
        } else if ( (Input.GetKeyUp(KeyCode.Keypad6) ) || (Input.GetKeyUp(KeyCode.RightArrow) ) ) {
            //print("Keypad6 Up - Right");
            goMario.newGear = Movement.STANDING_RIGHT;
        }

        // If the player presses KeyPad4 then move Mario left
        if ( (Input.GetKeyDown(KeyCode.Keypad4)) || (Input.GetKeyDown(KeyCode.LeftArrow)) )
        {
            //print("Keypad4 Down - Left");
            goMario.newGear = Movement.WALKING_LEFT;
        } else if ((Input.GetKeyUp(KeyCode.Keypad4)) || (Input.GetKeyUp(KeyCode.LeftArrow)) ) {
            //print("Keypad4 Up - Left");
            goMario.newGear = Movement.STANDING_LEFT;
        }

        // If the player presses Keypad8 then move Mario Up
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            print("Keypad8 - Up");
        }

        // If the player presses Keypad2 then make Mario Crouch
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            print("Keypad2 - Crouch or down pipe");
        }
    }
}
