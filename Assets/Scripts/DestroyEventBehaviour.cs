using System;
using UnityEngine;


public class DestroyEventBehaviour : MonoBehaviour
{
    public event Action OnDestroyEvent;

    private void OnDestroy() {
        OnDestroyEvent?.Invoke();
    }
}