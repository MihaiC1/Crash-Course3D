// SwipeDetector.cs
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public static bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;

    private Vector2 startTouch, swipeDelta;
    private const float deadZone = 50f;

    private void Update()
    {
        ResetSwipes();

        #region Touch
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                startTouch = Input.touches[0].position;
            else if (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Ended)
                swipeDelta = Input.touches[0].position - startTouch;
        }
        #endregion

        #region Mouse (Editor testing)
        if (Input.GetMouseButtonDown(0))
            startTouch = Input.mousePosition;
        else if (Input.GetMouseButtonUp(0))
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
        #endregion

        if (swipeDelta.magnitude > deadZone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                SwipeRight = x > 0;
                SwipeLeft = x < 0;
            }
            else
            {
                SwipeUp = y > 0;
                SwipeDown = y < 0;
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
    }

    private void ResetSwipes()
    {
        SwipeLeft = SwipeRight = SwipeUp = SwipeDown = false;
    }
}
