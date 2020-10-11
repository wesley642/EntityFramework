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
    public partial class FormAula : Form
    {
        public FormAula()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb1 = new Contexto())
                {
                    tb1.ObjetoSalaAula.Add(new SalaAula { Professor = txtProfessor.Text, Sala = txtSala.Text, Curso = txtCurso.Text, Data = Convert.ToDateTime(txtData.Text) });
                    tb1.SaveChanges();
                }
                //Atualizar o grid
                limparcampos();
                AtualizarGrid();
                MessageBox.Show("Incluido com súcesso", "Inclusão");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AtualizarGrid()
        {
            using (var tb1 = new Contexto())
            {
                gridAula.DataSource = null;
                gridAula.DataSource = tb1.ObjetoSalaAula.ToList();
            }
        }


        public void limparcampos()
        {
            txtId.Clear();
            txtProfessor.Clear();
            txtSala.Clear();
            txtCurso.Clear();
            txtData.Clear();
            AtualizarGrid();
        }

        private void gridAula_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = gridAula.CurrentRow.Cells[0].Value.ToString();
            txtProfessor.Text = gridAula.CurrentRow.Cells[1].Value.ToString();
            txtSala.Text = gridAula.CurrentRow.Cells[2].Value.ToString();
            txtCurso.Text = gridAula.CurrentRow.Cells[3].Value.ToString();
            txtData.Text = gridAula.CurrentRow.Cells[4].Value.ToString();

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb1 = new Contexto())
                {
                    var objeto = tb1.ObjetoSalaAula.Find(Convert.ToInt32(txtId.Text));
                    objeto.Professor = txtProfessor.Text;
                    objeto.Sala = txtSala.Text;
                    objeto.Curso = txtCurso.Text;
                    objeto.Data = Convert.ToDateTime(txtData.Text);

                    tb1.Entry(objeto).State = EntityState.Modified;
                    tb1.SaveChanges();

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

        private void FormAula_Load(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var tb1 = new Contexto())
                {
                    var objeto = tb1.ObjetoSalaAula.Find(Convert.ToInt32(txtId.Text));
                    tb1.ObjetoSalaAula.Remove(objeto);
                    tb1.SaveChanges();
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
