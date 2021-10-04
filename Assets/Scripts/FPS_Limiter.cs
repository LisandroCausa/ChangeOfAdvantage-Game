using UnityEngine;

public class FPS_Limiter : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
