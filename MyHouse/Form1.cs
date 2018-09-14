using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHouse
{
    public partial class Form1 : Form
    {
        #region Variable declarations
        private Location currentLocation;

        private Room dinningRoom;
        private RoomWithDoor livingRoom;
        private RoomWithDoor kitchen;

        private Outside garden;
        private OutsideWithDoor frontYard;
        private OutsideWithDoor backYard;

        private Room stairs;
        private RoomWithHidingPlace upstairsHallway;
        private RoomWithHidingPlace masterBedroom;
        private RoomWithHidingPlace secondBedroom;
        private RoomWithHidingPlace bathRoom;
        private OutsideWithHidingPlace driveWay;
        #endregion

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(frontYard);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void CreateObjects()
        {
            dinningRoom = new Room("Sala de estar", "candelabro de cristal");
            livingRoom = new RoomWithDoor("Comedol", "alfombra antiquísima", "puerta de roble con pomo de latón", "debajo de la mesa");
            kitchen = new RoomWithDoor("Cocina", "electrodomésticos de acero inoxidable", "puerta de cristal juno", "dentro de la nevera");
            livingRoom.Exits = new Location[] {dinningRoom, upstairsHallway};
            dinningRoom.Exits = new Location[] {livingRoom, kitchen};
            kitchen.Exits = new Location[] {dinningRoom};


            frontYard = new OutsideWithDoor("FrontYard", false, "puerta de roble con pomo de latón");
            backYard = new OutsideWithDoor("BackYard", true, "puerta de cristal juno");
            garden = new OutsideWithHidingPlace("Jardín", false, "en la caseta"); 
            frontYard.Exits = new Location[] {garden, backYard, driveWay};
            backYard.Exits = new Location[] {garden, frontYard, driveWay};
            garden.Exits = new Location[] {frontYard, backYard};

            livingRoom.DoorLocation = frontYard;
            kitchen.DoorLocation = backYard;

            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;

            stairs = new Room("Escaleras", "taquillón de madera");
            upstairsHallway = new RoomWithHidingPlace("pasillo superior", "cuadro de la Carlotica", "un armario");
            masterBedroom = new RoomWithHidingPlace("Dormitorio principal", "cama de 2 metros por su sitio", "debajo de la cama");
            secondBedroom = new RoomWithHidingPlace("Cuarto de invitados", "dos camas de 90 pa invitaos", "debajo de la cama");
            bathRoom = new RoomWithHidingPlace("Toileten", "con su señor roca y su lavabo", "en la ducha");
            driveWay = new OutsideWithHidingPlace("Aparcamiento", false, "en el garaje");

            upstairsHallway.Exits = new Location[] {livingRoom, masterBedroom, secondBedroom, bathRoom};
            masterBedroom.Exits = new Location[] {upstairsHallway};
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathRoom.Exits = new Location[] { upstairsHallway };
            driveWay.Exits = new Location[] {frontYard, backYard};


            
           




        }

        private void MoveToANewLocation(Location newLocation)
        {
            currentLocation = newLocation;

            exitsComboBox.Items.Clear();
            foreach (var exit in currentLocation.Exits)
            {
                exitsComboBox.Items.Add(exit.Name);
            }

            exitsComboBox.SelectedIndex = 0;

            descriptionTextBox.Text = currentLocation.Description;

            goThroughTheDoorButton.Visible = currentLocation is IHasExteriorDoor;

            if (newLocation is IHasExteriorDoor)
            {
                var location = newLocation as IHasExteriorDoor;

                goThroughTheDoorButton.Text = $@"Atraviesa {location.DoorDescription}";
            }
        }

        private void goHereButton_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exitsComboBox.SelectedIndex]);
        }

        private void goThroughTheDoorButton_Click(object sender, EventArgs e)
        {
            if (currentLocation is IHasExteriorDoor)
            {
                var location = currentLocation as IHasExteriorDoor;
               
                MoveToANewLocation(location.DoorLocation);
            }
        }

        private void exitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}