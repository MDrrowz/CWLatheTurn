using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using static CWLatheTurn.Form1;
using System.Reflection;

namespace CWLatheTurn
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitDGV1();

            //outputTB1Print(savedInfo, dt);

        }
        

        //DATA
        DataTable dt = new DataTable();
        DataTable st = new DataTable();

        JobInfo savedInfo = new JobInfo
        {
            WO = 12345,
            Name = "Sick Nancheth",
            Engine = "LS3",
            CrankMfg = "OE",
            Date = new DateTime(2020, 11, 3),
            ImbaRad = 3.25m,
        };

        string defaultPath = Path.GetFullPath(@"C:\Users\machine shop\source\repos\CWLatheTurn\SaveLoad Files");
        string defaultFileName = "ThisIsTheDefaultFileName";

        public class JobInfo
        {
            public int WO { get; set; }
            public string Name { get; set; }
            public string Engine { get; set; }
            public string CrankMfg { get; set; }
            public DateTime Date { get; set; }
            public decimal ImbaRad { get; set; }
            public decimal ImbaAng { get; set; }
            public decimal ImbaMass { get; set; }
        }

        void outputTB1Print ()
        {
            outputTB1.Text = SaveDataSerialize(savedInfo, dt);
        }

        string SaveDataSerialize (JobInfo ji, DataTable mt)
        {
            StringBuilder outString = new StringBuilder();
            return outString.Append($"{JobInfoToString(ji)} | {MeasTableToString(mt)}").ToString();
        }

        string JobInfoToString (JobInfo info) //woooo it fucking works
        {
            PropertyInfo[] props = typeof(JobInfo).GetProperties();
            StringBuilder sb = new StringBuilder();
            sb.Append("JobInfo:{");
            try
            {
                string str = String.Empty;
                int iter = 1;
                int numItems = props.Count();
                foreach (PropertyInfo prop in props)
                {
                    sb.Append($"{prop.Name}, {prop.GetValue(info)}");
                    if (iter < numItems) sb.Append("; ");
                    iter++;
                }                
            }
            catch 
            {
                sb.Append("Datatable is NULL");
            }
            sb.Append('}');
            return sb.ToString();
        }     
        
        string MeasTableToString (DataTable dt)
        {
            StringBuilder sb = new StringBuilder("Measurements:{");

            if (dt != null)
            {
                int iter = 1;
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append($"{row[1]},{row[2]}");
                    if (iter < dt.Rows.Count * 2) sb.Append(';');
                }
            }
            sb.Append("}");
            return sb.ToString();
        }

        void StringToMeasTable (string saveStr)
        {
            string str = string.Empty;
            dt.Rows.Clear();
            outputTB1.Clear();
            outputTB1.Text = saveStr; 
            outputTB1.AppendText(Environment.NewLine);

            string[] subStr1 = saveStr.Split('|')[1].Split(':')[1].Split('{', '}')[1].Split(';');
            int i = 1;

            foreach (string subStr2 in subStr1)
            {
                string[] meas = subStr2.Split(',');
                dt.Rows.Add(i, meas[0], meas[1]);
                outputTB1.Text += $"{i}: {{{meas[0]}, {meas[1]}}}";
                if (i < subStr1.Count()) outputTB1.Text += "; ";
                i++;
            }
            DGV1reload();
        }


        //SAVE/LOAD FILE
        public void LoadFile() //unfinished
        {
                if (true) //allow load conditions here
                {
                st.Clear(); //clears storage datatable
                st = dt; //save measurement datatable to storage datatable
                //dt.Clear();  //UNCOMMENT WHEN LOAD IS IMPLIMENTED

                Stream openStream = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Load Job File";
                openFileDialog.Filter = "JSON files|*.json";
                openFileDialog.InitialDirectory = @"C:\Users\machine shop\source\repos\CWLatheTurn\SaveLoad Files"; //functionality confirmed
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((openStream = openFileDialog.OpenFile()) != null)
                        {
                            using (openStream)
                            {
                                StreamReader sr = new StreamReader(openStream);
                                string json = sr.ReadToEnd();
                                sr.Close();
                                


                                DGV1reload(); //reload datatable to datagridview1
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not load file.\n" + ex.Message);
                    }
                }

            }
        }

        //public void ReadSaveFile (string json)
        //{
        //    try
        //    {
        //        string jobInfo;
        //        string dataInfo;


        //    }
        //    catch
        //    { 
            
        //    }
        //}

        public void SaveFile() //Saves JSON file of datatable
        {
            try
            {
                if (true) //allow save conditions here
                {
                    System.Windows.Forms.SaveFileDialog saveDia1;
                    saveDia1 = new System.Windows.Forms.SaveFileDialog();

                    saveDia1.Filter = "JSON Files (*.json)|*.json"; //sets file type
                    saveDia1.Title = "Save Job File"; //form title
                    //saveDia1.DefaultExt = "json"; //sets extension
                    saveDia1.InitialDirectory = defaultPath; //sets initial directory
                    saveDia1.FileName = defaultFileName; //sets file name to saveas

                    DialogResult dr = saveDia1.ShowDialog(); //calls save file dialogue

                    if (dr == DialogResult.OK) //if filename is not an empty string
                    {
                        string path = Path.GetFullPath(saveDia1.FileName); //saves file save path/name to string
                        string saveStr = string.Empty;

                        //saveStr += $"{JobInfoToString(jobInfo)}\n"; //adds jobInfo to save string
                        //saveStr += $"{DataTableToString(dt)}"; //adds converted data table to string

                        outputTB1.Text = $@"{path}: {saveStr}"; //outputs JSON string in textbox for debug
                        File.WriteAllText($@"{path}", saveStr);  //saves string to JSON file                        

                        string readJSON = File.ReadAllText($@"{path}");
                    }
                }
            }
            catch (Exception e) 
            {
                MessageBox.Show("Error: Could not save file. " + e.Message);
            }
        }

        public string SaveConvert (JobInfo jobInfo, DataTable dt)
        {
            string strOutput = "";

            try
            {


                return strOutput;
            }
            catch
            {
                return "Data Conversion to string failed.";
            }
        }

        private void InitDGV1 ()
        {
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add("Angle", typeof(decimal));
            dt.Columns.Add("Value", typeof(decimal));

            DGV1reload();

            int cWidth = 45;
            int cMarg = 2;

            dataGridView1.Columns[0].Width = cWidth - cMarg;
            dataGridView1.Columns[1].Width = (dataGridView1.Width - cWidth) / 2;
            dataGridView1.Columns[2].Width = (dataGridView1.Width - cWidth) / 2;
        }

        private void AddMeas()//adds Measurement row
        {
            string angTxt = AngleTextBox1.Text.Trim();
            string valTxt = textBox1.Text.Trim();
            DataRow dr = dt.NewRow();

            if ((!string.IsNullOrEmpty(angTxt))
                && !string.IsNullOrEmpty(valTxt) //textboxes !null
                && StrIsPositive(valTxt) //value is positive decimal
                && StrIsPositive(angTxt)) //value is decimal
            {
                if (-1 == AngleExists(angTxt)) //checks if angle exists in table
                {
                    dr["#"] = dt.Rows.Count + 1;
                    dr["Angle"] = decimal.Parse(angTxt);
                    dr["Value"] = decimal.Parse(valTxt);

                    dt.Rows.Add(dr);//modify code to add measurement in the appropriate spot in table and update row number
                }
            }
            DGV1settings();
        }

        private void ModMeas()//modifies Angle and/or Measurement value
        {
            string angTxt = AngleTextBox1.Text.Trim();
            string valTxt = textBox1.Text.Trim();

            int rowIndex;
            if (!(ValidateMeasInput())) //exits method if inputs are not valid
            {
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0) //row is selected
            {
                rowIndex = dataGridView1.SelectedRows[0].Index;
                if (!string.IsNullOrEmpty(angTxt)) //angle input is !NULL
                {
                    if (-1 == AngleExists(angTxt))
                    {
                        ModAngle(Decimal.Parse(angTxt), rowIndex); //modifies Angle and meas value in selected row if Angle value does not exist in data
                        if (null != valTxt) ModValue(Decimal.Parse(valTxt), rowIndex);
                    }
                    else
                    {
                        if (AngleExists(angTxt) == rowIndex && !string.IsNullOrEmpty(valTxt)) //if angle input matches row angle and meas val input exists, row val is modifies
                        {
                            ModValue(Decimal.Parse(valTxt), rowIndex); //modifies measurement value if the input angle is the same value as the selected row                            
                        }
                        else InvInputStatus('x');
                    }
                }
                else //no angle input and row is selected
                {
                    if (null == valTxt)
                    {
                        InvInputStatus('v'); return;
                    }
                    else ModValue(Decimal.Parse(valTxt), rowIndex);
                }
            }
            DGV1settings();
            DGV1reload();
        }

        private void MeasTypeChange(object sender, EventArgs e) //switches grid view values between radius/indicator reading (UNFINISHED)
        {
            //change column header name
            //popup zero-indicator reading value
            foreach (DataColumn dc in dt.Columns)
            {
                //if meastype = radius
                //if meastype = reading
            }
        }

        private void MeasListSort() //resort and update list in DataGridView (UNFINISHED)
        {

        }

        private void DGV1settings() //settings for datagridview1
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void DGV1reload() //reloads DGV1
        {
            dataGridView1.DataSource = dt;
        }

        private void ModAngle(decimal angle, int rowIndex) //modifies Angle in data table at rowindex
        {
            dt.Rows[rowIndex].SetField("Angle", angle);
            //re-sort angle into appropriate place in data table ///////////////////////////////////////////////////
        }

        private void ModValue(decimal value, int rowIndex) //modifies Value in data table at rowindex
        {
            dt.Rows[rowIndex].SetField("Value", value);
        }


        //INPUT/DATA VALIDATION
        private int AngleExists(string angle) //returns index of row with matching angle value or -1 if angle is not found
        {
            int rowIndex = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (angle == dr["Angle"].ToString()) //checks to see if angle string matches value from Angle column in row
                {
                    return rowIndex; //returns row index if matching
                }
                rowIndex++; //increments rowIndex value
            }
            return -1; //returns -1 if value is not found
        }

        private bool ValidateMeasInput() //checks validity of Value/Angle inputs, returns validity: true/false
        {
            string angTxt = AngleTextBox1.Text.Trim();
            string valTxt = textBox1.Text.Trim();
            bool valValid = true;
            bool angValid = true;
            if (null == valTxt && null == angTxt) //input boxes are empty
            {
                InvInputStatus('e');
                return false;
            }
            if (null != valTxt
                && (!StrIsDecimal(valTxt) || !StrIsPositive(valTxt))) //sets var to false if value is not a positive decimal
            {
                valValid = false;
            }
            if ("" != angTxt //value is not null
                && !StrIsDecimal(angTxt) //value is not decimal
                && (360 <= decimal.Parse(angTxt) //value >= 360
                    || false))
            {
                angValid = false; //sets var to false if angle input is invalid;
            }
            if (!valValid)
            {
                if (!angValid)  //value and angle invalid --> status error
                {
                    InvInputStatus('b');
                }
                else  //value invalid, angle valid
                {
                    InvInputStatus('v');
                }
                return false;
            }
            else if (!angValid) //angle invalid, value valid
            {
                InvInputStatus('a');
                return false;
            }
            return true;
        }

        private void InvInputStatus(char c) //status label input error output
        {
            string angError = "Invalid angle input.";
            string valError = $"Invalid {comboBox1.Text} input.";
            string noInput = $"Missing angle and {comboBox1.Text} input.";
            string angExists = "[Angle already exists]";
            string str = "Invalid Input.";
            switch (c)
            {
                case 'a':
                    str = angError;
                    break;
                case 'v':
                    str = valError;
                    break;
                case 'b':
                    str = angError + valError;
                    break;
                case 'e':
                    str = noInput;
                    break;
                case 'x':
                    str = $"{angError} {angExists}";
                    break;
            }
            toolStripStatusLabel1.Text = str;
        }

        private bool StrIsPositive(string str) //returns true if input is !null and a positive decimal
        {
            if (str == null)
            {
                return false;
            }
            decimal dec;
            if (Decimal.TryParse(str, out dec) && 0 <= dec) return true;
            return false;
        }

        private bool StrIsDecimal(string str) //returns true if String is a decimal
        {
            if (Decimal.TryParse(str, out _)) return true;
            return false;
        }


        //FORM DESIGNER GENERATED CODE
        private void addButton1_Click(object sender, EventArgs e)
        {
            AddMeas();
            //AngleTextBox1.Select();
        }

        private void modButton2_Click(object sender, EventArgs e)
        {
            ModMeas();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                AddMeas();
                AngleTextBox1.Select();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void remButton3_Click(object sender, EventArgs e)
        {
            //outputTB1Print();
            //outputTB1.AppendText(Environment.NewLine);
            //outputTB1.AppendText($"Num values in dt: {(dt.Rows.Count * 2).ToString()}");
            string str = "JobInfo:{WO, 12345; Name, Sick Nancheth; Engine, LS3; CrankMfg, OE; Date, 11/3/2020 12:00:00 AM; ImbaRad, 3.25; ImbaAng, 0; ImbaMass, 0} | Measurements:{0,1;2,3;4,5}";
            StringToMeasTable(str);
        }
    }
}
