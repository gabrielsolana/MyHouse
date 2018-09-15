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
        private Opponent opponent;
        private int moves;

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
            opponent = new Opponent(frontYard);
            ResetGame(false);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        public void CreateObjects()
        {
            dinningRoom = new Room("Sala de estar", "candelabro de cristal");
            livingRoom = new RoomWithDoor("Comedol", "alfombra antiquísima", "puerta de roble con pomo de latón", "debajo de la mesa");
            kitchen = new RoomWithDoor("Cocina", "electrodomésticos de acero inoxidable", "puerta de cristal juno", "dentro de la nevera");
            frontYard = new OutsideWithDoor("FrontYard", false, "puerta de roble con pomo de latón");
            backYard = new OutsideWithDoor("BackYard", true, "puerta de cristal juno");
            garden = new OutsideWithHidingPlace("Jardín", false, "en la caseta"); 
            stairs = new Room("Escaleras", "taquillón de madera");
            upstairsHallway = new RoomWithHidingPlace("pasillo superior", "cuadro de la Carlotica", "dentro del armario");
            masterBedroom = new RoomWithHidingPlace("Dormitorio principal", "cama de 2 metros por su sitio", "debajo de la cama");
            secondBedroom = new RoomWithHidingPlace("Cuarto de invitados", "dos camas de 90 pa invitaos", "debajo de la cama");
            bathRoom = new RoomWithHidingPlace("Toileten", "con su señor roca y su lavabo", "en la ducha");
            driveWay = new OutsideWithHidingPlace("Aparcamiento", false, "en el garaje");


            livingRoom.Exits = new Location[] { dinningRoom, upstairsHallway };
            dinningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { dinningRoom };
            upstairsHallway.Exits = new Location[] {livingRoom, masterBedroom, secondBedroom, bathRoom};
            masterBedroom.Exits = new Location[] {upstairsHallway};
            secondBedroom.Exits = new Location[] { upstairsHallway };
            bathRoom.Exits = new Location[] { upstairsHallway };
            driveWay.Exits = new Location[] {frontYard, backYard};
            frontYard.Exits = new Location[] { garden, backYard, driveWay };
            backYard.Exits = new Location[] { garden, frontYard, driveWay };
            garden.Exits = new Location[] { frontYard, backYard };

            livingRoom.DoorLocation = frontYard;
            kitchen.DoorLocation = backYard;
            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;

            opponent = new Opponent(frontYard);
        }

        private void MoveToANewLocation(Location newLocation)
        {
            moves++;
            currentLocation = newLocation;
            RedrawForm();
        }

        private void goHereButton_Click(object sender, EventArgs e)
        {
            
            MoveToANewLocation(currentLocation.Exits[exitsComboBox.SelectedIndex]);
        }

        private void goThroughTheDoorButton_Click(object sender, EventArgs e)
        {
            if (currentLocation is IHasExteriorDoor location)
            {
                MoveToANewLocation(location.DoorLocation);
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            moves++;

            if (opponent.Check(currentLocation))
                ResetGame(true);
            else
                RedrawForm();
        }

        private void hideButton_Click(object sender, EventArgs e)
        {

            MoveOpponent10Times();
            goHereButton.Visible = true;
            exitsComboBox.Visible = true;
            MoveToANewLocation(frontYard);

        }

        /// <summary>
        /// Pinta la descripción del lugar, hace que se muestren los botones y les pone las etiquetas correspondientes. 
        /// </summary>
        /// <param name="newLocation"></param>
        private void RedrawForm()
        {
            exitsComboBox.Items.Clear();
            foreach (var exit in currentLocation.Exits)
            {
                exitsComboBox.Items.Add(exit.Name);
            }

            exitsComboBox.SelectedIndex = 0;
            descriptionTextBox.Text += $"\r\nEste es el turno #{moves} \r\n";
            descriptionTextBox.Text += currentLocation.Description;
            goThroughTheDoorButton.Visible = currentLocation is IHasExteriorDoor;
            if (currentLocation is IHidingPlace hidingPlace)
            {
                checkButton.Visible = true;
                checkButton.Text = $"Mira a ver si pillas algo {hidingPlace.HidingPlace}";
            }
            else
                checkButton.Visible = false;

            if (currentLocation is IHasExteriorDoor locationWithExteriorDoor)
            {
                goThroughTheDoorButton.Text = $@"Atraviesa {locationWithExteriorDoor.DoorDescription}";
                goThroughTheDoorButton.Visible = true;
            }
            else
                goThroughTheDoorButton.Visible = false;
        }

        /// <summary>
        /// Resetea al jugador y al oponente (los vuelve a poner en el FrontYard y esconde al oponente moviéndolo 10 veces), esconde todos los botones excepto el de inicio, limpia los textos. Indica el marcador (cuántos movimientos tardaste en encontrar y en qué estancia lo trincaste)
        /// </summary>
        /// <param name="b"></param>
        private void ResetGame(bool displayMassage)
        {
            if (displayMassage)
            {
                IHidingPlace location = currentLocation as IHidingPlace;
                MessageBox.Show($"Mierda, me has pillao en {moves} turnos, co! Estaba escondido {location.HidingPlace}!!", "Cazaooooo");
            }

            ResetFormElements();
            moves = 0;
        }

        // Hide button is shown and all the others hidden.
        private void ResetFormElements()
        {
            hideButton.Visible = true;

            checkButton.Visible = false;
            exitsComboBox.Visible = false;
            goHereButton.Visible = false;
            goThroughTheDoorButton.Visible = false;

            descriptionTextBox.Clear();
        }

        private void MoveOpponent10Times()
        {
            for (int i = 1; i <= 10; i++)
            {
                opponent.Move();
                descriptionTextBox.Text += $"{i}... ";
                Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }
            descriptionTextBox.Text += $"\r\n Ala, a ver si me encuentras, fistro...";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);
        }
    }
}