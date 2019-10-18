using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioHorizonCalculator : MonoBehaviour
{
    public InputField altitudeField;
    public InputField velocityField;
    public InputField d1Field;
    public InputField d2Field;

    public Text resultText;

    private string altitude;
    private string velocity;
    private string distance1;
    private string distance2;

    private double dT;
    private double time;

    public void OnSubmit()
    {
        altitude = altitudeField.text;
        velocity = velocityField.text;
        distance1 = d1Field.text;
        distance2 = d2Field.text;

        dT = calculateDT(double.Parse(distance1), double.Parse(distance2));
        time = calculateTime(dT, double.Parse(velocity));
        double result =  calculateRadioHorizon(double.Parse(velocity), double.Parse(altitude), time);

        Debug.Log("result is" + result);
        resultText.text = "result is" + result;
    }

    public double calculateRadioHorizon(double velocity, double altitude, double time)
    {
        return (Mathf.Sqrt(2) * altitude) + (Mathf.Sqrt(2) * time);
    }

    private double calculateTime(double distance, double velocity)
    {
        /* 
         * t=d/v
        d = meters
        v = m/hr */

        return distance / velocity;
    }

    private double calculateDT(double distance1, double distance2)
    {
        return distance2 - distance1;
    }
}
