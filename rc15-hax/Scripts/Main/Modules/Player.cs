using UnityEngine;

namespace Hax;
public class Player : HaxModules {
    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onBackslashPress += Player.RectifyOrientation;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onBackslashPress -= Player.RectifyOrientation;
    }

    public static void Freeze(bool isFrozen) => HaxObjects.PlayerRigidbody.isKinematic = isFrozen;

    public static void RectifyOrientation() => HaxObjects.PlayerRigidbody.rotation = Quaternion.Euler(0.0f, Global.Camera.transform.eulerAngles.y, 0.0f);

    public static void RectifyRoll() => HaxObjects.PlayerRigidbody.rotation = Quaternion.Euler(Global.Camera.transform.eulerAngles.x, Global.Camera.transform.eulerAngles.y, 0.0f);

    public static void EnableCollisions(bool enable) => HaxObjects.PlayerRigidbody.detectCollisions = enable;
}