using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float normalSpeed=1f,speed =1f, abilitySpeed = 1f,abiltyTime = 1f;

    //[SerializeField] private float rotationSpeed = 1f;
    private Vector2 startTouchPosition, endTouchPosition;
    // Start is called before the first frame update
    public bool speedddActivated = false;
    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime*speed);
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && speedddActivated)
        {
            speedddActivated = false;
           StartCoroutine(SpeedSpeed());
            
        }
    }
    private void Move()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (endTouchPosition.x < startTouchPosition.x)
            {
                //left
                print("left");
                rotateLeft();
            }
            if (endTouchPosition.x > startTouchPosition.x)
            {
                //right
                print("right");
                rotaterright();
            }
        }
            

    }
    public void rotateLeft()
    {
        transform.Rotate(new Vector3(0, -90, 0));
    }
    public void rotaterright()
    {

        transform.Rotate(new Vector3(0, 90, 0));
    }

    public void activateSpeeddd(bool a)
    {
        speedddActivated = a;
    }
    IEnumerator SpeedSpeed()
    {
        speed = abilitySpeed;
        yield return new WaitForSeconds(abiltyTime);
        speed = normalSpeed;
    }
}
