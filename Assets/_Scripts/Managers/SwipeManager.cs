using UnityEngine;
public class SwipeManager : MonoBehaviour
{
    public static bool swipeLeft, swipeRight, swipeUp;
    private Vector2 startTouch, swipeDelta;

    void Update()
    {
        swipeLeft = swipeRight = swipeUp = false;

        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
                startTouch = touch.position;
            else if (touch.phase == TouchPhase.Ended)
            {
                swipeDelta = touch.position - startTouch;

                if (swipeDelta.magnitude > 100)
                {
                    float x = swipeDelta.x;
                    float y = swipeDelta.y;

                    if (Mathf.Abs(x) > Mathf.Abs(y))
                        swipeRight = x > 0;
                    else
                        swipeUp = y > 0;
                    swipeLeft = x < 0;
                }

                startTouch = swipeDelta = Vector2.zero;
            }
        }
    }
}
