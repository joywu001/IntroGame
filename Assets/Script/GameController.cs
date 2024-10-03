using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] pickups;
    public GameObject player;
    public TextMeshProUGUI DistanceText;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateClosestPickup();
    }

    void UpdateClosestPickup()
    {
        GameObject closestPickup = null;
        float closestDistance = Mathf.Infinity;
        Vector3 playerPosition = player.transform.position;

        foreach (GameObject pickup in pickups)
        {
            if (pickup.activeInHierarchy)
            {
                // �p��P���a���Z��
                float distance = Vector3.Distance(playerPosition, pickup.transform.position);

                // ����񪺦�����
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPickup = pickup;
                }

                pickup.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        // �p�G���F�̪񪺦������A��s�Z���奻�ç����C�⬰�Ŧ�
        if (closestPickup != null)
        {
            // ��s�Z���奻
            DistanceText.text = "Pickup Distance: " + closestDistance.ToString("0.00");

            // �N�̪񪺦������C��]�m���Ŧ�
            closestPickup.GetComponent<Renderer>().material.color = Color.blue;

            // ø�s�q���a��̪񦬶������u��
            lineRenderer.SetPosition(0, playerPosition);  // �u���_�I�����a��m
            lineRenderer.SetPosition(1, closestPickup.transform.position);  // �u�����I����������m
        }
        else
        {
            lineRenderer.SetPosition(0, playerPosition);
            lineRenderer.SetPosition(1, playerPosition);
        }
    }
}
