using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 moveValue;
    public float speed;
    private int count;
    private int numPickups = 6; // Put here the number of pickups you have .
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI WinText;

    private Vector3 oldPosition;
    private Vector3 velocity;
    private float scalarSpeed;

    public TextMeshProUGUI PlayerPosition;
    public TextMeshProUGUI PlayerVelocity;

    void Start()
    {
        count = 0;
        WinText.text = " ";
        SetCountText();

        oldPosition = transform.position;
    }

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);
        GetComponent<Rigidbody>().AddForce(movement*speed*Time.fixedDeltaTime);

        CalculateVelocity();
        oldPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        ScoreText.text = " Score : " + count.ToString();
        if (count >= numPickups)
        {
            WinText.text = " You win ! ";
        }
    }

    private void CalculateVelocity()
    {
        velocity = (transform.position - oldPosition)/Time.deltaTime;
        scalarSpeed = velocity.magnitude;

        PlayerPosition.text = "Position: " + transform.position.ToString("0.00");
        PlayerVelocity.text = "Speed: " + scalarSpeed.ToString("0.00");
        
    }
}
