using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class damageTextHandlerOld : MonoBehaviour
{
    Vector3 destinationPoint;
    TextMeshProUGUI text;
    public float speed;
    public void Setup(Vector3 destination, float damage)
    {
        speed = 20f;
        destinationPoint = destination;
        text = GetComponent<TextMeshProUGUI>();
        text.SetText(damage.ToString());
        ColorHandler(damage);
    }
    public void ColorHandler(float damage)
    {
        // min damage 120
        // max damage 150
        if (damage >= 120 && damage <= 130)
        {
            text.color = new Color32(0, 255, 0, 255);
        }
        else if (damage > 130 && damage <= 140)
        {
            text.color = new Color32(120, 120, 0, 255);
        }
        else if (damage > 140 && damage <= 150)
        {
            text.color = new Color32(255, 30, 0, 255);
        }
    }
    public void Update()
    {
        if (transform.position != destinationPoint)
        {
            MoveText();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void MoveText()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint, speed*Time.deltaTime);
    }
}
