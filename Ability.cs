using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    public bool isCharging;
    public float chargeTime;
    public float chargeDuration;
    public bool isReady;

    public bool isChanneling;
    public float channelTime;
    public float channelDuration;     
    
    public bool isUsing;
    public float useTime;
    public float useDuration;

    public bool requiresChanneling;

    public bool NotYetCharged => chargeTime < chargeDuration;
    public bool FullyCharged => chargeTime >= chargeDuration;

    public bool NotYetChanneled => channelTime < channelDuration;
    public bool FullyChanneled => channelTime >= channelDuration;

    public bool NotYetFinishedUsing => useTime < useDuration;
    public bool FinishedUsing => useTime >= useDuration;

    public void SetAsReady() => isReady = true;
    public void UnsetAsReady() => isReady = false;

    public void Charge_CountTime(float multiplier) => chargeTime += Time.deltaTime * multiplier;
    public void Charge_CountTime() => chargeTime += Time.deltaTime;
    public void Charge_Start() => isCharging = true;
    public void Charge_Stop() => isCharging = false;
    public void Charge_ResetTime() => chargeTime = 0;
    public void Charge_FillTime() => chargeTime = chargeDuration;

    public void Charge_Modify(float amount) => chargeTime += amount;

    public void Channel_CountTime(float multiplier) => channelTime += Time.deltaTime * multiplier;
    public void Channel_CountTime() => channelTime += Time.deltaTime;
    public void Channel_Start() => isChanneling = true;
    public void Channel_Stop() => isChanneling = false;
    public void Channel_ResetTime() => channelTime = 0;
    public void Channel_FillTime() => channelTime = channelDuration;

    public void Use_CountTime(float multiplier) => useTime += Time.deltaTime * multiplier;
    public void Use_CountTime() => useTime += Time.deltaTime;
    public void Use_Start() => isUsing = true;
    public void Use_Stop() => isUsing = false;
    public void Use_ResetTime() => useTime = 0;
    public void Use_FillTime() => useTime = useDuration;

    public void Run (float ChargeTimeMultiplier)
    {
        if (!isUsing)
        {
            if (NotYetCharged)
            {
                Charge_Start();
            }

            if (isCharging)
            {               
                Charge_CountTime(ChargeTimeMultiplier);
            }

            if (FullyCharged)
            {
                Charge_Stop();

                SetAsReady();
            }
        }

        if (isUsing)
        {
            Charge_ResetTime();

            UnsetAsReady();

            Use_CountTime();

            if (FinishedUsing)
            {
                Use_Stop();

                Use_ResetTime();
            }
        }
    }
}