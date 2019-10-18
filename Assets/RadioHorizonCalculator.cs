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
    public InputField heightOfAntennaTransmitterField;
    public InputField heightOfAntennaReceiverField;


    public Text resultText;

    private string altitude;
    private string velocity;
    private string distance1;
    private string distance2;
    private string heightOfAntennaTransmitter;
    private string heightOfAntennaReceiver;

    private double dT;
    private double time;

    public void OnSubmit()
    {
        altitude = altitudeField.text;
        velocity = velocityField.text;
        distance1 = d1Field.text;
        distance2 = d2Field.text;
        heightOfAntennaTransmitter = heightOfAntennaTransmitterField.text;
        heightOfAntennaReceiver = heightOfAntennaReceiverField.text;

        dT = calculateDT(double.Parse(distance1), double.Parse(distance2));
        time = calculateTime(dT, double.Parse(velocity));


        double result =  calculateRadioHorizon(double.Parse(heightOfAntennaTransmitter), double.Parse(heightOfAntennaReceiver));

        string strResult = $"Result of radio horizon is {result} miles / {result *  1.609} kilometer, time: {time} hr, distance travelled: {dT} miles";
        Debug.Log(strResult);
        resultText.text = strResult;
    }

    public double calculateRadioHorizon(double heightOfAntennaTransmitter, double heightOfAntennaReceiver)
    {
        return (Mathf.Sqrt(2) * heightOfAntennaTransmitter) + (Mathf.Sqrt(2) * heightOfAntennaReceiver);
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
