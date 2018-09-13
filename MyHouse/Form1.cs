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
        private Location currentLocation;

        private Room dinningRoom;
        private RoomWithDoor livingRoom;
        private RoomWithDoor kitchen;

        private Outside garden;
        private OutsideWithDoor frontYard;
        private OutsideWithDoor backYard;


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
            dinningRoom = new Room("Sala de estar", "Candelabro de cristal");
            livingRoom = new RoomWithDoor("Comedol", "Una alfombra antiquísima", "puerta de roble con pomo de latón");
            kitchen = new RoomWithDoor("Cocina", "Electrodomésticos de acero inoxidable", "puerta de cristal juno");
            livingRoom.Exits = new Location[] {dinningRoom};
            dinningRoom.Exits = new Location[] {livingRoom, kitchen};
            kitchen.Exits = new Location[] {dinningRoom};

            frontYard = new OutsideWithDoor("FrontYard", false, "puerta de roble con pomo de latón");
            backYard = new OutsideWithDoor("BackYard", true, "puerta de cristal juno");
            garden = new Outside("Jardín", false);
            frontYard.Exits = new Location[] {garden, backYard};
            backYard.Exits = new Location[] {garden, frontYard};
            garden.Exits = new Location[] {frontYard, backYard};

            livingRoom.DoorLocation = frontYard;
            kitchen.DoorLocation = backYard;

            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
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