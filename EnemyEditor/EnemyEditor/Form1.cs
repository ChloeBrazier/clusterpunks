using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//Liam Perry
//External Tool (Enemy Editor) for Cluster Punks
//Warren Warriors
//GDAPS 2, Section 7
//2/28/19

namespace EnemyEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Variable to store the filename
        string fileName;

        //Code for the Saving of new files
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool picture; //If Sprite is present, true.
                if (ImageDisplay.Image == null)
                    picture = false;
                else
                    picture = true;
                string name = textBox1.Text;
                int health = int.Parse(textBox2.Text);
                int atk = int.Parse(this.textBox3.Text);
                int speed = int.Parse(textBox4.Text);
                int cooldown = int.Parse(textBox5.Text);
                if (name == "" || health < 10 || health > 500 || atk < 1 || atk > 10 || speed < 1 || speed > 10  || cooldown < 1 || cooldown > 10 || !picture) //If any fields are blank
                {
                    string message = "Errors:\n"; //Errors depending on which fields are out of bounds or blank
                    if (name == "")
                        message += "- No name entered. Please enter a name\n";
                    if (health < 10)
                        message += "- Health too low. Minimum is 10\n";
                    if (health > 500)
                        message += "- health too large. Maximum is 500\n";
                    if (atk < 1)
                        message += "- Attack too small. Minimum is 10\n";
                    if (atk > 10)
                        message += "- Attack too large. Maximum is 10\n";
                    if (speed < 1)
                        message += "- Speed too small. Minimum is 10\n";
                    if (speed > 10)
                        message += "- Speed too large. Maximum is 10\n";
                    if (cooldown < 1)
                        message += "- Cooldown too small. Minimum is 10\n";
                    if (cooldown > 10)
                        message += "- Cooldown too large. Maximum is 10\n";
                    if (!picture)
                        message += "- No sprite selected. Please select a sprite\n";
                    MessageBox.Show(message, "Error Saving File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    SaveFileDialog saving = new SaveFileDialog();
                    saving.Title = "Save an Enemy File"; //Saves files to type .enemy
                    saving.Filter = "Enemy File (*.enemy)|*.enemy";
                    saving.RestoreDirectory = true;
                    if (saving.ShowDialog() != DialogResult.OK)
                        return;
                    System.IO.StreamWriter writer = new StreamWriter(saving.FileName); //Writes Data to files
                    writer.WriteLine(name);
                    writer.WriteLine(health);
                    writer.WriteLine(atk);
                    writer.WriteLine(speed);
                    writer.WriteLine(cooldown);
                    writer.WriteLine(fileName);
                    writer.Close();
                    MessageBox.Show("File saved successfully", "Saving Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch //If any of the int-based text boxes are left empty
            {
                MessageBox.Show("One or more input boxes is missing an input. Please fill out all boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Code to load in the selected sprites
        private void ImageLoader_Click(object sender, EventArgs e)
        {
            ImageDisplayText.Text = "Current Image: ";
            OpenFileDialog loading = new OpenFileDialog();
            loading.Title = "Load a sprite";
            loading.Filter = "Sprite (*.png)|*.png"; //Loads PNGs only
            loading.RestoreDirectory = true;
            if (loading.ShowDialog() != DialogResult.OK)
                return;
            ImageDisplayText.Text += loading.FileName; //Adds to the display text
            ImageDisplay.Image = new Bitmap(loading.FileName); //Displays the image
            ImageDisplay.SizeMode = PictureBoxSizeMode.Zoom; //Makes the image fit the box
            fileName = loading.FileName; //Sets filename to the storage variable
        }

        //Code to load existing enemy files for editing
        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            //Variables to store loaded data
            string name;
            string health;
            string atk;
            string speed;
            string cooldown;

            //File Selection
            OpenFileDialog loading = new OpenFileDialog();
            loading.Title = "Load an Enemy File";
            loading.Filter = "Enemy File (*.enemy)|*.enemy"; //Loads files of type .enemy
            loading.RestoreDirectory = true;
            if (loading.ShowDialog() != DialogResult.OK)
                return;

            //File Reading
            System.IO.StreamReader reader = new StreamReader(loading.FileName);
            name = reader.ReadLine();
            health = reader.ReadLine();
            atk = reader.ReadLine();
            speed = reader.ReadLine();
            cooldown = reader.ReadLine();
            fileName = reader.ReadLine();
            reader.Close();

            //Data Displaying
            textBox1.Text = name;
            textBox2.Text = health;
            textBox3.Text = atk;
            textBox4.Text = speed;
            textBox5.Text = cooldown;
            ImageDisplayText.Text = "Current Image: ";
            ImageDisplayText.Text = "Current Image: ";
            ImageDisplayText.Text += fileName; //Adds to the display text
            ImageDisplay.Image = new Bitmap(fileName); //Displays the image
            ImageDisplay.SizeMode = PictureBoxSizeMode.Zoom; //Makes the image fit the box

            MessageBox.Show("File loaded successfully", "Loading Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
