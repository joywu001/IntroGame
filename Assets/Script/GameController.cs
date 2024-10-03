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
                // 計算與玩家的距離
                float distance = Vector3.Distance(playerPosition, pickup.transform.position);

                // 找到更近的收集物
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPickup = pickup;
                }

                pickup.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        // 如果找到了最近的收集物，更新距離文本並改變顏色為藍色
        if (closestPickup != null)
        {
            // 更新距離文本
            DistanceText.text = "Pickup Distance: " + closestDistance.ToString("0.00");

            // 將最近的收集物顏色設置為藍色
            closestPickup.GetComponent<Renderer>().material.color = Color.blue;

            // 繪製從玩家到最近收集物的線條
            lineRenderer.SetPosition(0, playerPosition);  // 線條起點為玩家位置
            lineRenderer.SetPosition(1, closestPickup.transform.position);  // 線條終點為收集物位置
        }
        else
        {
            lineRenderer.SetPosition(0, playerPosition);
            lineRenderer.SetPosition(1, playerPosition);
        }
    }
}
