﻿using System;
using System.ComponentModel;
using EDSDKLib;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Canon_EOS_Remote.ViewModel
{
    class ViewModelCurrentCamera : INotifyPropertyChanged
    {
        private string currentCameraName;
        private int currentBatteryLevel;
        private string currentBodyID;
        private int currentAvailableShots;
        private string currentCameraOwner;
        private string currentCameraFirmware;
        private Camera currentCamera;

        private EDSDK.EdsPropertyDesc PropertyDescISO;
        private CollectionView availableISOListView;
        private ObservableCollection<int> availableISOListCollection;
        private ISOSpeeds isoSpeeds;
        private classes.ShutterTimes shutterTimes;
        private EDSDK.EdsPropertyDesc propertyDescTv;
        private CollectionView availableShutterTimesView;
        private ObservableCollection<string> availableShutterTimesCollection;
        private EDSDK.EdsPropertyDesc propertyDescAE;
        private CollectionView aEView;
        private ObservableCollection<string> aECollection;
        private classes.AEModes aeModes;

        private bool isolistemtpy;
        private bool shuttertimeslistempty;
        private bool aelistempty;
        private bool apertureslistempty;
        private int currentISO;

        private Command_TakePhoto commandTakePhoto;
        private Command_DriveLensNearOne commandDriveLensNearOne;
        private string currentDate;
        private string currentTime;
        private EDSDK.EdsPropertyDesc apertureDesc;
        private classes.AEModes aemodes;

        public EDSDK.EdsPropertyDesc ApertureDesc
        {
            get { return apertureDesc; }
            set { apertureDesc = value;
            update("ApertureDesc");
            }
        }
        private CollectionView apertureView;

        public CollectionView ApertureView
        {
            get { return apertureView; }
            set { apertureView = value;
            update("ApertureView");
            }
        }
        private ObservableCollection<string> aptureCollection;

        internal ObservableCollection<string> AptureCollection
        {
            get { return aptureCollection; }
            set { aptureCollection = value;
            update("AptureCollection");
            }
        }

        public string CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value;
            update("CurrentTime");
            }
        }

        public string CurrentDate
        {
            get { return currentDate; }
            set { currentDate = value;
            update("CurrentDate");
            }
        }

        public Command_DriveLensNearOne CommandDriveLensNearOne
        {
            get { return commandDriveLensNearOne; }
            set { commandDriveLensNearOne = value; }
        }
        private IntPtr streamref;
        private IntPtr imageref;
        private classes.PropertyCodes propertyCodes;
        private string currentProgramm;
        private string currentAperture;
        private classes.Apertures apertures;

        public string CurrentAperture
        {
            get { return currentAperture; }
            set
            {
                currentAperture = value;
                update("CurrentAperture");
            }
        }

        public string CurrentProgramm
        {
            get { return currentProgramm; }
            set
            {
                currentProgramm = value;
                update("CurrentProgramm");
            }
        }

        public classes.PropertyCodes PropertyCodes
        {
            get { return propertyCodes; }
            set { propertyCodes = value; }
        }

        public IntPtr Imageref
        {
            get { return imageref; }
            set { imageref = value; }
        }

        public Command_TakePhoto CommandTakePhoto
        {
            get { return commandTakePhoto; }
            set { commandTakePhoto = value; }
        }

        public int CurrentISO
        {
            get { return currentISO; }
            set
            {
                currentISO = value;
                update("CurrentISO");
            }
        }
        private string currentTv;

        public string CurrentTv
        {
            get { return currentTv; }
            set
            {
                currentTv = value;
                update("CurrentTv");
            }
        }

        public EDSDK.EdsPropertyDesc PropertyDescAE
        {
            get { return propertyDescAE; }
            set
            {
                propertyDescAE = value;
                update("PropertyDescAE");
            }
        }

        public CollectionView AEView
        {
            get { return aEView; }
            set
            {
                aEView = value;
                update("AEView");
            }
        }

        public ObservableCollection<string> AECollection
        {
            get { return aECollection; }
            set
            {
                aECollection = value;
                update("AECollection");
            }
        }

        public classes.AEModes AeModes
        {
            get { return aeModes; }
            set
            {
                aeModes = value;
                update("AeModes");
            }
        }

        public CollectionView AvailableShutterTimesView
        {
            get { return availableShutterTimesView; }
            set
            {
                availableShutterTimesView = value;
                update("AvailableShutterTimesView");
            }
        }

        public ObservableCollection<string> AvailableShutterTimesCollection
        {
            get { return availableShutterTimesCollection; }
            set
            {
                availableShutterTimesCollection = value;
                update("AvailableShutterTimesCollection");
            }
        }

        public ObservableCollection<int> AvailableISOListCollection
        {
            get { return availableISOListCollection; }
            set
            {
                availableISOListCollection = value;
                update("AvailableISOListCollection");
            }
        }

        public CollectionView AvailableISOListView
        {
            get { return availableISOListView; }
            set
            {
                availableISOListView = value;
                update("AvailableISOListView");
            }
        }

        public EDSDK.EdsPropertyDesc AvailableISOList
        {
            get { return PropertyDescISO; }
            set
            {
                PropertyDescISO = value;
                update("AvailableISOList");
            }
        }

        public Camera CurrentCamera
        {
            get { return currentCamera; }
            set
            {
                currentCamera = value;
                this.CommandTakePhoto.Camera = currentCamera.CameraPtr;
                this.CommandDriveLensNearOne.CameraPtr = currentCamera.CameraPtr;
                update("CurrentCamera");
            }
        }

        public ViewModelCurrentCamera()
        {
            Console.WriteLine("Intance of ViewModelCurrentCamera created.");
            this.CurrentCameraName = "CurrentCameraName";
            this.CurrentCameraOwner = "CurrentCameraOwner";
            this.CurrentCameraFirmware = "CurrentCameraFirmware";
            this.currentProgramm = "CurrentProgramm";
            this.CurrentAperture = "CurrentAperture";
            this.CurrentDate = " CurrentDate";
            this.CurrentTime = "CurrentTime";
            this.CurrentBatteryLevel = 50;

            this.AvailableISOListCollection = new ObservableCollection<int>();
            this.AvailableISOListView = new CollectionView(this.AvailableISOListCollection);

            this.AvailableShutterTimesCollection = new ObservableCollection<string>();
            this.availableShutterTimesView = new CollectionView(this.AvailableShutterTimesCollection);
            this.AECollection = new ObservableCollection<string>();
            this.AEView = new CollectionView(this.AECollection);
            this.isoSpeeds = new ISOSpeeds();
            this.shutterTimes = new classes.ShutterTimes();
            this.AeModes = new classes.AEModes();
            this.isolistemtpy = true;
            this.shuttertimeslistempty = true;
            this.apertureslistempty = true;
            this.aelistempty = true;
            this.CurrentISO = 100;
            this.CurrentTv = "Lange";
            this.CommandTakePhoto = new Command_TakePhoto();
            this.CommandTakePhoto.Camera = IntPtr.Zero;
            this.CommandDriveLensNearOne = new Command_DriveLensNearOne();
            this.CommandDriveLensNearOne.CameraPtr = IntPtr.Zero;
            this.propertyCodes = new classes.PropertyCodes();
            this.apertures = new classes.Apertures();
            this.AptureCollection = new ObservableCollection<string>();
            this.ApertureView = new CollectionView(this.AptureCollection);
            this.aemodes = new classes.AEModes();
        }

        public string CurrentCameraFirmware
        {
            get { return currentCameraFirmware; }
            set
            {
                currentCameraFirmware = value;
                update("CurrentCameraFirmware");
            }
        }

        public string CurrentCameraOwner
        {
            get { return currentCameraOwner; }
            set
            {
                currentCameraOwner = value;
                update("CurrentCameraOwner");
            }
        }

        public int CurrentAvailableShots
        {
            get { return currentAvailableShots; }
            set
            {
                currentAvailableShots = value;
                update("CurrentAvailableShots");
            }
        }

        public string CurrentBodyID
        {
            get { return currentBodyID; }
            set
            {
                currentBodyID = value;
                update("CurrentBodyID");
            }
        }

        public int CurrentBatteryLevel
        {
            get { return currentBatteryLevel; }
            set
            {
                currentBatteryLevel = value;
                update("CurrentBatteryLevel");
            }
        }

        public string CurrentCameraName
        {
            get { return currentCameraName; }
            set
            {
                currentCameraName = value;
                update("CurrentCameraName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void update(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
                Console.WriteLine("\n\nViewModelCurrentCamera Property has changed : " + property+"\n\n");
            }
        }

        public void setCurrentlyCamera()
        {
            Console.WriteLine("Set all values for the currently choosen camera ........");
            this.CurrentCameraName = this.currentCamera.CameraName;
            this.CurrentBatteryLevel = (int)this.currentCamera.CameraBatteryLevel;
            this.CurrentBodyID = this.currentCamera.CameraBodyID;
            this.currentCamera.getAvailableShotsFromCamera();
            this.CurrentAvailableShots = (int)this.currentCamera.CameraAvailableShots;
            this.CurrentCameraOwner = this.currentCamera.CameraOwner;
            this.CurrentCameraFirmware = this.currentCamera.CameraFirmware;
            this.AvailableISOList = this.CurrentCamera.AvailableISOSpeeds;
            if (this.isolistemtpy) copyPropertyDescISOToCollection();
            this.AvailableISOListView.CurrentChanged += new EventHandler(sendISOSpeedToCamera);
            this.AvailableShutterTimesView.CurrentChanged += new EventHandler(sendShutterTimeToCamera);
            this.AEView.CurrentChanged += new EventHandler(sendAEModeToCamera);
            this.propertyDescTv = this.CurrentCamera.AvailableShutterspeeds;
            if (this.shuttertimeslistempty) copyPropertyDescShutterTimesToCollection();
            this.propertyDescAE = this.CurrentCamera.AvailableAEModes;
            if (this.aelistempty) copyPropertyDescAEModesToCollection();
            this.CurrentCamera.getISOSpeedFromCamera();
            this.CurrentISO = (int)this.isoSpeeds.getISOSpeedFromHex(this.currentCamera.CameraISOSpeed);
            this.CurrentCamera.getTvFromCamera();
            this.CurrentTv = this.shutterTimes.getShutterTimeStringFromHex(this.currentCamera.CameraShutterTime);
            this.CurrentProgramm = this.AeModes.getAEString(this.CurrentCamera.CameraAEMode);
            this.CurrentAperture = this.apertures.getApertureString(this.CurrentCamera.CameraAperture);
            this.CurrentDate = convertEdsTimeToDateString(this.CurrentCamera.CameraTime);
            this.CurrentTime = convertEdsTimeToTimeString(this.CurrentCamera.CameraTime);
            this.ApertureDesc = this.CurrentCamera.AvailableApertureValues;
            if (apertureslistempty) copyPropertyDescAperturesToCollection();
            this.ApertureView.CurrentChanged += new EventHandler(sendApertureToCamera);
            Console.WriteLine("All values setted");
        }

        public void updateCurrentlyCamera(classes.PropertyEventArgs p)
        {
            switch (p.PropertyName)
            {
                case EDSDK.PropID_Tv:
                    {
                        this.CurrentCamera.getTvFromCamera();
                        this.CurrentTv = this.shutterTimes.getShutterTimeStringFromHex(this.currentCamera.CameraShutterTime);
                        break;
                    }
                case EDSDK.PropID_ISOSpeed:
                    {
                        this.CurrentCamera.getISOSpeedFromCamera();
                        this.CurrentISO = (int)this.isoSpeeds.getISOSpeedFromHex(this.currentCamera.CameraISOSpeed);
                        break;
                    }
                case EDSDK.PropID_AvailableShots:
                    {
                        this.currentCamera.getAvailableShotsFromCamera();
                        this.CurrentAvailableShots = (int)this.currentCamera.CameraAvailableShots;
                        break;
                    }
                case EDSDK.PropID_BatteryLevel:
                    {
                        this.currentCamera.getCameraBatteryLevelFromBody();
                        this.CurrentBatteryLevel = (int)this.currentCamera.CameraBatteryLevel;
                        break;
                    }
                case EDSDK.PropID_FirmwareVersion:
                    {
                        this.currentCamera.getFirmwareVersion();
                        this.CurrentCameraFirmware = this.currentCamera.CameraFirmware;
                        break;
                    }

                case EDSDK.PropID_ProductName:
                    {
                        this.currentCamera.getCameraName();
                        this.CurrentCameraName = this.currentCamera.CameraName;
                        break;
                    }
                case EDSDK.PropID_OwnerName:
                    {
                        this.currentCamera.getCameraOwner();
                        this.CurrentCameraOwner = this.currentCamera.CameraOwner;
                        break;
                    }
                case EDSDK.PropID_BodyIDEx:
                    {
                        this.currentCamera.getBodyID();
                        this.CurrentBodyID = this.currentCamera.CameraBodyID;
                        break;
                    }
                case EDSDK.PropID_AEMode:
                    {
                        this.currentCamera.getAEModeFromCamera();
                        this.CurrentProgramm = this.AeModes.getAEString(this.CurrentCamera.CameraAEMode);
                        break;
                    }
                case EDSDK.PropID_Av:
                    {
                        this.currentCamera.getApertureFromCamera();
                        this.CurrentAperture = this.apertures.getApertureString(this.CurrentCamera.CameraAperture);
                        break;
                    }
                case EDSDK.PropID_DateTime:
                    {
                        this.CurrentCamera.getTimeFromCamera();
                        this.CurrentDate = convertEdsTimeToDateString(this.CurrentCamera.CameraTime);
                        this.CurrentTime = convertEdsTimeToTimeString(this.CurrentCamera.CameraTime);
                        break;
                    }
                  
                default:
                    {
                        Console.WriteLine("Cant identify PropertyID");
                        break;
                    }
            }
        }

        private void copyPropertyDescISOToCollection()
        {
            this.isolistemtpy = false;
            this.availableISOListCollection.Clear();
            for (int i = 0; i < this.AvailableISOList.NumElements; i++)
            {
                this.AvailableISOListCollection.Add((int)this.isoSpeeds.getISOSpeedFromHex(this.AvailableISOList.PropDesc[i]));
            }
        }

        private void sendISOSpeedToCamera(object sender, EventArgs e)
        {
            int tmpProperty = 0;
            if (this.AvailableISOListView.CurrentItem != null)
            {
                tmpProperty = (int)this.AvailableISOListView.CurrentItem;
                this.CurrentCamera.setISOSpeedToCamera((int)this.isoSpeeds.getISOSpeedFromDec((uint)tmpProperty));
            }
        }

        private void copyPropertyDescShutterTimesToCollection()
        {
            this.shuttertimeslistempty = false;
            this.AvailableShutterTimesCollection.Clear();
            for (int i = 0; i < this.propertyDescTv.NumElements; i++)
            {
                this.AvailableShutterTimesCollection.Add(this.shutterTimes.getShutterTimeStringFromHex((uint)this.propertyDescTv.PropDesc[i]));
            }
        }

        private void sendShutterTimeToCamera(object sender, EventArgs e)
        {
            string tmpProperty = "";
            if (this.AvailableShutterTimesView.CurrentItem != null)
            {
                tmpProperty = (string)this.AvailableShutterTimesView.CurrentItem;
                this.CurrentCamera.setShutterTimeToCamera((int)this.shutterTimes.getShutterTimeStringFromDec(tmpProperty));
            }
        }

        private void copyPropertyDescAEModesToCollection()
        {
            this.aelistempty = false;
            this.AECollection.Clear();
            for (int i = 0; i < this.propertyDescAE.NumElements; i++)
            {
                this.AECollection.Add(this.aemodes.getAEString((uint)this.propertyDescAE.PropDesc[i]));
            }
        }

        private void copyPropertyDescAperturesToCollection()
        {
            this.apertureslistempty = false;
            this.AptureCollection.Clear();
            for (int i = 0; i < this.ApertureDesc.NumElements; i++)
            {
                this.AptureCollection.Add(this.apertures.getApertureString((uint)this.ApertureDesc.PropDesc[i]));
            }
        }

        private void sendAEModeToCamera(object sender, EventArgs e)
        {
            string tmpProperty = "";
            if (this.AEView.CurrentItem != null)
            {
                tmpProperty = (string)this.AEView.CurrentItem;
                this.CurrentCamera.setAEModeToCamera((int)this.AeModes.getAEHex(tmpProperty));
            }
        }

        private void sendApertureToCamera(object sender, EventArgs e)
        {
            string tmpProperty = "";
            if (this.ApertureView.CurrentItem != null)
            {
                tmpProperty = (string)this.ApertureView.CurrentItem;
                this.CurrentCamera.setApertureToCamera((int)this.apertures.getApertureHex(tmpProperty));
            }
        }

        public string convertEdsTimeToDateString(EDSDK.EdsTime time)
        {
            return time.Year + "-" + time.Month + "-" + time.Day;
        }

        public string convertEdsTimeToTimeString(EDSDK.EdsTime time)
        {
            return time.Hour + "-" + time.Minute + "-" + time.Second;
        }
    }
}
