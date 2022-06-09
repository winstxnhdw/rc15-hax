// void AimBot() {
// float closestBodyOnScreen = float.MaxValue;
// Vector2 closestBodyPosition = Vector2.zero;

// foreach (Rigidbody rigidbody in Rigidbodies.Objects) {
//     if (!rigidbody.name.StartsWith("AIB") && rigidbody.name != "RigidBodyParent__") continue;

//     Vector3 rigidbodyWorldPosition = rigidbody.worldCenterOfMass;
//     Vector3 rigidbodyScreenPosition = Global.Camera.WorldToScreenPoint(rigidbodyWorldPosition);

//     if (rigidbodyScreenPosition.z <= 0.0f) continue;
//     rigidbodyScreenPosition.y = Screen.height - rigidbodyScreenPosition.y;

//     Vector2 rigidbodyScreenPosition2D = rigidbodyScreenPosition;
//     float crosshairToBodyDistance = (rigidbodyScreenPosition2D - ScreenInfo.GetScreenCentre()).sqrMagnitude;
//     if (crosshairToBodyDistance < closestBodyOnScreen) {
//         closestBodyOnScreen = crosshairToBodyDistance;
//         closestBodyPosition = rigidbodyScreenPosition2D;
//     }
// }

// Global.Camera.transform.localEulerAngles = new Vector3(-closestBodyPosition.y, closestBodyPosition.x, 0.0f);
// }