using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Bai5
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Text = "Login";
            this.ClientSize = new Size(600, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(40)
            };
            this.Controls.Add(mainPanel);

            Label lblTitle = new Label
            {
                Text = "Login",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 120, 215),
                AutoSize = true,
                Location = new Point(260, 10),
                Anchor = AnchorStyles.Top
            };
            mainPanel.Controls.Add(lblTitle);

            Label lblUsername = new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(40, 60),
                Anchor = AnchorStyles.Top
            };
            mainPanel.Controls.Add(lblUsername);

            TextBox txtUsername = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(mainPanel.Width - 80, 35),
                Location = new Point(40, 80),
                Anchor = AnchorStyles.Top
            };
            mainPanel.Controls.Add(txtUsername);

            Label lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(40, 130),
                Anchor = AnchorStyles.Top
            };
            mainPanel.Controls.Add(lblPassword);

            TextBox txtPassword = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(mainPanel.Width - 80, 35),
                Location = new Point(40, 150),
                PasswordChar = '•',
                Anchor = AnchorStyles.Top
            };
            mainPanel.Controls.Add(txtPassword);

            Button btnLogin = new Button
            {
                Text = "Login",
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(mainPanel.Width - 80, 40),
                Location = new Point(40, 210),
                Anchor = AnchorStyles.Top,
                Cursor = Cursors.Hand
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 170);
            btnLogin.Click += (s, ev) => {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter complete information!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
                }

                string dbFile = "db.txt";
                bool ok = false;
                foreach (string line in File.ReadAllLines(dbFile))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 1 && parts[0] == username && parts[1] == password)
                    {
                        ok = true;
                        break;
                    }
                }

                if (ok)
                {
                    MessageBox.Show("hehe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            };
            mainPanel.Controls.Add(btnLogin);

            LinkLabel lnkForgot = new LinkLabel
            {
                Text = "Forgot password?",
                AutoSize = true,
                Location = new Point(40, 260),
                Anchor = AnchorStyles.Top,
                LinkColor = Color.Gray,
                ActiveLinkColor = Color.FromArgb(0, 120, 215),
                Font = new Font("Segoe UI", 8)
            };
            lnkForgot.Click += (s, ev) => {
                MessageBox.Show("Please contact system administrator!", "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            mainPanel.Controls.Add(lnkForgot);

            LinkLabel lnkSignUp = new LinkLabel
            {
                Text = "Don't have an account? Sign Up",
                AutoSize = true,
                Location = new Point(mainPanel.Width - 220, 260),
                Anchor = AnchorStyles.Top,
                LinkColor = Color.Gray,
                ActiveLinkColor = Color.FromArgb(0, 120, 215),
                Font = new Font("Segoe UI", 8)
            };
            lnkSignUp.Click += (s, ev) => {
                SignUp signUpForm = new SignUp(); 
                signUpForm.Show();
                this.Close();
            };
            mainPanel.Controls.Add(lnkSignUp);

            txtUsername.Enter += (s, ev) => txtUsername.BorderStyle = BorderStyle.Fixed3D;
            txtUsername.Leave += (s, ev) => txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Enter += (s, ev) => txtPassword.BorderStyle = BorderStyle.Fixed3D;
            txtPassword.Leave += (s, ev) => txtPassword.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
