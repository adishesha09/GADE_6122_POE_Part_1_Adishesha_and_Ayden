namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public partial class MainForm : Form
    {
        private GameEngine gameEngine;
        private Label lblDisplay;

        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
            ApplyArcadeTheme();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            this.MaximizeBox = false;
            this.MinimizeBox = true; 
            this.Size = new Size(800, 600); 
        }

        private void ApplyArcadeTheme()
        {
            // Set form properties for arcade look
            this.BackColor = Color.Black;
            this.ForeColor = Color.Lime;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "ARCADE ADVENTURE";

            // Remove standard Windows chrome
            this.Padding = new Padding(0);
        }


        private void InitializeGame()
        {
            // Initialize game engine with 10 levels
            gameEngine = new GameEngine(10);

            // Set up display label
            lblDisplay = new Label();
            lblDisplay.AutoSize = false;
            lblDisplay.Dock = DockStyle.Fill;
            lblDisplay.Font = new Font("Consolas", 12);
            lblDisplay.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(lblDisplay);

            // Set up keyboard controls
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;
            this.Focus();

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblDisplay.Text = gameEngine.ToString();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            Direction direction = Direction.None;

            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    direction = Direction.Up;
                    break;
                case Keys.D:
                case Keys.Right:
                    direction = Direction.Right;
                    break;
                case Keys.S:
                case Keys.Down:
                    direction = Direction.Down;
                    break;
                case Keys.A:
                case Keys.Left:
                    direction = Direction.Left;
                    break;
            }

            if (direction != Direction.None)
            {
                gameEngine.TriggerMovement(direction);
                UpdateDisplay();
            }
        }
    }
}