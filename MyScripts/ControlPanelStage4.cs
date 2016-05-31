using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelStage4 : MonoBehaviour {

    public AudioSource MusicSound;

    public HelicopterController4 heli;
    public CheckpointControllerStage4 ch4;

    [SerializeField]
    KeyCode SpeedUp = KeyCode.LeftShift;
    [SerializeField]
    KeyCode SpeedDown = KeyCode.Space;
    [SerializeField]
    KeyCode Forward = KeyCode.W;
    [SerializeField]
    KeyCode Back = KeyCode.S;
    [SerializeField]
    KeyCode Left = KeyCode.A;
    [SerializeField]
    KeyCode Right = KeyCode.D;
    [SerializeField]
    KeyCode TurnLeft = KeyCode.Q;
    [SerializeField]
    KeyCode TurnRight = KeyCode.E;
    [SerializeField]
    KeyCode MusicOffOn = KeyCode.M;
    [SerializeField]
    KeyCode Move = KeyCode.Tab;

    private KeyCode[] keyCodes;

    public Action<PressedKeyCode[]> KeyPressed;
    private void Awake()
    {
        keyCodes = new[] {
                            SpeedUp,
                            SpeedDown,
                            Forward,
                            Back,
                            Left,
                            Right,
                            TurnLeft,
                            TurnRight,
                            Move
                        };

    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        var pressedKeyCode = new List<PressedKeyCode>();
        for (int index = 0; index < keyCodes.Length; index++)
        {
            var keyCode = keyCodes[index];
            if (Input.GetKey(keyCode))
                pressedKeyCode.Add((PressedKeyCode)index);
        }

        if (KeyPressed != null)
            KeyPressed(pressedKeyCode.ToArray());


        if (Input.GetKey(MusicOffOn))
        {
            if (MusicSound.volume == 1) return;

            MusicSound.volume = 1;
            MusicSound.Play();
        }
        if (Input.GetKeyDown(Move))
        {
            heli.HelicopterModel.transform.position = ch4.CurrentCheckpoint.transform.position;
        }


    }
}
