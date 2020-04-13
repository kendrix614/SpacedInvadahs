using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VerticalMovement
{
    FORWARD,
    BACKWARD,
    NOTHING
}

public enum HorizontalMovement
{
    RIGHT,
    LEFT,
    NOTHING
}

public class Player : MonoBehaviour
{
    public GameObject projectileTemplate;

    public Transform projectileSpawnPoint;

    [HideInInspector] public HorizontalMovement horizontalGear = HorizontalMovement.NOTHING;
    [HideInInspector] public VerticalMovement VerticalGear = VerticalMovement.NOTHING;

    protected Vector3 moveRightAmount = new Vector3(.2f, 0, 0);
    protected Vector3 moveLeftAmount = new Vector3(-.2f, 0, 0);
    protected Vector3 moveForwardAmount = new Vector3(0f, .2f, 0);
    protected Vector3 moveBackwardAmount = new Vector3(0, -.2f, 0);

    public void MoveRight()
    {
        // Check if Mario can move right

        // Move Mario to the right
        this.gameObject.transform.position += moveRightAmount;
    }

    public void MoveLeft()
    {
        // Check if Mario can move left

        // Move Mario to the left
        this.gameObject.transform.position += moveLeftAmount;
    }
    public void MoveForward()
    {
        // Check if Mario can move right

        // Move Mario to the right
        this.gameObject.transform.position += moveForwardAmount;
    }

    public void MoveBackward()
    {
        // Check if Mario can move left

        // Move Mario to the left
        this.gameObject.transform.position += moveBackwardAmount;
    }

    public void Shoot()
    {
        Instantiate(projectileTemplate, projectileSpawnPoint.position, Quaternion.identity);
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
        // check if forward or backward
        if (VerticalGear == VerticalMovement.FORWARD)
        {
            MoveForward();
        }
        else if (VerticalGear == VerticalMovement.BACKWARD)
        {
            MoveBackward();
        }
        
        // check if left or right
        if (horizontalGear == HorizontalMovement.LEFT)
        {
            MoveLeft();
        }
        else if (horizontalGear == HorizontalMovement.RIGHT)
        {
            MoveRight();
        }
    }
}