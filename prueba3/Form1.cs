using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSProject = Microsoft.Office.Interop.MSProject;
using MySql.Data.MySqlClient;
using System.Collections;

namespace prueba3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
          
        }
        private string getStringNotNull(MySqlDataReader reader, int col)
        {
            if (reader.IsDBNull(col))
            {
                return "";
            }
            else
            {
                return reader.GetString(col);
            }
        }
        private int getintNotNull(MySqlDataReader reader, int col)
        {
            if (reader.IsDBNull(col))
            {
                return 0;
            }
            else
            {
                return reader.GetInt32(col);
            }
        }
        private double getdoubleNotNull(MySqlDataReader reader, int col)
        {
            if (reader.IsDBNull(col))
            {
                return 0;
            }
            else
            {
                return reader.GetInt32(col);
            }
        }
        private DateTime getDateTimeNotNull(MySqlDataReader reader, int col)
        {
            if (reader.IsDBNull(col))
            {
                return new DateTime(1999, 01, 01);
            }
            else
            {
                return reader.GetDateTime(col);
            }
        }
        //cadenas de construcción de conexión a servidor
        public string connStr = "Server=10.48.13.154;Database=dbgestionocupacion;Uid=userInt;Pwd=userInt123456";
        //"Server=127.0.0.1;Database=dbgestionocupacion;Uid=root;Pwd=";
        //"Server=10.48.13.154;Database=dbgestionocupacion;Uid=userInt;Pwd=userInt123456";
        private void button1_Click(object sender, EventArgs e)
        {
            /* try
           {*/
            MySqlConnection conn = new MySqlConnection(connStr);
            /*}
            catch (Exception errosql)
            {
             MessageBox.Show("Error en conexion a la base de datos\n\n" + errosql.Message);
            }*/
            //tabla Request
            List<int> req_id = new List<int>();
            List<String> ms_project = new List<String>();
            //Tabla activities
            List<String> act_trello_name = new List<String>();
            List<DateTime> act_init_date = new List<DateTime>();
            List<DateTime> act_init_real_date = new List<DateTime>();
            List<DateTime> act_end_date = new List<DateTime>();
            List<DateTime> act_real_end_date = new List<DateTime>();
            List<String> act_title = new List<String>();
            List<String> mails = new List<String>();
            List<double> act_estimated_hours = new List<double>();
            List<double> act_time_loaded = new List<double>();
            List<double> act_porcent = new List<double>();
            List<bool> used = new List<bool>();
            //Llaves
            List<int> for_req_id = new List<int>();
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand command;
                string commandStr = "SELECT * FROM request WHERE req_cargar='false' AND sta_id = 'open';";
                command = new MySqlCommand(commandStr, conn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //MessageBox.Show("aqui\n\n");
                    req_id.Add(reader.GetInt32(0));
                    ms_project.Add(reader.GetString(4));
                }
                reader.Close(); //importante cerrar el reader pues solo se puede tener uno abierto a la vez
                conn.Close();
            }
            catch (Exception errosql)
            {
                MessageBox.Show("Error en la consulta\n\n" + errosql.Message);
            }
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand command;
                string commandStr = "SELECT * FROM activities ORDER BY act_id asc;";
                command = new MySqlCommand(commandStr, conn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    for_req_id.Add(getintNotNull(reader, 1));
                    act_trello_name.Add(getStringNotNull(reader, 2));
                    act_init_date.Add(getDateTimeNotNull(reader, 5));

                    act_init_real_date.Add(getDateTimeNotNull(reader, 6));

                    act_end_date.Add(getDateTimeNotNull(reader, 7));

                    act_real_end_date.Add(getDateTimeNotNull(reader, 8));

                    act_estimated_hours.Add(getdoubleNotNull(reader, 9));

                    act_time_loaded.Add(getdoubleNotNull(reader, 17));
                    act_porcent.Add(getdoubleNotNull(reader, 19));
                    act_title.Add(getStringNotNull(reader, 20));
                    mails.Add(getStringNotNull(reader, 21));
                    used.Add(false);
                }
                reader.Close(); //importante cerrar el reader pues solo se puede tener uno abierto a la vez
                conn.Close();
            }
            catch (Exception errosql)
            {
                MessageBox.Show("Error en la consulta\n\n" + errosql.Message);
            }

            ArrayList tasks = new ArrayList(); // se declara array de las tareas
                                               // creamos un objeto de tipo aplicacion MSProject
            MSProject.Application app = null;
            app = new MSProject.Application();
            int cont = 0;
            int filteredListCount;
            bool test;
            for ( int i= 0; i< ms_project.Count; i++)
            {
                if (ms_project[i] != null)
                {
                    MessageBox.Show("Nombre del Project: "+ms_project[i]);

                    try
                    {
                        // Si no hay problemas para abrir el project entrará en la condición
                        // Fijense en la info que da FileOpen pues aqui indicarás especificas como lo quieres abrir (escritura/lectura) y la ruta, como está aqui es de la forma que se pueda escribir y leer en él
                        if (app.FileOpen("C:/Home/Intelix/Mayoreo/00-Control-Solicitudes/" + ms_project[i] + "", false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSProject.PjPoolOpen.pjPoolReadWrite, Type.Missing, Type.Missing, Type.Missing, Type.Missing))
                        {
                            //Se recorren los proyectos activos
                            foreach (MSProject.Project proj in app.Projects)
                            {
                                //MessageBox.Show(string.Join(",", for_req_id.ToArray()));
                                filteredListCount = for_req_id.Where(x => x == req_id[i]).ToList().Count;
                                
                                if (proj.Tasks.Count < filteredListCount)
                                {
                                    MessageBox.Show("Para esta solicitud se añadieron cartas desde trello");
                                    //proj.Tasks.Add(act_trello_name[i], i + 1);
                                    for (int k = proj.Tasks.Count; k < filteredListCount; k++)
                                    {
                                        proj.Tasks.Add("", k+1);
                                    }
                                }
                                //Se recorre las tareas
                                foreach (MSProject.Task task in proj.Tasks)
                                {
                                    //proj.Tasks.Add(act_trello_name[i], i + 1);
                                    for (int j = 0; j < act_trello_name.Count; j++)
                                    {
                                        test = ((act_trello_name[j] == task.Name || "" == task.Name)
                                            && task.Rollup.ToString() == "False"
                                            && act_title[j] == "false"
                                            && req_id[i] == for_req_id[j]
                                             && used[j] == false);
                                        if (test)
                                        {
                                            used[j] = true;
                                            task.Name = act_trello_name[j];
                                            task.Text10 = mails[j];
                                            task.Number11 = act_time_loaded[j];
                                            task.Start10 = act_init_real_date[j];
                                            task.Finish10 = act_real_end_date[j];
                                            task.Number10 = act_porcent[j]; 
                                            cont++;
                                            continue;
                                        }
                                        if(act_title[j] == "true" && used[j] == false)
                                        {
                                            used[j] = true;
                                        }
                                        if (task.Rollup.ToString() == "True")
                                        {
                                            continue;
                                        }

                                    }
                                }
                                MessageBox.Show(cont + " tareas actualizadas");
                                app.FileClose(Microsoft.Office.Interop.MSProject.PjSaveType.pjSave, false); //cerramos el fichero
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Error en el proyecto\n\n" + err.Message, "Error");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            MySqlConnection conn = new MySqlConnection(connStr);
            MessageBox.Show("Todo bien\n\n");
            //}
            //catch (Exception errosql)
            //{
            // MessageBox.Show("Error en conexion a la base de datos\n\n" + errosql.Message);
            //}
            double[] request_id = new double[50];
            double[] act_request_id = new double[50];
            string[] ms_project = new string[3];

            string act_trello_name;
            string act_init_date;
            string act_mail;
            string act_end_date;
            string act_trello_user;
            double act_estimated_hours;
            double act_time_loaded;
            int contador = 0;
            int contador1 = 0;

            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand command;
                string commandStr = "SELECT * FROM request WHERE req_cargar='true';";
                command = new MySqlCommand(commandStr, conn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //MessageBox.Show("aqui\n\n");
                    request_id[contador1] = reader.GetDouble(0);
                    //MessageBox.Show(request_id[contador1].ToString());
                    ms_project[contador1] = reader.GetString(4);
                    contador1++;
                }
                reader.Close(); //importante cerrar el reader pues solo se puede tener uno abierto a la vez
                conn.Close();
            }
            catch (Exception errosql)
            {
                MessageBox.Show("Error en la consulta\n\n" + errosql.Message);
            }
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand command;
                string commandStr = "SELECT * FROM activities;";
                command = new MySqlCommand(commandStr, conn);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //MessageBox.Show("aqui\n\n");
                    //act_trello_name[contador] = reader.GetString(2);
                    act_request_id[contador1] = reader.GetDouble(1);
                    //MessageBox.Show(act_request_id[contador1].ToString());
                    contador++;
                }
                reader.Close(); //importante cerrar el reader pues solo se puede tener uno abierto a la vez
                conn.Close();
            }
            catch (Exception errosql)
            {
                MessageBox.Show("Error en la consulta1\n\n" + errosql.Message);
            }

            ArrayList tasks = new ArrayList(); // se declara array de las tareas
                                               // creamos un objeto de tipo aplicacion MSProject
            int cont = 0;
            int cont1 = 0;

            string[] task_names = new string[50];
            MSProject.Application app = null;
            app = new MSProject.Application();

            foreach (String project in ms_project)
            {
                if (project != null)
                {
                    MessageBox.Show(project);
                    try
                    {
                        // Si no hay problemas para abrir el project entrará en la condición
                        // Fijense en la info que da FileOpen pues aqui indicarás especificas como lo quieres abrir (escritura/lectura) y la ruta, como está aqui es de la forma que se pueda escribir y leer en él
                        if (app.FileOpen("C:/Home/Intelix/Mayoreo/00-Control-Solicitudes/" + project + "", false, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, MSProject.PjPoolOpen.pjPoolReadWrite, Type.Missing, Type.Missing, Type.Missing, Type.Missing))
                        {

                            foreach (MSProject.Project proj in app.Projects)
                            {
                                //Se recorre las tareas
                                foreach (MSProject.Task task in proj.Tasks)
                                {
                                    if (task.Rollup.ToString() == "False")
                                    {
                                        act_trello_name = task.Name;
                                        act_time_loaded = task.ActualWork / 60;
                                        act_estimated_hours = task.Work / 60;
                                        act_init_date = String.Format("{0:yyyy-MM-dd HH:mm:ss}", task.Start);
                                        act_end_date = String.Format("{0:yyyy-MM-dd HH:mm:ss}", task.Finish);
                                        act_trello_user = task.ResourceNames;
                                        act_mail = task.Text10;


                                        try
                                        {

                                            //MessageBox.Show("INSERT INTO activities (act_request_id, act_trello_name, act_init_date, act_end_date, act_estimated_hours, act_time_loaded ,act_porcent, act_title, act_trello_user, act_mail) VALUES (" + request_id[cont1] + ",'" + act_trello_name + "','" + act_init_date + "', '" + act_end_date + "', " + act_estimated_hours + "," + act_time_loaded + ", " + act_porcent + ", 'false', '" + act_trello_user + "', '" + act_mail + "')");
                                            conn.Open();
                                            MySqlDataReader reader;

                                            MySqlCommand command1;

                                            string commandStr1 = "INSERT INTO activities (req_id, act_trello_name, act_init_date, act_end_date, act_estimated_hours, act_time_loaded ,act_porcent, act_title, act_trello_user, act_mail) VALUES (" + request_id[cont1] + ",'" + act_trello_name + "','" + act_init_date + "', '" + act_end_date + "', " + act_estimated_hours + "," + act_time_loaded + ", " + 0 + ", 'false', '" + act_trello_user + "', '" + act_mail + "')";

                                            command1 = new MySqlCommand(commandStr1, conn);
                                            reader = command1.ExecuteReader();
                                            reader.Close(); //importante cerrar el reader pues solo se puede tener uno abierto a la vez
                                            conn.Close();
                                            cont++;
                                        }
                                        catch (Exception errosql)
                                        {
                                            MessageBox.Show("Error en la consulta1\n\n" + errosql.Message);
                                        }


                                        //continue;
                                    }
                                    else
                                    {
                                        act_trello_name = task.Name;
                                        act_time_loaded = task.Number11 / 60;
                                        act_estimated_hours = task.Work / 60;
                                        act_init_date = String.Format("{0:yyyy-MM-dd HH:mm:ss}", task.Start);
                                        act_end_date = String.Format("{0:yyyy-MM-dd HH:mm:ss}", task.Finish);

                                        if (cont % 10 == 0 && cont != 0)
                                        {
                                            MessageBox.Show("10 tareas agregadas a la base de datos");
                                        }


                                        try
                                        {
                                            //MessageBox.Show("INSERT INTO activities (act_request_id, act_trello_name, act_init_date, act_end_date, act_estimated_hours, act_time_loaded ,act_porcent, act_title, act_trello_user, act_mail) VALUES (" + request_id[cont1] + ",'" + act_trello_name + "','" + act_init_date + "', '" + act_end_date + "', " + act_estimated_hours + "," + act_time_loaded + ", " + act_porcent + ", 'true', '', '')");
                                            conn.Open();
                                            MySqlDataReader reader;

                                            MySqlCommand command1;

                                            string commandStr1 = "INSERT INTO activities (req_id, act_trello_name, act_init_date, act_end_date, act_estimated_hours, act_time_loaded ,act_porcent, act_title, act_trello_user, act_mail) VALUES (" + request_id[cont1] + ",'" + act_trello_name + "','" + act_init_date + "', '" + act_end_date + "', " + act_estimated_hours + "," + act_time_loaded + ", " + 0 + ", 'true', '', '')";

                                            command1 = new MySqlCommand(commandStr1, conn);
                                            reader = command1.ExecuteReader();
                                            reader.Close(); //importante cerrar el reader pues solo se puede tener uno abierto a la vez
                                            conn.Close();
                                            cont++;
                                        }
                                        catch (Exception errosql)
                                        {
                                            MessageBox.Show("Error en la consulta1\n\n" + errosql.Message);
                                        }



                                    }

                                }
                            }

                            MessageBox.Show(cont + " tareas agregadas a la base de datos");
                            app.FileClose(Microsoft.Office.Interop.MSProject.PjSaveType.pjSave, false); //cerramos el fichero
                        }

                        //}
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Error en el proyecto\n\n" + err.Message, "Error");
                    }
                    cont1++;
                }
            }
        }

        private void txt_reqtitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txt_reqresp_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlDataReader reader;
                MySqlCommand command1;
                //string commandStr1 = "INSERT INTO request (board_id, req_ms_project, cli_id, req_title, req_description, req_responsable, sta_id) VALUES (" + txt_boardid.Text + ")";
                string commandStr1 = "INSERT INTO request (board_id, req_ms_project, cli_id, req_title, req_description, req_responsable, sta_id) VALUES ('" + txt_boardid.Text + "', '"+  txt_mpp.Text +"', '"+ 1 +"', '"+txt_reqtitle.Text+"', '"+txt_reqdescription.Text+"', '"+txt_reqresp.Text+"','open')";

                command1 = new MySqlCommand(commandStr1, conn);
                reader = command1.ExecuteReader();
                reader.Close(); //importante cerrar el reader pues solo se puede tener uno abierto a la vez
                conn.Close();
                MessageBox.Show("Request creado\n\n");
            }
            catch (Exception errosql)
            {
                MessageBox.Show("Error en la consulta1\n\n" + errosql.Message);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
