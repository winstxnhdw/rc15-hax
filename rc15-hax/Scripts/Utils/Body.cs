using UnityEngine;

namespace RC15_HAX;
readonly public struct Body {
    float OriginalMass { get; }
    public float DeltaTime { get; }

    public int ID { get; }
    public float PositionX { get; }
    public float PositionY { get; }
    public float PositionZ { get; }
    public float PreviousPositionX { get; }
    public float PreviousPositionY { get; }
    public float PreviousPositionZ { get; }
    public Rigidbody Rigidbody { get; }

    public Body(int id, Rigidbody rigidbody, float dt) {
        this.ID = id;
        this.Rigidbody = rigidbody;
        this.PositionX = rigidbody.worldCenterOfMass.x;
        this.PositionY = rigidbody.worldCenterOfMass.y;
        this.PositionZ = rigidbody.worldCenterOfMass.z;
        this.PreviousPositionX = rigidbody.worldCenterOfMass.x;
        this.PreviousPositionY = rigidbody.worldCenterOfMass.y;
        this.PreviousPositionZ = rigidbody.worldCenterOfMass.z;
        this.OriginalMass = rigidbody.mass;
        this.DeltaTime = dt;
    }

    public Body(Body body, Rigidbody rigidbody) {
        this.ID = body.ID;
        this.Rigidbody = rigidbody;
        this.PositionX = rigidbody.worldCenterOfMass.x;
        this.PositionY = rigidbody.worldCenterOfMass.y;
        this.PositionZ = rigidbody.worldCenterOfMass.z;
        this.PreviousPositionX = body.PositionX;
        this.PreviousPositionY = body.PositionY;
        this.PreviousPositionZ = body.PositionZ;
        this.OriginalMass = body.OriginalMass;
        this.DeltaTime = body.DeltaTime;
    }

    public Vector3 Position => new Vector3(this.PositionX, this.PositionY, this.PositionZ);

    public Vector3 PreviousPosition => new Vector3(this.PreviousPositionX, this.PreviousPositionY, this.PreviousPositionZ);

    public Vector3 ScreenPosition {
        get {
            Vector3 screenPosition = Global.Camera.WorldToScreenPoint(this.Position);
            return new Vector3(screenPosition.x, Screen.height - screenPosition.y, screenPosition.z);
        }
    }

    public Vector2 ScreenPosition2D => this.ScreenPosition;

    public float Velocity => Vector3.Distance(this.Position, this.PreviousPosition) / this.DeltaTime;

    public string StrVelocity => $"{this.Velocity.ToString("F1")} m/s";

    public float DistanceToCamera => Vector3.Distance(this.Position, Global.Camera.transform.position);

    public string StrDistanceToCamera => $"{this.DistanceToCamera.ToString("F0")} m";

    public string Health => $"{(this.Rigidbody.mass * 100.0f / this.OriginalMass).ToString("F1")}%";

    public string Mass => $"{this.Rigidbody.mass.ToString("F0")} kg";
}