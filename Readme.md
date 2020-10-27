# The Next Car
The Next Car adalah sebuah aplikasi dashboard electric car yang menggunakan konsep MVC (Model View Controller).

## Scope & Functionalities
- User dapat menyalakan tombol ON/OFF pada aplikasi
- User dapat membuka & menutup pintu pada aplikasi
- User dapat mengunci dan membuka kunci pintu pada aplikasi
- User dapat menyalakan mesin ketika semua sudah siap

## How It Does Work?
Pada aplikasi ini electric car hanya akan menyala ketika pintu sudah tertutup dan terkunci serta menyalakan tombol ON
```csharp
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
```
## Apa kegunaan `DoorController.cs`?
Kegunaan dari `DoorController.cs` yaitu untuk mengetahui pintu dalam keadaan tertutup, terbuka, terkunci, atau tidak terkunci. Jika pintu dalam keadaan terbuka dan tidak terkunci maka mesin tidak bisa dijalankan
```csharp
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
```
## Apa kegunaan model `Door.cs`?
`Door.cs` berguna untuk mengetahui fungsi dari door Closed atau Locked
```csharp
class Door
    {
        private bool closed;
        private bool locked;
        public void close()
        {
            this.closed = true;
        }
        public void open()
        {
            this.closed = false;
        }
        public void activateLock()
        {
            this.locked = true;
        }
        public void unlock()
        {
            this.locked = false;
        }
        public bool isLocked()
        {
            return this.locked;
        }
        public bool isClosed()
        {
            return this.closed;
        }
    }
```
## Apa kegunaan interface `OnDoorChanged`?
Interface `OnDoorChanged`berfungsi untuk mengganti fungsi dari `Door` dan `DoorController`
```csharp
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
```