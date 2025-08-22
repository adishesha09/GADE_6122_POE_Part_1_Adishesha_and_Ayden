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
            this.Size = new Size(1920, 1080); 
        }

        private void ApplyArcadeTheme()
        {
            // Set form properties for arcade look
            this.BackColor = Color.Black;
            this.ForeColor = Color.Lime;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "CODE CRAWLER";

            // Remove standard Windows chrome
            this.Padding = new Padding(0);
        }


        private void InitializeGame()
        {
            // Remove any existing controls first
            this.Controls.Clear();

            // Create CRT effect panel
            var crtPanel = new CRTEffectPanel();
            crtPanel.Dock = DockStyle.Fill;
            crtPanel.BackColor = Color.Black;
            crtPanel.Size = this.ClientSize;

            // Set up display label
            lblDisplay = new Label();
            lblDisplay.AutoSize = false;
            lblDisplay.Dock = DockStyle.Fill;
            lblDisplay.Font = new Font("Consolas", 16, FontStyle.Bold);
            lblDisplay.ForeColor = Color.Lime;
            lblDisplay.BackColor = Color.Transparent;
            lblDisplay.TextAlign = ContentAlignment.MiddleCenter;

            // Add label to CRT panel, then panel to form
            crtPanel.Controls.Add(lblDisplay);
            this.Controls.Add(crtPanel);

            // Initialize game engine
            gameEngine = new GameEngine(10);

            // Calculate size based on current level dimensions
            int levelWidth = gameEngine.CurrentLevel.Width;
            int levelHeight = gameEngine.CurrentLevel.Height;

            // Set form size dynamically
            int formWidth = (levelWidth * 10) + 40; 
            int formHeight = (levelHeight * 16) + 80; 

            this.ClientSize = new Size(formWidth, formHeight);
            this.MinimumSize = new Size(formWidth, formHeight);

            // Set up keyboard controls
            this.KeyPreview = true;
            this.KeyDown += MainForm_KeyDown;

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            lblDisplay.Text = gameEngine.ToString();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameEngine.State == GameState.Complete || gameEngine.State == GameState.GameOver)
            {
                // Any key restarts the game when completed or game over
                ArcadeSounds.PlayRestartSound();
                gameEngine.RestartGame();
                UpdateDisplay();
                return;
            }

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
                ArcadeSounds.PlayMoveSound();
                UpdateDisplay();
            }
        }
    }
}