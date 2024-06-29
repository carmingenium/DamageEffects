using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMover : MonoBehaviour
{
    void Start()
    {
        // This is just to show that damage numbers and images don't move with enemy, and stay on their own path.
        transform.DOMove(transform.position + new Vector3(2, 0, 0), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
