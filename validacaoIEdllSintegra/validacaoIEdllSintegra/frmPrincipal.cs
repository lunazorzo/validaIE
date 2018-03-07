using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace validacaoIEdllSintegra
{
    public partial class frmPrincipal : Form
    {
        [DllImport("DllInscE32.dll")]
        public static extern int ConsisteInscricaoEstadual(string cInsc, string cUF);
        String sgEstado;
        String ieLimpa;
        Int32 retornoIE;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {            
            try
            {
                
                bool prossegue = true;
                if (cbEstados.SelectedIndex == -1 && prossegue)
                {
                    MessageBox.Show("É necessário informar o Estado!");
                    cbEstados.Focus();
                    prossegue = false;
                }
                if (txtIE.Text.Equals(string.Empty) && prossegue)
                {
                    MessageBox.Show("É necessário informar a IE!");
                    cbEstados.Focus();
                    prossegue = false;
                }
                if (prossegue == true)
                {
                    ieLimpa = OnlyNumbers(txtIE.Text);
                    // AC - ACRE 
                    if (cbEstados.SelectedIndex == 0) { sgEstado = "AC"; }
                    //AL - ALAGOAS 
                    if (cbEstados.SelectedIndex == 1) { sgEstado = "AL"; }
                    //AM - AMAZONAS                                
                    if (cbEstados.SelectedIndex == 2) { sgEstado = "AM"; }
                    //AP - AMAPÁ                                   
                    if (cbEstados.SelectedIndex == 3) { sgEstado = "AP"; }
                    //BA - BAHIA                                   
                    if (cbEstados.SelectedIndex == 4) { sgEstado = "BA"; }
                    //CE - CEARÁ                                   
                    if (cbEstados.SelectedIndex == 5) { sgEstado = "CE"; }
                    //DF - DISTRITO FEDERAL                        
                    if (cbEstados.SelectedIndex == 6) { sgEstado = "DF"; }
                    //ES - ESPÍRITO SANTO                          
                    if (cbEstados.SelectedIndex == 7) { sgEstado = "ES"; }
                    //GO - GOIÁS                                   
                    if (cbEstados.SelectedIndex == 8) { sgEstado = "GO"; }
                    //MA - MARANHÃO                                
                    if (cbEstados.SelectedIndex == 9) { sgEstado = "MA"; }
                    //MG - MINAS GERAIS 
                    if (cbEstados.SelectedIndex == 10) { sgEstado = "MG"; }
                    //MS - MATO GROSSO DO SUL                       
                    if (cbEstados.SelectedIndex == 11) { sgEstado = "MS"; }
                    //MT - MATO GROSSO                              
                    if (cbEstados.SelectedIndex == 12) { sgEstado = "MT"; }
                    //PA - PARÁ                                     
                    if (cbEstados.SelectedIndex == 13) { sgEstado = "PA"; }
                    //PB - PARAÍBA                                  
                    if (cbEstados.SelectedIndex == 14) { sgEstado = "PB"; }
                    //PE - PERNAMBUCO                               
                    if (cbEstados.SelectedIndex == 15) { sgEstado = "PE"; }
                    //PI - PIAUÍ                                    
                    if (cbEstados.SelectedIndex == 16) { sgEstado = "PI"; }
                    //PR - PARANÁ                                   
                    if (cbEstados.SelectedIndex == 17) { sgEstado = "PR"; }
                    //RJ - RIO DE JANEIRO                           
                    if (cbEstados.SelectedIndex == 18) { sgEstado = "RJ"; }
                    //RN - RIO GRANDE DO NORTE                      
                    if (cbEstados.SelectedIndex == 19) { sgEstado = "RN"; }
                    //RO - RONDÔNIA                                 
                    if (cbEstados.SelectedIndex == 20) { sgEstado = "RO"; }
                    //RR - RORAIMA                                  
                    if (cbEstados.SelectedIndex == 21) { sgEstado = "RR"; }
                    //RS - RIO GRANDE DO SUL                        
                    if (cbEstados.SelectedIndex == 22) { sgEstado = "RS"; }
                    //SC - SANTA CATARINA                           
                    if (cbEstados.SelectedIndex == 23) { sgEstado = "SC"; }
                    //SE - SERGIPE                                  
                    if (cbEstados.SelectedIndex == 24) { sgEstado = "SE"; }
                    //SP - SÃO PAULO                                
                    if (cbEstados.SelectedIndex == 25) { sgEstado = "SP"; }
                    //TO - TOCANTINS                                
                    if (cbEstados.SelectedIndex == 26) { sgEstado = "TO"; }

                    retornoIE = ConsisteInscricaoEstadual(ieLimpa, sgEstado);
                    if (retornoIE == 0)
                    {
                        MessageBox.Show("Incrição Estadual válida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (retornoIE == 1)
                    {
                        MessageBox.Show("Incrição Estadual inválida", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (retornoIE == 2)
                    {
                        MessageBox.Show("Parâmetro inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtIE.Clear();
                    cbEstados.SelectedIndex = -1;
                    cbEstados.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao válidar IE! \n" + erro.Message);
            }
        }
        public string OnlyNumbers(string toNormalize)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(toNormalize, "");
            return resultString;
        } 
    }
}
