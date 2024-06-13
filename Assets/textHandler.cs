using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;

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
        transform.DOMove(destinationPoint, 1f).SetEase(Ease.OutSine).OnComplete(() => StartCoroutine(WaitBeforeRemoval()));
    }
    IEnumerator WaitBeforeRemoval()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
