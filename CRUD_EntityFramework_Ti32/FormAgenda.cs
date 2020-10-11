using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace CRUD_EntityFramework_Ti32
{
    public partial class FormAgenda : Form
    {
        public FormAgenda()
        {
            InitializeComponent();
        }

        private void cadtelefoneBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cadtelefoneBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.cadagendaDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cadagendaDataSet.cadtelefone'. Você pode movê-la ou removê-la conforme necessário.
            this.cadtelefoneTableAdapter.Fill(this.cadagendaDataSet.cadtelefone);
            AtualizarGrid();

        }

        private void btninserir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb = new Contexto())
                {
                    tb.ObjetoAgenda.Add(new Agenda { nome = txtNome.Text, telefone = txtTelefone.Text, Salario = Convert.ToDouble(txtSalario.Text), CEP = txtCEP.Text });
                    tb.SaveChanges();
                }
                //Atualizar o grid
                limparcampos();
                MessageBox.Show("Incluido com súcesso", "Inclusão");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            




        }

        public void limparcampos()
        {
            txtId.Clear();
            txtNome.Clear();
            txtTelefone.Clear();
            txtCEP.Clear();
            txtSalario.Clear();
            AtualizarGrid();
        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb = new Contexto())
                {
                    var objeto = tb.ObjetoAgenda.Find(Convert.ToInt32(txtId.Text));
                    objeto.nome = txtNome.Text;
                    objeto.telefone = txtTelefone.Text;
                    objeto.CEP = txtCEP.Text;
                    objeto.Salario = Convert.ToDouble(txtSalario.Text);

                    tb.Entry(objeto).State = EntityState.Modified;
                    tb.SaveChanges();

                    MessageBox.Show("Alteração realizada com sucesso", "Alteração");
                    AtualizarGrid();
                    limparcampos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AtualizarGrid();
        }



        public void AtualizarGrid()
        {
            using (var tb = new Contexto())
            {
                grid.DataSource = null;
                grid.DataSource = tb.ObjetoAgenda.ToList();
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtTelefone.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtCEP.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtSalario.Text = grid.CurrentRow.Cells[4].Value.ToString();

        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb = new Contexto())
                {
                    var objeto = tb.ObjetoAgenda.Find(Convert.ToInt32(txtId.Text));
                    tb.ObjetoAgenda.Remove(objeto);
                    tb.SaveChanges();
                    MessageBox.Show("Excluido com súcesso", "Exclusão");
                    AtualizarGrid();
                    limparcampos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
