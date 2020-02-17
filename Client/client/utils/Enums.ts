﻿export enum Alignment {
    Left,
    Centered,
    Right,
}

export enum Bone {
    SKEL_ROOT = 0,
    FB_R_Brow_Out_000 = 1356,
    SKEL_L_Toe0 = 2108,
    MH_R_Elbow = 2992,
    SKEL_L_Finger01 = 4089,
    SKEL_L_Finger02 = 4090,
    SKEL_L_Finger31 = 4137,
    SKEL_L_Finger32 = 4138,
    SKEL_L_Finger41 = 4153,
    SKEL_L_Finger42 = 4154,
    SKEL_L_Finger11 = 4169,
    SKEL_L_Finger12 = 4170,
    SKEL_L_Finger21 = 4185,
    SKEL_L_Finger22 = 4186,
    RB_L_ArmRoll = 5232,
    IK_R_Hand = 6286,
    RB_R_ThighRoll = 6442,
    SKEL_R_Clavicle = 10706,
    FB_R_Lip_Corner_000 = 11174,
    SKEL_Pelvis = 11816,
    IK_Head = 12844,
    SKEL_L_Foot = 14201,
    MH_R_Knee = 16335,
    FB_LowerLipRoot_000 = 17188,
    FB_R_Lip_Top_000 = 17719,
    SKEL_L_Hand = 18905,
    FB_R_CheekBone_000 = 19336,
    FB_UpperLipRoot_000 = 20178,
    FB_L_Lip_Top_000 = 20279,
    FB_LowerLip_000 = 20623,
    SKEL_R_Toe0 = 20781,
    FB_L_CheekBone_000 = 21550,
    MH_L_Elbow = 22711,
    SKEL_Spine0 = 23553,
    RB_L_ThighRoll = 23639,
    PH_R_Foot = 24806,
    SKEL_Spine1 = 24816,
    SKEL_Spine2 = 24817,
    SKEL_Spine3 = 24818,
    FB_L_Eye_000 = 25260,
    SKEL_L_Finger00 = 26610,
    SKEL_L_Finger10 = 26611,
    SKEL_L_Finger20 = 26612,
    SKEL_L_Finger30 = 26613,
    SKEL_L_Finger40 = 26614,
    FB_R_Eye_000 = 27474,
    SKEL_R_Forearm = 28252,
    PH_R_Hand = 28422,
    FB_L_Lip_Corner_000 = 29868,
    SKEL_Head = 31086,
    IK_R_Foot = 35502,
    RB_Neck_1 = 35731,
    IK_L_Hand = 36029,
    SKEL_R_Calf = 36864,
    RB_R_ArmRoll = 37119,
    FB_Brow_Centre_000 = 37193,
    SKEL_Neck_1 = 39317,
    SKEL_R_UpperArm = 40269,
    FB_R_Lid_Upper_000 = 43536,
    RB_R_ForeArmRoll = 43810,
    SKEL_L_UpperArm = 45509,
    FB_L_Lid_Upper_000 = 45750,
    MH_L_Knee = 46078,
    FB_Jaw_000 = 46240,
    FB_L_Lip_Bot_000 = 47419,
    FB_Tongue_000 = 47495,
    FB_R_Lip_Bot_000 = 49979,
    SKEL_R_Thigh = 51826,
    SKEL_R_Foot = 52301,
    IK_Root = 56604,
    SKEL_R_Hand = 57005,
    SKEL_Spine_Root = 57597,
    PH_L_Foot = 57717,
    SKEL_L_Thigh = 58271,
    FB_L_Brow_Out_000 = 58331,
    SKEL_R_Finger00 = 58866,
    SKEL_R_Finger10 = 58867,
    SKEL_R_Finger20 = 58868,
    SKEL_R_Finger30 = 58869,
    SKEL_R_Finger40 = 58870,
    PH_L_Hand = 60309,
    RB_L_ForeArmRoll = 61007,
    SKEL_L_Forearm = 61163,
    FB_UpperLip_000 = 61839,
    SKEL_L_Calf = 63931,
    SKEL_R_Finger01 = 64016,
    SKEL_R_Finger02 = 64017,
    SKEL_R_Finger31 = 64064,
    SKEL_R_Finger32 = 64065,
    SKEL_R_Finger41 = 64080,
    SKEL_R_Finger42 = 64081,
    SKEL_R_Finger11 = 64096,
    SKEL_R_Finger12 = 64097,
    SKEL_R_Finger21 = 64112,
    SKEL_R_Finger22 = 64113,
    SKEL_L_Clavicle = 64729,
    FACIAL_facialRoot = 65068,
    IK_L_Foot = 65245
}

export enum Control {
    NextCamera = 0,
    LookLeftRight = 1,
    LookUpDown = 2,
    LookUpOnly = 3,
    LookDownOnly = 4,
    LookLeftOnly = 5,
    LookRightOnly = 6,
    CinematicSlowMo = 7,
    FlyUpDown = 8,
    FlyLeftRight = 9,
    ScriptedFlyZUp = 10,
    ScriptedFlyZDown = 11,
    WeaponWheelUpDown = 12,
    WeaponWheelLeftRight = 13,
    WeaponWheelNext = 14,
    WeaponWheelPrev = 15,
    SelectNextWeapon = 16,
    SelectPrevWeapon = 17,
    SkipCutscene = 18,
    CharacterWheel = 19,
    MultiplayerInfo = 20,
    Sprint = 21,
    Jump = 22,
    Enter = 23,
    Attack = 24,
    Aim = 25,
    LookBehind = 26,
    Phone = 27,
    SpecialAbility = 28,
    SpecialAbilitySecondary = 29,
    MoveLeftRight = 30,
    MoveUpDown = 31,
    MoveUpOnly = 32,
    MoveDownOnly = 33,
    MoveLeftOnly = 34,
    MoveRightOnly = 35,
    Duck = 36,
    SelectWeapon = 37,
    Pickup = 38,
    SniperZoom = 39,
    SniperZoomInOnly = 40,
    SniperZoomOutOnly = 41,
    SniperZoomInSecondary = 42,
    SniperZoomOutSecondary = 43,
    Cover = 44,
    Reload = 45,
    Talk = 46,
    Detonate = 47,
    HUDSpecial = 48,
    Arrest = 49,
    AccurateAim = 50,
    Context = 51,
    ContextSecondary = 52,
    WeaponSpecial = 53,
    WeaponSpecial2 = 54,
    Dive = 55,
    DropWeapon = 56,
    DropAmmo = 57,
    ThrowGrenade = 58,
    VehicleMoveLeftRight = 59,
    VehicleMoveUpDown = 60,
    VehicleMoveUpOnly = 61,
    VehicleMoveDownOnly = 62,
    VehicleMoveLeftOnly = 63,
    VehicleMoveRightOnly = 64,
    VehicleSpecial = 65,
    VehicleGunLeftRight = 66,
    VehicleGunUpDown = 67,
    VehicleAim = 68,
    VehicleAttack = 69,
    VehicleAttack2 = 70,
    VehicleAccelerate = 71,
    VehicleBrake = 72,
    VehicleDuck = 73,
    VehicleHeadlight = 74,
    VehicleExit = 75,
    VehicleHandbrake = 76,
    VehicleHotwireLeft = 77,
    VehicleHotwireRight = 78,
    VehicleLookBehind = 79,
    VehicleCinCam = 80,
    VehicleNextRadio = 81,
    VehiclePrevRadio = 82,
    VehicleNextRadioTrack = 83,
    VehiclePrevRadioTrack = 84,
    VehicleRadioWheel = 85,
    VehicleHorn = 86,
    VehicleFlyThrottleUp = 87,
    VehicleFlyThrottleDown = 88,
    VehicleFlyYawLeft = 89,
    VehicleFlyYawRight = 90,
    VehiclePassengerAim = 91,
    VehiclePassengerAttack = 92,
    VehicleSpecialAbilityFranklin = 93,
    VehicleStuntUpDown = 94,
    VehicleCinematicUpDown = 95,
    VehicleCinematicUpOnly = 96,
    VehicleCinematicDownOnly = 97,
    VehicleCinematicLeftRight = 98,
    VehicleSelectNextWeapon = 99,
    VehicleSelectPrevWeapon = 100,
    VehicleRoof = 101,
    VehicleJump = 102,
    VehicleGrapplingHook = 103,
    VehicleShuffle = 104,
    VehicleDropProjectile = 105,
    VehicleMouseControlOverride = 106,
    VehicleFlyRollLeftRight = 107,
    VehicleFlyRollLeftOnly = 108,
    VehicleFlyRollRightOnly = 109,
    VehicleFlyPitchUpDown = 110,
    VehicleFlyPitchUpOnly = 111,
    VehicleFlyPitchDownOnly = 112,
    VehicleFlyUnderCarriage = 113,
    VehicleFlyAttack = 114,
    VehicleFlySelectNextWeapon = 115,
    VehicleFlySelectPrevWeapon = 116,
    VehicleFlySelectTargetLeft = 117,
    VehicleFlySelectTargetRight = 118,
    VehicleFlyVerticalFlightMode = 119,
    VehicleFlyDuck = 120,
    VehicleFlyAttackCamera = 121,
    VehicleFlyMouseControlOverride = 122,
    VehicleSubTurnLeftRight = 123,
    VehicleSubTurnLeftOnly = 124,
    VehicleSubTurnRightOnly = 125,
    VehicleSubPitchUpDown = 126,
    VehicleSubPitchUpOnly = 127,
    VehicleSubPitchDownOnly = 128,
    VehicleSubThrottleUp = 129,
    VehicleSubThrottleDown = 130,
    VehicleSubAscend = 131,
    VehicleSubDescend = 132,
    VehicleSubTurnHardLeft = 133,
    VehicleSubTurnHardRight = 134,
    VehicleSubMouseControlOverride = 135,
    VehiclePushbikePedal = 136,
    VehiclePushbikeSprint = 137,
    VehiclePushbikeFrontBrake = 138,
    VehiclePushbikeRearBrake = 139,
    MeleeAttackLight = 140,
    MeleeAttackHeavy = 141,
    MeleeAttackAlternate = 142,
    MeleeBlock = 143,
    ParachuteDeploy = 144,
    ParachuteDetach = 145,
    ParachuteTurnLeftRight = 146,
    ParachuteTurnLeftOnly = 147,
    ParachuteTurnRightOnly = 148,
    ParachutePitchUpDown = 149,
    ParachutePitchUpOnly = 150,
    ParachutePitchDownOnly = 151,
    ParachuteBrakeLeft = 152,
    ParachuteBrakeRight = 153,
    ParachuteSmoke = 154,
    ParachutePrecisionLanding = 155,
    Map = 156,
    SelectWeaponUnarmed = 157,
    SelectWeaponMelee = 158,
    SelectWeaponHandgun = 159,
    SelectWeaponShotgun = 160,
    SelectWeaponSmg = 161,
    SelectWeaponAutoRifle = 162,
    SelectWeaponSniper = 163,
    SelectWeaponHeavy = 164,
    SelectWeaponSpecial = 165,
    SelectCharacterMichael = 166,
    SelectCharacterFranklin = 167,
    SelectCharacterTrevor = 168,
    SelectCharacterMultiplayer = 169,
    SaveReplayClip = 170,
    SpecialAbilityPC = 171,
    PhoneUp = 172,
    PhoneDown = 173,
    PhoneLeft = 174,
    PhoneRight = 175,
    PhoneSelect = 176,
    PhoneCancel = 177,
    PhoneOption = 178,
    PhoneExtraOption = 179,
    PhoneScrollForward = 180,
    PhoneScrollBackward = 181,
    PhoneCameraFocusLock = 182,
    PhoneCameraGrid = 183,
    PhoneCameraSelfie = 184,
    PhoneCameraDOF = 185,
    PhoneCameraExpression = 186,
    FrontendDown = 187,
    FrontendUp = 188,
    FrontendLeft = 189,
    FrontendRight = 190,
    FrontendRdown = 191,
    FrontendRup = 192,
    FrontendRleft = 193,
    FrontendRright = 194,
    FrontendAxisX = 195,
    FrontendAxisY = 196,
    FrontendRightAxisX = 197,
    FrontendRightAxisY = 198,
    FrontendPause = 199,
    FrontendPauseAlternate = 200,
    FrontendAccept = 201,
    FrontendCancel = 202,
    FrontendX = 203,
    FrontendY = 204,
    FrontendLb = 205,
    FrontendRb = 206,
    FrontendLt = 207,
    FrontendRt = 208,
    FrontendLs = 209,
    FrontendRs = 210,
    FrontendLeaderboard = 211,
    FrontendSocialClub = 212,
    FrontendSocialClubSecondary = 213,
    FrontendDelete = 214,
    FrontendEndscreenAccept = 215,
    FrontendEndscreenExpand = 216,
    FrontendSelect = 217,
    ScriptLeftAxisX = 218,
    ScriptLeftAxisY = 219,
    ScriptRightAxisX = 220,
    ScriptRightAxisY = 221,
    ScriptRUp = 222,
    ScriptRDown = 223,
    ScriptRLeft = 224,
    ScriptRRight = 225,
    ScriptLB = 226,
    ScriptRB = 227,
    ScriptLT = 228,
    ScriptRT = 229,
    ScriptLS = 230,
    ScriptRS = 231,
    ScriptPadUp = 232,
    ScriptPadDown = 233,
    ScriptPadLeft = 234,
    ScriptPadRight = 235,
    ScriptSelect = 236,
    CursorAccept = 237,
    CursorCancel = 238,
    CursorX = 239,
    CursorY = 240,
    CursorScrollUp = 241,
    CursorScrollDown = 242,
    EnterCheatCode = 243,
    InteractionMenu = 244,
    MpTextChatAll = 245,
    MpTextChatTeam = 246,
    MpTextChatFriends = 247,
    MpTextChatCrew = 248,
    PushToTalk = 249,
    CreatorLS = 250,
    CreatorRS = 251,
    CreatorLT = 252,
    CreatorRT = 253,
    CreatorMenuToggle = 254,
    CreatorAccept = 255,
    CreatorDelete = 256,
    Attack2 = 257,
    RappelJump = 258,
    RappelLongJump = 259,
    RappelSmashWindow = 260,
    PrevWeapon = 261,
    NextWeapon = 262,
    MeleeAttack1 = 263,
    MeleeAttack2 = 264,
    Whistle = 265,
    MoveLeft = 266,
    MoveRight = 267,
    MoveUp = 268,
    MoveDown = 269,
    LookLeft = 270,
    LookRight = 271,
    LookUp = 272,
    LookDown = 273,
    SniperZoomIn = 274,
    SniperZoomOut = 275,
    SniperZoomInAlternate = 276,
    SniperZoomOutAlternate = 277,
    VehicleMoveLeft = 278,
    VehicleMoveRight = 279,
    VehicleMoveUp = 280,
    VehicleMoveDown = 281,
    VehicleGunLeft = 282,
    VehicleGunRight = 283,
    VehicleGunUp = 284,
    VehicleGunDown = 285,
    VehicleLookLeft = 286,
    VehicleLookRight = 287,
    ReplayStartStopRecording = 288,
    ReplayStartStopRecordingSecondary = 289,
    ScaledLookLeftRight = 290,
    ScaledLookUpDown = 291,
    ScaledLookUpOnly = 292,
    ScaledLookDownOnly = 293,
    ScaledLookLeftOnly = 294,
    ScaledLookRightOnly = 295,
    ReplayMarkerDelete = 296,
    ReplayClipDelete = 297,
    ReplayPause = 298,
    ReplayRewind = 299,
    ReplayFfwd = 300,
    ReplayNewmarker = 301,
    ReplayRecord = 302,
    ReplayScreenshot = 303,
    ReplayHidehud = 304,
    ReplayStartpoint = 305,
    ReplayEndpoint = 306,
    ReplayAdvance = 307,
    ReplayBack = 308,
    ReplayTools = 309,
    ReplayRestart = 310,
    ReplayShowhotkey = 311,
    ReplayCycleMarkerLeft = 312,
    ReplayCycleMarkerRight = 313,
    ReplayFOVIncrease = 314,
    ReplayFOVDecrease = 315,
    ReplayCameraUp = 316,
    ReplayCameraDown = 317,
    ReplaySave = 318,
    ReplayToggletime = 319,
    ReplayToggletips = 320,
    ReplayPreview = 321,
    ReplayToggleTimeline = 322,
    ReplayTimelinePickupClip = 323,
    ReplayTimelineDuplicateClip = 324,
    ReplayTimelinePlaceClip = 325,
    ReplayCtrl = 326,
    ReplayTimelineSave = 327,
    ReplayPreviewAudio = 328,
    VehicleDriveLook = 329,
    VehicleDriveLook2 = 330,
    VehicleFlyAttack2 = 331,
    RadioWheelUpDown = 332,
    RadioWheelLeftRight = 333,
    VehicleSlowMoUpDown = 334,
    VehicleSlowMoUpOnly = 335,
    VehicleSlowMoDownOnly = 336,
    MapPointOfInterest = 337,
    ReplaySnapmaticPhoto = 338,
    VehicleCarJump = 339,
    VehicleRocketBoost = 340,
    VehicleParachute = 341,
    VehicleBikeWings = 342
}