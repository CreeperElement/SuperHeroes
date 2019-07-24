using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveController : MonoBehaviour
{

    public enum Direction { Right, Left }
    private Direction _lastDirection;
    public Direction FacingDirection
    {
        get
        {
            if(DirectionalInput.x >= .75)           { return Direction.Left;
            } else if(DirectionalInput.x <= -.75)   { return Direction.Right;
            } else                                  { return _lastDirection; }
        }
        set { _lastDirection = value; }
    }
    public bool Grounded { get; set; }
    public bool Sprinting { get { return !Grounded && Mathf.Abs(DirectionalInput.x) > .75f; }}

    #region Miscelaneous
    public Vector2 DirectionalInput { get; set; }
    bool Jump { get; set; }
    bool Shield { get; set; }
    bool NeutralAttack { get; set; }
    bool DashAttack { get; set; }
    #endregion

    #region Smash Attacks
    bool ForwardSmash { get; set; }
    bool UpSmash { get; set; }
    bool DownSmash { get; set; }
    #endregion

    #region Special Attacks
    bool NeturalSpecial { get; set; }
    bool SideSpecial { get; set; }
    bool DownSpeciald { get; set; }
    bool UpSpecial { get; set; }
    #endregion

    #region Tilt Attacks
    bool ForwardTilt { get; set; }
    bool UpTilt { get; set; }
    bool DownTilt { get; set; }
    #endregion

    #region Aerials
    bool NeutralAir { get; set; }
    bool BackAir { get; set; }
    bool UpAir { get; set; }
    bool DownAir { get; set; }
    #endregion
}
