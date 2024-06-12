using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textHandler : MonoBehaviour
{
    Vector3 destinationPoint;
    TextMeshProUGUI text;
    public float speed;

    public void Setup(Vector3 dest, string dmg)
    {
        destinationPoint = dest;
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.SetText(dmg);

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
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint, speed * Time.deltaTime *0.1f);
    }
}
