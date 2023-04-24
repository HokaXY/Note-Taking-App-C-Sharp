using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class Notetaker : Form
    {
        DataTable notes = new DataTable();
        bool editing = false;
        public Notetaker()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            PreviousNotes.DataSource = notes;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) { Console.WriteLine("Not a valid note"); }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void NewNoteButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Notes"] = titleBox.Text;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                notes.Rows[PreviousNotes.CurrentCell.RowIndex]["Notes"] = titleBox.Text;
            }
            else
            {
                notes.Rows.Add(titleBox.Text, noteBox.Text);
            }
            titleBox.Text = "";
            noteBox.Text = "";
            editing = false;
        }

        private void titleBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void noteBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PreviousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            noteBox.Text = notes.Rows[PreviousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

    }
}
