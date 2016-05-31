using UnityEngine;
using UnityEngine.UI;

public class HelicopterController4 : MonoBehaviour
{
    public AudioSource HelicopterSound;     
    public ControlPanelStage4 ControlPanel;       
    public Rigidbody HelicopterModel;       
    public HeliRotorController MainRotorController;     
    public HeliRotorController SubRotorController;    
	public joystickDrone joystick;
	public joystickdrone2 joystick2;

    public float TurnForce = 3f;        
    public float ForwardForce = 10f;
    public float ForwardTiltForce = 20f;
    public float TurnTiltForce = 30f;
    public float EffectiveHeight = 100f;

    public float turnTiltForcePercent = 1.5f;
    public float turnForcePercent = 1.3f;

    private float _engineForce;
    public float EngineForce        
    {
        get { return _engineForce; }    
        set     
        {
            MainRotorController.RotarSpeed = value * 80;        
            SubRotorController.RotarSpeed = value * 40;          
            HelicopterSound.pitch = Mathf.Clamp(value / 40, 0, 1.2f);      
            if (UIGameController.runtime.EngineForceView != null)   
				UIGameController.runtime.EngineForceView.text = string.Format("Engine: {0}", (int)value);     


            _engineForce = value;  
        }
    }

    private Vector2 hMove = Vector2.zero;
    private Vector2 hTilt = Vector2.zero;
    private float hTurn = 0f;
    public bool IsOnGround = true;

    // Use this for initialization
	void Start ()
	{
        ControlPanel.KeyPressed += OnKeyPressed;
	}

	void Update () {    
                        
                        
	}
  
    void FixedUpdate()  
                        
    {
        LiftProcess();  
        MoveProcess();                                              
        TiltProcess();
    }

    private void MoveProcess()
    {
        var turn = TurnForce * Mathf.Lerp(hMove.x, hMove.x * (turnTiltForcePercent - Mathf.Abs(hMove.y)), Mathf.Max(0f, hMove.y));
        hTurn = Mathf.Lerp(hTurn, turn, Time.fixedDeltaTime * TurnForce);
        HelicopterModel.AddRelativeTorque(0f, hTurn * HelicopterModel.mass, 0f);
        HelicopterModel.AddRelativeForce(Vector3.forward * Mathf.Max(0f, hMove.y * ForwardForce * HelicopterModel.mass));
    }

    private void LiftProcess()
    {
        var upForce = 1 - Mathf.Clamp(HelicopterModel.transform.position.y / EffectiveHeight, 0, 1);
        upForce = Mathf.Lerp(0f, EngineForce, upForce) * HelicopterModel.mass;
        HelicopterModel.AddRelativeForce(Vector3.up * upForce);
    }

    private void TiltProcess()
    {
        hTilt.x = Mathf.Lerp(hTilt.x, hMove.x * TurnTiltForce, Time.deltaTime);
        hTilt.y = Mathf.Lerp(hTilt.y, hMove.y * ForwardTiltForce, Time.deltaTime);
        HelicopterModel.transform.localRotation = Quaternion.Euler(hTilt.y, HelicopterModel.transform.localEulerAngles.y, -hTilt.x);
    }

    private void OnKeyPressed(PressedKeyCode[] obj)
    {
		Vector3 dir = Vector3.zero;
		Vector3 dir2 = Vector3.zero;
		dir.x = joystick.Horizontal ();
		dir.z = joystick.Vertical ();
		dir2.x = joystick2.Horizontal ();
		dir2.z = joystick2.Vertical ();

        float tempY = 0;
        float tempX = 0;

        // stable forward
        if (hMove.y > 0)
            tempY = - Time.fixedDeltaTime;      
        else
            if (hMove.y < 0)
                tempY = Time.fixedDeltaTime;

        // stable lurn
        if (hMove.x > 0)
            tempX = -Time.fixedDeltaTime;
        else
            if (hMove.x < 0)
                tempX = Time.fixedDeltaTime;

		// pc keybord moving
        foreach (var pressedKeyCode in obj)     
                                                
                                                
                                                                            
        { 
            switch (pressedKeyCode)
            {
                case PressedKeyCode.SpeedUpPressed:     

                    EngineForce += 0.1f;    
                    break;
                case PressedKeyCode.SpeedDownPressed:                                                                  

                    EngineForce -= 0.12f;
                    if (EngineForce < 0) EngineForce = 0;
                    break;

                case PressedKeyCode.ForwardPressed:    

                    if (IsOnGround) break;             
                    tempY = Time.fixedDeltaTime;
                    break;
                case PressedKeyCode.BackPressed:       

                    if (IsOnGround) break;             
                    tempY = -Time.fixedDeltaTime;
                    break;
                case PressedKeyCode.LeftPressed:       

                    if (IsOnGround) break;             
                    tempX = -Time.fixedDeltaTime;
                    break;
                case PressedKeyCode.RightPressed:      

                    if (IsOnGround) break;             
                    tempX = Time.fixedDeltaTime;
                    break;
                case PressedKeyCode.TurnRightPressed:  
                    {
                        if (IsOnGround) break;             
                        var force = (turnForcePercent - Mathf.Abs(hMove.y))*HelicopterModel.mass;
                        HelicopterModel.AddRelativeTorque(0f, force, 0);
                    }
                    break;                              
                case PressedKeyCode.TurnLeftPressed:    
                    {
                        if (IsOnGround) break;                        
                        var force = -(turnForcePercent - Mathf.Abs(hMove.y))*HelicopterModel.mass;
                        HelicopterModel.AddRelativeTorque(0f, force, 0);
                    }
                    break;

            }
        }


		//Joystick moving
		EngineForce += dir2.z/2; // SpeedUp
		if (EngineForce < 0) EngineForce = 0;

		if (!IsOnGround) { 
			if (dir.x > 0 && Mathf.Abs(dir.x) > Mathf.Abs(dir.z)) // right
				tempX = Time.fixedDeltaTime;
			if (dir.x < 0 && Mathf.Abs(dir.x) > Mathf.Abs(dir.z)) // left
				tempX = -Time.fixedDeltaTime;


			if (dir.z > 0 && Mathf.Abs(dir.z) > Mathf.Abs(dir.x)) // forward
				tempY = Time.fixedDeltaTime;
			if (dir.z < 0 && Mathf.Abs(dir.z) > Mathf.Abs(dir.x)) // back
				tempY = -Time.fixedDeltaTime;

			if (dir2.x > 0 && Mathf.Abs (dir2.x) > Mathf.Abs (dir2.z)) { // turn right
				var force = (turnForcePercent - Mathf.Abs (hMove.y)) * HelicopterModel.mass;
				HelicopterModel.AddRelativeTorque (0f, force, 0);
			}
			if (dir2.x < 0 && Mathf.Abs (dir2.x) > Mathf.Abs (dir2.z)) { // turn left
				var force = -(turnForcePercent - Mathf.Abs(hMove.y)) * HelicopterModel.mass;
				HelicopterModel.AddRelativeTorque(0f, force, 0);
			}
		}

        hMove.x += tempX;
        hMove.x = Mathf.Clamp(hMove.x, -1, 1);

        hMove.y += tempY;
        hMove.y = Mathf.Clamp(hMove.y, -1, 1);

    }

    private void OnCollisionEnter()
    {
        IsOnGround = true;
    }

    private void OnCollisionExit()
    {
        IsOnGround = false;
    }
}