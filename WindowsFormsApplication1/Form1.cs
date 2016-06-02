using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargaGrid();
        }

        private void CargaGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Checked", typeof(Int32));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Rows.Add(0, "ABC");
            dt.Rows.Add(0, "DEF");
            dt.Rows.Add(0, "HIJ");
            dt.Rows.Add(0, "KLM");
            dt.Rows.Add(0, "NOP");

            ((ListBox)checkedListBox1).DataSource = dt;
            ((ListBox)checkedListBox1).DisplayMember = "Nombre";
            ((ListBox)checkedListBox1).ValueMember = "Checked";

            string seleccionados = "Valores seleccionados: ";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool isChecked = Convert.ToBoolean(Convert.ToInt32(dt.Rows[i]["Checked"].ToString()));
                this.checkedListBox1.SetItemChecked(Convert.ToInt32(i), isChecked);
                if (isChecked)
                {
                    seleccionados += string.Format("{0},", i.ToString());
                }
            }

            //MessageBox.Show(seleccionados);
        }

        private void btnGetRow_Click(object sender, EventArgs e)
        {
            string seleccionados = "Valores seleccionados: ";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    DataRowView oDataRowView = checkedListBox1.Items[i] as DataRowView;
                    seleccionados += string.Format("{0},", oDataRowView.Row["Nombre"].ToString());
                }
            }
            MessageBox.Show(seleccionados);
        }
    }
}