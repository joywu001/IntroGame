using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 moveValue;
    public float speed;
    private int count;

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement*speed*Time.fixedDeltaTime);
    }

    void Start()
    {
        count = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            count++;
            other.gameObject.SetActive(false); 
        }
    }    
}
