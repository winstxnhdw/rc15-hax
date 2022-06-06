using System.Collections;
using UnityEngine;

namespace RC15_HAX;
public class IronWall : HaxComponents {
    // float IronWallIntervals { get; } = HaxSettings.GetFloat("IronWallIntervals"]);

    // protected override void Start() {
    //     base.Start();

    //     if (!bool.Parse(HaxSettings.Params["IronWall"])) return;
    //     StartCoroutine(this.IronWallRoutine());
    // }

    // IEnumerator IronWallRoutine() {
    //     bool ironWallActivate = false;

    //     while (true) {
    //         Rigidbody playerRigidbody = HaxObjects.PlayerRigidbody.Objects[0].rb;

    //         bool isInvulnerable = ironWallActivate && Mathf.RoundToInt(playerRigidbody.velocity.sqrMagnitude) == 0;
    //         Player.Freeze(isInvulnerable);
    //         Player.EnableCollisions(!isInvulnerable);
    //         Console.Print($"isInvulnerable: {isInvulnerable}");
    //         ironWallActivate = !isInvulnerable;

    //         yield return new WaitForSeconds(this.IronWallIntervals);
    //     }
    // }
}