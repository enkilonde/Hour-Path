using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    public AnimationCurve rewindCurve;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

}
