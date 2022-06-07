using UnityEngine;

namespace RC15_HAX;
public class Player : HaxModules {
    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onBackslashPress += Player.RectifyOrientation;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onBackslashPress -= Player.RectifyOrientation;
    }

    public static void Freeze(bool isFrozen) => HaxObjects.PlayerRigidbody.Objects[0].rb.isKinematic = isFrozen;

    public static void RectifyOrientation() => HaxObjects.PlayerRigidbody.Objects[0].rb.rotation = Quaternion.Euler(0.0f, Global.Camera.transform.eulerAngles.y, 0.0f);

    public static void RectifyRoll() => HaxObjects.PlayerRigidbody.Objects[0].rb.rotation = Quaternion.Euler(Global.Camera.transform.eulerAngles.x, Global.Camera.transform.eulerAngles.y, 0.0f);

    public static void EnableCollisions(bool enable) => HaxObjects.PlayerRigidbody.Objects[0].rb.detectCollisions = enable;
}