using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetCache
{
    public partial class StoreItemPage : Form
    {
        int m_width = 0;
        int m_height = 0;
        Point m_location = Point.Empty;
        FormWindowState m_formWindowState = FormWindowState.Normal;
        public StoreItemPage(FormWindowState state, int width, int height, Point location)
        {
            InitializeComponent();

            m_formWindowState = state;
            Left = Top = 0;
            m_width = width;
            m_height = height;
            m_location = location;
            this.FormClosing += new FormClosingEventHandler(StoreItemPage_FormClosing);
        }

        private void StoreItemPage_Load(object sender, EventArgs e)
        {
            WindowState = m_formWindowState;
            Width = m_width;
            Height = m_height;
            Location = m_location;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "Home")
                {
                    // Open Home Form
                    //Fixed the code for opening a new form
                    Home form1 = new Home();
                    form1.Show();
                    this.Hide();
                    //Application.OpenForms[i].Show();
                    //AdjustWindow(Application.OpenForms[i], WindowState, Width, Height, Location);
                    //this.Close();

                    break;
                }
            }
        }

        private void button_3d_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            int index = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "Browser")
                {
                    formExists = true;
                    index = i;
                }
            }
            if (formExists)
            {
                // If form already exists show it
                Application.OpenForms[index].Show();
                this.Close();
            }
            else
            {
                // Create form for browser with 3d filter on
            }
        }

        private void button_2d_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            int index = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "Browser")
                {
                    formExists = true;
                    index = i;
                }
            }
            if (formExists)
            {
                // If form already exists show it
                Application.OpenForms[index].Show();
                this.Close();
            }
            else
            {
                // Create form for browser with 2d filter on
            }
        }

        private void button_audio_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            int index = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "Browser")
                {
                    formExists = true;
                    index = i;
                }
            }
            if (formExists)
            {
                // If form already exists show it
                Application.OpenForms[index].Show();
                this.Close();
            }
            else
            {
                // Create form for browser with audio filter on
            }
        }

        private void button_vfx_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            int index = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "Browser")
                {
                    formExists = true;
                    index = i;
                }
            }
            if (formExists)
            {
                // If form already exists show it
                Application.OpenForms[index].Show();
                this.Close();
            }
            else
            {
                // Create form for browser with vfx filter on
            }
        }

        private void button_basket_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            int index = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "Basket")
                {
                    formExists = true;
                    index = i;
                }
            }
            if (formExists)
            {
                // If form already exists show it
                Application.OpenForms[index].Show();
                this.Close();
            }
            else
            {
                // Create form for browser with basket filter on
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {

        }

        private void button_account_Click(object sender, EventArgs e)
        {
            bool formExists = false;
            int index = 0;
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "Account")
                {
                    formExists = true;
                    index = i;
                }
            }
            if (formExists)
            {
                // If form already exists show it
                Application.OpenForms[index].Show();
                this.Close();
            }
            else
            {
                // Create form for browser with 3d filter on
            }
        }

        public void AdjustWindow(Form form, FormWindowState formWindowState, int width, int height, Point location)
        {
            form.WindowState = formWindowState;
            form.Width = width;
            form.Height = height;
            form.Location = location;
        }

        

        void StoreItemPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i =0; i< Application.OpenForms.Count; i++)
            {
                Application.OpenForms[i].Close();
            }    
        }
    }
}
