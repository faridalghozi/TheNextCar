using System;
using System.Collections.Generic;
using System.Text;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubatteryController accubatteryController;
        private OnCarEngineStateChanged callbackOnCarEngineStateChanged;

        public Car(DoorController doorController, AccubatteryController accubatteryController, OnCarEngineStateChanged callbackOnCarEngineStateChanged)
        {
            this.doorController = doorController;
            this.accubatteryController = accubatteryController;
            this.callbackOnCarEngineStateChanged = callbackOnCarEngineStateChanged;
        }
        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        private bool powerIsReady()
        {
            return this.accubatteryController.accubatteryIsOn();
        }
        public void startEngine()
        {
            if (!doorIsClosed())
            {
                this.callbackOnCarEngineStateChanged.onCarEngineStateChanged("STOPPED", "Close The Door");
                return;
            }
            if (!doorIsLocked())
            {
                this.callbackOnCarEngineStateChanged.onCarEngineStateChanged("STOPPED", "Lock The Door");
                return;
            }
            if (!powerIsReady())
            {
                this.callbackOnCarEngineStateChanged.onCarEngineStateChanged("STOPPED", "No Power Available");
                return;
            }
            this.callbackOnCarEngineStateChanged.onCarEngineStateChanged("STARTED", "Engine Started");
        }
        public void toggleTheLockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.doorController.activateLock();
            }
            else
            {
                this.doorController.unlock();
            }
        }
        public void toggleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }
            else
            {
                this.doorController.open();
            }
        }
        public void togglePowerButton()
        {
            if (!powerIsReady())
            {
                this.accubatteryController.turnOn();
            }
            else
            {
                this.accubatteryController.turnOff();
            }
        }
    }
    interface OnCarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }
}
