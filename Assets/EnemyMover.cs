using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // set tween loop, yoyo maybe. needs to keep moving between two positions
        transform.DOMove(transform.position + new Vector3(2, 0, 0), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }
}
