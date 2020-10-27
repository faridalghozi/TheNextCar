using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccubatteryController
    {
        private Accubattery accubattery;
        private OnPowerChanged callbackOnPowerChanged;

        public AccubatteryController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accubattery = new Accubattery(12);
        }
        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callbackOnPowerChanged.onPowerChangedStatus("ON", "Power is ON");
        }
        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callbackOnPowerChanged.onPowerChangedStatus("OFF", "Power is OFF");
        }
        public bool accubatteryIsOn()
        {
            return this.accubattery.isOn();
        }
    }
    interface OnPowerChanged
    {
        void onPowerChangedStatus(string value, string message);
    }
}
