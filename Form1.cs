using stajKacisOyunu;
using System.Media;

namespace stajKacisOyunu
{
    public partial class Form1 : Form
    {
        SoundPlayer soundPlayer = new SoundPlayer(Resources.explosion);

        Random xRandom = new Random(); /*0-750*/

        PictureBox grenade;
        PictureBox grenade2;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                character.Location = new Point(character.Location.X - 7, character.Location.Y);
                character.Image = Resources.runner_left;
            }
            if (e.KeyCode == Keys.Right)
            {
                character.Location = new Point(character.Location.X + 7, character.Location.Y);
                character.Image = Resources.runner_right;
            }
        }

        private void generationTimer_Tick(object sender, EventArgs e)
        {
            grenade = new PictureBox();
            grenade.Image = Resources.grenade;
            grenade.SizeMode = PictureBoxSizeMode.CenterImage;
            grenade.Size = new Size(50, 50);
            grenade.Location = new Point(xRandom.Next(0, 750), 20);


            grenade2 = new PictureBox();
            grenade2.Image = Resources.grenade;
            grenade2.SizeMode = PictureBoxSizeMode.CenterImage;
            grenade2.Size = new Size(50, 50);
            grenade2.Location = new Point(xRandom.Next(0, 750), 20);

            this.Controls.Add(grenade);
            this.Controls.Add(grenade2);
        }

        private void movementTimer_Tick(object sender, EventArgs e)
        {
            if (grenade != null && grenade2 != null)
            {
                grenade.Location = new Point(grenade.Location.X, grenade.Location.Y + 7);
                grenade2.Location = new Point(grenade2.Location.X, grenade2.Location.Y + 7);
            
                if (character.Bounds.IntersectsWith(grenade.Bounds) && character.Bounds.IntersectsWith(grenade2.Bounds))
                {
                    grenade.Dispose();
                    grenade2.Dispose();

                    generationTimer.Stop();
                    movementTimer.Stop();

                    soundPlayer.Play();

                    MessageBox.Show("OYUN BÝTTÝ. KAYBETTÝNÝZ");

                    this.Dispose(); 
                }
            
            }
        }
    }
}
