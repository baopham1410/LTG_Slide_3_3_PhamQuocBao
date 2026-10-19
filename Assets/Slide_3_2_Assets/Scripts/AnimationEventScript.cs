using UnityEngine;

/// <summary>
/// Practice Slide 3.2 — Animation Event trên Standing Greeting.
/// Gắn script này lên X Bot. Ở frame 60 gọi AnimationEventFunction.
/// </summary>
public class AnimationEventScript : MonoBehaviour
{
    /// <summary>
    /// Hàm được Animation Event gọi.
    /// Parameter string truyền từ Animation Event (vd: "Hello World!").
    /// </summary>
    public void AnimationEventFunction(string message)
    {
        Debug.Log(message);
    }
}
