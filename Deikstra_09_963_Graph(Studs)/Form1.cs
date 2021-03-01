using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Deikstra_09_963;

namespace Deikstra_09_963_Graph_Studs_
{
    public partial class Form1 : Form
    {

        private GraphPainter gp = null;
        private Graph g;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs ea)
        {
            try
            {
                var file = GetGraphFileName();
                if (file != null && File.Exists(file))
                {
                    var data = Loader.LoadData(file);
                    g = new Graph(data);
                    gp = new GraphPainter(g);
                    nudTo.Value = nudTo.Maximum = nudFrom.Maximum = g.VertexCount;
                    nudTo.Enabled = nudFrom.Enabled = btnFind.Enabled = true;
                    mainPanel.Refresh();          
                }
                
                /*int b = 1;
                int e = 6;
                var path = g.GetShortestPath(b, e);
                ShowPath(path);
                Console.WriteLine("Длина кратчайшего пути: {0}", Graph.GetShortestPathLength(path));
                b = 2;
                path = g.GetShortestPath(b, e);
                ShowPath(path);
                Console.WriteLine("Длина кратчайшего пути: {0}", Graph.GetShortestPathLength(path));*/
            }
            catch (IOException e)
            {
                Console.WriteLine("Проблема с чтением из файла :(");
            }
            catch (Exception e)
            {
                Console.WriteLine("Что-то пошло не так :(");
            }
        }

        private string GetGraphFileName()
        {
            return "data.csv";
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            gp?.Paint(mainPanel.CreateGraphics());
        }
    }
    
}
