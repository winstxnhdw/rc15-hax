using UnityEngine;

namespace RC15_HAX;
public class Player : HaxComponents {
    void Awake() {
        InputListener.onBackslashPress += Player.RectifyOrientation;
    }

    public static void Freeze(bool isFrozen) => HaxObjects.PlayerRigidbody.Objects[0].rb.isKinematic = isFrozen;

    public static void RectifyOrientation() => HaxObjects.PlayerRigidbody.Objects[0].rb.rotation = Quaternion.Euler(0.0f, Global.Camera.transform.eulerAngles.y, 0.0f);

    public static void RectifyRoll() => HaxObjects.PlayerRigidbody.Objects[0].rb.rotation = Quaternion.Euler(Global.Camera.transform.eulerAngles.x, Global.Camera.transform.eulerAngles.y, 0.0f);

    void OnDestroy() {
        InputListener.onBackslashPress -= Player.RectifyOrientation;
    }
}