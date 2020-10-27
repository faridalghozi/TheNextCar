using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged callbackonDoorChanged;

        public DoorController(OnDoorChanged callbackonDoorChanged)
        {
            this.callbackonDoorChanged = callbackonDoorChanged;
            this.door = new Door();
        }
        public void close()
        {
            this.door.close();
            this.callbackonDoorChanged.onDoorOpenStateChanged("CLOSED", "Door is Closed");
        }
        public void open()
        {
            this.door.open();
            this.callbackonDoorChanged.onDoorOpenStateChanged("OPENED", "Door is Opened");
        }
        public void activateLock()
        {
                this.door.activateLock();
                this.callbackonDoorChanged.onLockDoorStateChanged("LOCKED", "Door is Locked");
        }
        public void unlock()
        {
            this.door.unlock();
            this.callbackonDoorChanged.onLockDoorStateChanged("UNLOCKED", "Door is Unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void onLockDoorStateChanged(string value, string message);
        void onDoorOpenStateChanged(string value, string message);
    }
}
