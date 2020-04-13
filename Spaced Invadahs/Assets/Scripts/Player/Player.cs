using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Movement
{
    WALKING_RIGHT,
    WALKING_LEFT,
    RUNNING_RIGHT,
    RUNNING_LEFT,
    JUMPING_RIGHT,
    JUMPING_LEFT,
    STANDING_LEFT,
    STANDING_RIGHT,
    NOTHING
}

public class Player : MonoBehaviour
{
    public Sprite marioStandsLeft;
    public Sprite marioStandsRight;
    public Sprite marioChangeDirectionLeft;
    public Sprite marioChangeDirectionRight;

    protected int currentAnimationFrame = 0;
    public Sprite[] marioWalkingLeft;
    public Sprite[] marioWalkingRight;

    [HideInInspector] public Movement newGear = Movement.NOTHING;
    [HideInInspector] public Movement currentGear = Movement.NOTHING;

    protected Vector3 moveRightAmount = new Vector3(.2f, 0, 0);
    protected Vector3 moveLeftAmount = new Vector3(-.2f, 0, 0);

    public void MoveRight()
    {
        // Check if Mario can move right

        // Move Mario to the right
        this.gameObject.transform.position += moveRightAmount;

        // update marios sprite
        this.gameObject.GetComponent<SpriteRenderer>().sprite = marioWalkingRight[currentAnimationFrame];
        currentAnimationFrame++;

        if (currentAnimationFrame >= marioWalkingRight.Length) currentAnimationFrame = 0;
    }

    public void MoveLeft()
    {
        // Check if Mario can move left

        // Move Mario to the left
        this.gameObject.transform.position += moveLeftAmount;

        // update marios sprite
        this.gameObject.GetComponent<SpriteRenderer>().sprite = marioWalkingLeft[currentAnimationFrame];
        currentAnimationFrame++;

        if (currentAnimationFrame >= marioWalkingLeft.Length) currentAnimationFrame = 0;
    }

    public void StandRight()
    {
        // Change Mario to stand left
        
    }

    public void StandLeft()
    {
        // Change Mario to stand left

    }

    private float timerLength = 0.025f;
    private float targetTime = 0.01f;

    void Update()
    {
        //print("Update: targetTime="+ targetTime);
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            TimerEnded();
            targetTime = timerLength;
        }

    }

    public void TimerEnded()
    {
        //print("TimerEnded");
        if (newGear != currentGear)
        {
            // Change Mario's Sprite to a new Sprite
            if (newGear == Movement.STANDING_LEFT)
            {
                print("marioChangeDirectionLeft");
                this.gameObject.GetComponent<SpriteRenderer>().sprite = marioChangeDirectionLeft;
            }
            else if (newGear == Movement.STANDING_RIGHT)
            {
                print("marioChangeDirectionRight");
                this.gameObject.GetComponent<SpriteRenderer>().sprite = marioChangeDirectionRight;
            }

            // Change Mario's previousGear to match
            currentGear = newGear;
        } else
        {
            // Keep Mario moving in his current direction
            if (currentGear == Movement.STANDING_LEFT)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = marioStandsLeft;
            }
            else if (currentGear == Movement.STANDING_RIGHT)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = marioStandsRight;
            } else if (currentGear == Movement.WALKING_LEFT)
            {
                MoveLeft();
            }
            else if (currentGear == Movement.WALKING_RIGHT)
            {
                MoveRight();
            }
        }
    }
}