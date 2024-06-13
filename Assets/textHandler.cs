using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

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
    public void Start()
    {
        transform.DOMove(destinationPoint, 1f).SetEase(Ease.OutCubic).OnComplete(() => Destroy(gameObject));
    }
    public void Update()
    {
        //if (transform.position != destinationPoint)
        //{
        //    MoveText();
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    public void MoveText()
    {
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint, speed * Time.deltaTime);
    }
}
