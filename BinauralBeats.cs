/* 
 * Unity Binaural Beats Generator v0.9
 * 2022 Lodale Solution 4.0 Ltd / Marco Capelli
 */

using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class BinauralBeats : MonoBehaviour
{
    public enum MainToneHz { C128Hz, D144Hz, E162Hz, F172Hz, G192Hz, A216Hz, B242Hz};
    public MainToneHz mainToneHz = MainToneHz.C128Hz;

    [Range(1, 20)]
    public double binauralBeatsHz;

    private double baseFrequencyHz;
    private double oscillator_L;
    private double oscillator_R;

    public double gain = 0.05;

    private double increment1;
    private double increment2;

    private double phase1;
    private double phase2;

    private double sampling_frequency = 48000;

    private void Awake()
    {
        binauralBeatsHz = 1;
        oscillator_L = baseFrequencyHz;
        oscillator_R = baseFrequencyHz + 1;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        if (mainToneHz == MainToneHz.C128Hz)
        {
            baseFrequencyHz = 128;
            oscillator_L = baseFrequencyHz;
            oscillator_R = baseFrequencyHz + 1;
        }
        else if (mainToneHz == MainToneHz.D144Hz)
        {
            baseFrequencyHz = 144;
            oscillator_L = baseFrequencyHz;
            oscillator_R = baseFrequencyHz + 1;
        }
        else if (mainToneHz == MainToneHz.E162Hz)
        {
            baseFrequencyHz = 162;
            oscillator_L = baseFrequencyHz;
            oscillator_R = baseFrequencyHz + 1;
        }
        else if (mainToneHz == MainToneHz.F172Hz)
        {
            baseFrequencyHz = 172;
            oscillator_L = baseFrequencyHz;
            oscillator_R = baseFrequencyHz + 1;
        }
        else if (mainToneHz == MainToneHz.G192Hz)
        {
            baseFrequencyHz = 192;
            oscillator_L = baseFrequencyHz;
            oscillator_R = baseFrequencyHz + 1;
        }
        else if (mainToneHz == MainToneHz.A216Hz)
        {
            baseFrequencyHz = 216;
            oscillator_L = baseFrequencyHz;
            oscillator_R = baseFrequencyHz + 1;
        }
        else if (mainToneHz == MainToneHz.B242Hz)
        {
            baseFrequencyHz = 242;
            oscillator_L = baseFrequencyHz;
            oscillator_R = baseFrequencyHz + 1;
        }

        increment1 = (oscillator_L + binauralBeatsHz) * 2 * Math.PI / sampling_frequency;
        increment2 = oscillator_R * 2 * Math.PI / sampling_frequency;

        for (int i = 0; i < data.Length; i += channels)
        {
            phase1 += increment1;
            phase2 += increment2;

            data[i] = genSine1();

            if (channels == 2)
                data[i + 1] = genSine2();

            if (phase2 > 2 * Math.PI) phase2 = 0;
        }
    }

    float genSine1()
    {
        return (float)(gain * Math.Sin((float)phase1));
    }

    float genSine2()
    {
        return (float)(gain * Math.Sin((float)phase2));
    }
}
