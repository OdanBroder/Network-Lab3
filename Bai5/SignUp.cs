using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bai5
{
    public partial class SignUp: Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        private void SignUp_Load(object sender, EventArgs e)
        {
            this.Text = "SignUp";
            this.Size = new Size(600, 350);
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
                Text = "Sign Up",
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
                Location = new Point(40, 70),
                Anchor = AnchorStyles.Top
            };
            mainPanel.Controls.Add(txtUsername);

            Label lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(40, 110),
                Anchor = AnchorStyles.Top
            };
            mainPanel.Controls.Add(lblPassword);

            TextBox txtPassword = new TextBox
            {
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(mainPanel.Width - 80, 35),
                Location = new Point(40, 120),
                PasswordChar = '•',
                Anchor = AnchorStyles.Top
            };
            mainPanel.Controls.Add(txtPassword);

            Button btnSignUp = new Button
            {
                Text = "Sign Up",
                BackColor = Color.FromArgb(0, 120, 215),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(mainPanel.Width - 80, 40),
                Location = new Point(40, 190),
                Anchor = AnchorStyles.Top,
                Cursor = Cursors.Hand
            };
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 100, 190);
            btnSignUp.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 80, 170);
            btnSignUp.Click += (s, ev) => {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter complete information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                Regex regex = new Regex(@"^[a-zA-Z0-9_]{3,20}$");
                if (!regex.IsMatch(username))
                {
                    MessageBox.Show("Invalid username. Username length must be at least 3 and at most 20. Only letters, numbers, and underscore are allowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password.Length < 6 || password.Length > 32)
                {
                    MessageBox.Show("Password length must be at least 6 characters and at most 32!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string dbFile = "db.txt";
                bool exist = false;
                foreach (string line in File.ReadAllLines(dbFile))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 1 && parts[0] == username)
                    {
                        exist = true;
                        break;
                    }
                }

                if (exist)
                {
                    MessageBox.Show("Username already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    return;
                }

                File.AppendAllText(dbFile, $"{username}|{password}\n");
                MessageBox.Show("Sign Up Successful!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            };

            mainPanel.Controls.Add(btnSignUp);

            LinkLabel lnkLogin = new LinkLabel
            {
                Text = "Already have an account? Login",
                AutoSize = true,
                Location = new Point(mainPanel.Width - 220, 260),
                Anchor = AnchorStyles.Top,
                LinkColor = Color.Gray,
                ActiveLinkColor = Color.FromArgb(0, 120, 215),
                Font = new Font("Segoe UI", 8)
            };

            lnkLogin.Click += (s, ev) => {
                Login loginForm = new Login();
                loginForm.Show();
                this.Close();
            };

            mainPanel.Controls.Add(lnkLogin);
            txtUsername.Enter += (s, ev) => txtUsername.BorderStyle = BorderStyle.Fixed3D;
            txtUsername.Leave += (s, ev) => txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Enter += (s, ev) => txtPassword.BorderStyle = BorderStyle.Fixed3D;
            txtPassword.Leave += (s, ev) => txtPassword.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
