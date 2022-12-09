using System.Collections;
using System.Collections.Generic;
using TelloLib;
using UnityEngine;

public class Experiment_TelloControllerWrapper : MonoBehaviour
{


	public void RequestTakeOff() =>
			Tello.takeOff();
	public void RequestLanding() =>
			Tello.land();


	public float m_joystickSensibility;
	public float m_realjoystickSensibility=1f;
	public float m_minSensibility = 0.1f;


	public float m_yaw;
	public float m_throttle;
	public float m_roll;
	public float m_tilt;
	public int m_speed;
	public float m_speedPercent;

	public void SetAxisValues(float yaw, float throttle, float roll, float tilt) {

		m_yaw  =yaw;
		m_throttle=throttle;
		m_roll   =roll;
		m_tilt = tilt;
	}
	public void SetYaw(float percent) => m_yaw = percent;
	public void SetRoll(float percent) => m_roll = percent;
	public void SetTilt(float percent) => m_tilt = percent;
	public void SetThrottle(float percent) => m_throttle = percent;

	public void SetJoystickSensibility(float percent) {
		m_joystickSensibility = percent;
		m_realjoystickSensibility = m_minSensibility + (percent - m_minSensibility);
	}

	public int m_maxSpeedMode = 5;

	public void SetSpeedMode(int value)
	{
		m_speed = (int)(value * m_maxSpeedMode);
		m_speedPercent = value /(float) m_maxSpeedMode;
	}
	public void SetSpeedModeWithPercent(float value)
	{
		m_speed = (int)(value * m_maxSpeedMode);
		m_speedPercent = value;
	}

	public float m_timeBetweenPush = 0.1f;
    private void Start()
    {
		InvokeRepeating("Push", 0, m_timeBetweenPush);
    }

    private void Push()
    {

		Tello.controllerState.setAxis(
			m_yaw,
			m_throttle,
			m_roll,
			m_tilt);
		Tello.controllerState.setSpeedMode(m_speed);
	}
}
