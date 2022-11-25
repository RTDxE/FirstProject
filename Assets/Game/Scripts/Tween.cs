using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Tween : MonoBehaviour
{
    private void OnEnable() {
        transform.DOMove(new Vector3(0, -2, 0), 2f).SetEase(Ease.Linear).From().SetRelative(true);
    }

    private void OnDisable() {
        transform.DOComplete();
    }
}
