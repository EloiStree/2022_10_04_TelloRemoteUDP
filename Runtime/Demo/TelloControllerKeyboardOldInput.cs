using System.Collections;
using System.Collections.Generic;
using TelloLib;
using UnityEngine;
using UnityEngine.Events;

public class TelloControllerKeyboardOldInput : MonoBehaviour
{

	public TelloController m_telloController;

	[Header("Key Code")]
	public KeyCode m_takeOff= KeyCode.KeypadDivide;
	public KeyCode m_land = KeyCode.KeypadMultiply;
	public KeyCode m_joyRight_Right = KeyCode.Keypad6;
	public KeyCode m_joyRight_Left = KeyCode.Keypad4;
	public KeyCode m_joyRight_Top = KeyCode.Keypad8;
	public KeyCode m_joyRight_Down = KeyCode.Keypad5;
	public KeyCode m_joyLeft_Right = KeyCode.Keypad9;
	public KeyCode m_joyLeft_Left = KeyCode.Keypad7;
	public KeyCode m_joyLeft_Top = KeyCode.KeypadMinus;
	public KeyCode m_joyLeft_Down = KeyCode.KeypadPlus;


	[Header("Event")]
	public UnityEvent m_requestTakeOff;
	public UnityEvent m_requestLanding;
	public FloatEvent m_onYawLeftToRight;
	public FloatEvent m_onThrottleDownToTop;
	public FloatEvent m_onTiltBackToFront;
	public FloatEvent m_onRollLeftToRight;

	[System.Serializable]
	public class FloatEvent : UnityEvent<float> { }


	void Update()
	{


		if (Input.GetKeyDown(m_takeOff))
		{
			m_requestTakeOff.Invoke();
		}
		else if (Input.GetKeyDown(m_land))
		{
			m_requestLanding.Invoke();
		}

		float lx = 0f;
		float ly = 0f;
		float rx = 0f;
		float ry = 0f;

		if (Input.GetKey(m_joyRight_Top))
		{
			ry = 1;
		}
		if (Input.GetKey(m_joyRight_Down))
		{
			ry = -1;
		}
		if (Input.GetKey(m_joyRight_Right))
		{
			rx = 1;
		}
		if (Input.GetKey(m_joyRight_Left))
		{
			rx = -1;
		}
		if (Input.GetKey(m_joyLeft_Top))
		{
			ly = 1;
		}
		if (Input.GetKey(m_joyLeft_Down))
		{
			ly = -1;
		}
		if (Input.GetKey(m_joyLeft_Right))
		{
			lx = 1;
		}
		if (Input.GetKey(m_joyLeft_Left))
		{
			lx = -1;
		}
		m_onYawLeftToRight.Invoke(lx);
		m_onThrottleDownToTop.Invoke(ly);
		m_onRollLeftToRight.Invoke(rx);
		m_onTiltBackToFront.Invoke(ry);
	}


}
