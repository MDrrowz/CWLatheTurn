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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using static CWLatheTurn.Form1;
using System.Reflection;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CWLatheTurn
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitDGV1();
        }

        //DATA
        DataTable dt = new DataTable();
        DataTable st = new DataTable();
        JobInfo savedInfo = new JobInfo
        {
            WO = "12345",
            Name = "Sick Nancheth",
            Engine = "LS3",
            CrankMfg = "OE",
            Date = new DateTime(2020, 11, 3),
            ImbaRad = 3.25m,
        };

        string defaultPath = Path.GetFullPath(@"C:\Users\machine shop\source\repos\CWLatheTurn\SaveLoad Files");
        string defaultFileName = "ThisIsTheDefaultFileName";

        Color tbInvalid = Color.Yellow;

        public static class Delims
        {
            public const string infoData = "`||`";
            public const string type = "#:";
            public const string propVal = ",*";
            public const string measInfo = ";`";
            public const string start = "^{";
            public const string end = "}^";
        }
        public class JobInfo
        {
            public string WO { get; set; }
            public string Name { get; set; }
            public string Engine { get; set; }
            public string CrankMfg { get; set; }
            public DateTime Date { get; set; }
            public decimal ImbaRad { get; set; }
            public decimal ImbaAng { get; set; }
            public decimal ImbaMass { get; set; }
        }

        string SaveDataSerialize(JobInfo ji, DataTable mt) //serializes Job Info and Datatable and returns string
        {
            StringBuilder outString = new StringBuilder();
            return outString.Append($"{JobInfoToString(ji)}{Delims.infoData}{MeasTableToString(mt)}").ToString();
        }

        string JobInfoToString(JobInfo info) //Serializes Job Info data and returns string
        {
            PropertyInfo[] props = typeof(JobInfo).GetProperties();
            StringBuilder sb = new StringBuilder();
            sb.Append($"JobInfo{Delims.type}{Delims.start}");
            try
            {
                string str = String.Empty;
                int iter = 1;
                foreach (PropertyInfo prop in props)
                {
                    sb.Append($"{prop.Name}{Delims.propVal}{prop.GetValue(info)}");
                    if (iter < props.Count()) sb.Append($"{Delims.measInfo}");
                    iter++;
                }
            }
            catch
            {
                sb.Append("Datatable is NULL");
            }
            sb.Append($"{Delims.end}");
            return sb.ToString();
        }

        string MeasTableToString(DataTable dt) //Serializes measurement datatable info and returns string 
        {


            StringBuilder sb = new StringBuilder($"Measurements{Delims.type}{Delims.start}");

            if (dt != null)
            {
                int iter = 1;
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append($"{row[1]}{Delims.propVal}{row[2]}");
                    if (iter < dt.Rows.Count) sb.Append($"{Delims.measInfo}");
                    iter++;
                }
            }
            sb.Append($"{Delims.end}");
            return sb.ToString();
        }

        void StringToMeasTable(string saveStr) //[WORKS]Takes serialized saveinfo string and inputs measurement info in datatable
        {
            dt.Rows.Clear(); //clears datatable
            outputTB1.Clear();

            string[] dID = { Delims.infoData };
            string[] dType = { Delims.type };
            string[] dPV = { Delims.propVal };
            string[] dMI = { Delims.measInfo };
            string[] dS = { Delims.start };
            string[] dE = { Delims.end };
            string[] subStr1 = saveStr.Split(dID, StringSplitOptions.None)[1]
                .Split(dType, StringSplitOptions.None)[1]
                .Split(dS, StringSplitOptions.None)[1]
                .Split(dE, StringSplitOptions.None)[0]
                .Split(dMI, StringSplitOptions.None);

            int i = 1;

            foreach (string subStr2 in subStr1)
            {
                outputTB1.Text += $"subStr2: {subStr2}{Environment.NewLine}";
            }

            foreach (string subStr2 in subStr1)
            {
                string[] meas = subStr2.Split(dPV, StringSplitOptions.None);
                dt.Rows.Add(i, meas[0], meas[1]);
                i++;
            }
            DGV1reload();
        }

        void StringToJobInfo(string saveStr)
        {
            string[] dID = { Delims.infoData };
            string[] dType = { Delims.type };
            string[] dPV = { Delims.propVal };
            string[] dMI = { Delims.measInfo };
            string[] dS = { Delims.start };
            string[] dE = { Delims.end };

            string[] subStr1 = saveStr.Split(dID, StringSplitOptions.None)[0]
                .Split(dType, StringSplitOptions.None)[1]
                .Split(dS, StringSplitOptions.None)[1]
                .Split(dE, StringSplitOptions.None)[0]
                .Split(dMI, StringSplitOptions.None);

            JobInfo testInfo = new JobInfo();

            //int i = 1;
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            outputTB1.Text = $"subStr1.count = {subStr1.Length}";

            foreach (string subStr2 in subStr1)
            {
                string propName = subStr2.Split(dPV, StringSplitOptions.None)[0].Trim();
                string propValue = subStr2.Split(dPV, StringSplitOptions.None)[1].Trim();

                PropertyInfo propertyInfo = typeof(JobInfo).GetProperty(propName);

                if (TryGetPropertyType<JobInfo>(propName, out Type propType))
                {
                    switch (propType.Name)
                    {
                        case "String":
                            propertyInfo.SetValue(testInfo, propValue);
                            sb.Append(propStoredString(propValue, propName, propType));
                            break;
                        case "Decimal":
                            decimal decOut;
                            if (decimal.TryParse(propValue, out decOut))
                            {
                                propertyInfo.SetValue(testInfo, decOut);
                            }
                            sb.Append(propStoredString(propValue, propName, propType));
                            break;
                        case "DateTime":
                            DateTime dtOut;
                            if (DateTime.TryParse(propValue, out dtOut))
                            {
                                propertyInfo.SetValue(testInfo, dtOut);
                            }
                            sb.Append(propStoredString(propValue, propName, propType));
                            break;
                        case "Int":
                            int intOut;
                            if (int.TryParse(propValue, out intOut))
                            {
                                propertyInfo.SetValue(testInfo, intOut);
                            }
                            sb.Append(propStoredString(propValue, propName, propType));
                            break;
                        // Add more cases for other types as needed
                        default:
                            Console.WriteLine($"Property '{propName}' is of unknown type: {propType.Name}");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Property '{propName}' not found.");
                }
            }
            outputTB1.AppendText($"{sb}{Environment.NewLine}{JobInfoToString(testInfo)}");
        }

        private string propStoredString(string pV, string pN, Type pT)
        {
            return ($"Value '{pV}' of type '{pT.Name}' stored in property '{pN}'.{Environment.NewLine}");
        }

        static bool TryGetPropertyType<T>(string propertyName, out Type propertyType)
        {
            Type type = typeof(T);
            PropertyInfo property = type.GetProperty(propertyName);

            if (property != null)
            {
                propertyType = property.PropertyType;
                return true;
            }
            else
            {
                propertyType = null;
                return false;
            }
        }


        //SAVE/LOAD FILE
        public string readSaveFile() //unfinished
        {
            if (true) //ADD LOAD CONDITIONS HERE (SET TO TRUE FOR DEBUG)
            {
                st.Clear(); //clears storage datatable
                st = dt; //save measurement datatable to storage datatable

                Stream openStream = null; //createes empty IOstream
                OpenFileDialog openFileDialog = new OpenFileDialog(); //opens load file dialogue
                openFileDialog.Title = "Load Job File";
                openFileDialog.Filter = "Counter-Weight Lathe Turn files|*.cwlt";
                openFileDialog.InitialDirectory = @"C:\Users\machine shop\source\repos\CWLatheTurn\SaveLoad Files"; //functionality confirmed, add functionality to establish default save file in settings
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((openStream = openFileDialog.OpenFile()) != null)
                        {
                            using (openStream)
                            {
                                StreamReader sr = new StreamReader(openStream);
                                string cwlt = sr.ReadToEnd();
                                sr.Close();
                                return cwlt;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not load file.\n" + ex.Message);
                        return null;
                    }
                }
            }
            return null;
        }

        public void ImportStringData(string str)
        {
            StringToMeasTable(str);
            StringToJobInfo(str);
        }

        public void LoadSaveData()
        {
            string loadData = null;
            loadData = readSaveFile();
            try
            {
                if (loadData != null)
                {
                    ImportStringData(loadData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load data could not be properly read/imported.", "Load Data Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveFile() //Saves CWLT file of datatable
        {
            try
            {
                if (true) //allow save conditions here
                {
                    System.Windows.Forms.SaveFileDialog saveDia1;
                    saveDia1 = new System.Windows.Forms.SaveFileDialog();

                    saveDia1.Filter = "CWLT Files (*.cwlt)|*.cwlt"; //sets file type //CHANGE TO MDLATHECALC FILENAME
                    saveDia1.Title = "Save Job File"; //form title
                    saveDia1.DefaultExt = "cwlt"; //sets extension
                    saveDia1.InitialDirectory = defaultPath; //sets initial directory
                    saveDia1.FileName = defaultFileName; //sets file name to saveas

                    DialogResult dr = saveDia1.ShowDialog(); //calls save file dialogue

                    if (dr == DialogResult.OK) //if filename is not an empty string
                    {
                        string path = Path.GetFullPath(saveDia1.FileName); //saves file save path/name to string
                        string saveStr = string.Empty;
                        saveStr = "JobInfo#:^{WO,*12345;`Name,*Sick Nancheth;`Engine,*LS3;`CrankMfg,*OE;`Date,*11/3/2020 12:00:00 AM;`ImbaRad,*3.25;`ImbaAng,*0;`ImbaMass,*0}^`||`Measurements#:^{1,*123;`2,*234;`3,*345;`4,*456}^";

                        outputTB1.Text = $@"{path}: {saveStr}"; //outputs CWLT string in textbox for debug
                        File.WriteAllText($@"{path}", saveStr);  //saves string to CWLT file   
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Could not save file. " + e.Message);
            }
        }

        private void InitDGV1()
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
            if (!ValidateMeasInput()) //exits method if inputs are not valid
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

        private void CWRadButtonText(object sender)
        {
            const string str1 = "CW Radius";
            const string str2 = "Journal to CW";

            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            switch (button.Text)
            {
                case str1: //button text = "CW Radius"
                    button.Text = str2;
                    //disable Radius textbox editing
                    cwrCalcTB.Visible = true;
                    cwrTB.Visible = false;
                    journalDiaTB.Enabled = true;
                    jtcwTB.Enabled = true;
                    break;
                case str2: //button text = "Journal to CW"
                    button.Text = str1; //button text changed to "CW Radius"
                    cwrCalcTB.Visible = false;
                    cwrTB.Visible = true;
                    journalDiaTB.Enabled = false;
                    jtcwTB.Enabled = false;
                    break;
                default:
                    MessageBox.Show("Counter-weight radius input error.", "CW Rad Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            cwRadCalc();
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
                && PosDecCheck(valTxt)) //sets var to false if value is not a positive decimal
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

        private bool PosDecCheck (string str)
        {
            if (StrIsDecimal(str) && StrIsPositive(str)) return true;
            else return false;
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
            if (Decimal.TryParse(str.Trim(), out _)) return true;
            return false;
        }

        private bool tbleaveCheck(object sender) //validates textbox input is a positive decimal or refocuses textbox and changes background to yellow
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            string str = tb.Text;
            if (!StrIsDecimal(str) || !StrIsPositive(str))
            {
                if (str != "")
                {
                    tb.BackColor = tbInvalid;
                    tb.Focus();
                    return false;
                }
            }
            tb.BackColor = SystemColors.Window;
            return true;
        }


        //FORM DESIGNER GENERATED CODE
        private void AddButton1_Click(object sender, EventArgs e)
        {
            AddMeas();
            //AngleTextBox1.Select();
        }

        private void ModButton2_Click(object sender, EventArgs e)
        {
            ModMeas();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
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
            LoadSaveData();
        }

        private void RemButton3_Click(object sender, EventArgs e) //currently debug button
        {
            string str = "JobInfo#:^{WO,*12345;`Name,*Sick Nancheth;`Engine,*LS3;`CrankMfg,*OE;`Date,*11/3/2020 12:00:00 AM;`ImbaRad,*3.25;`ImbaAng,*0;`ImbaMass,*0}^`||`Measurements#:^{1,*123;`2,*234;`3,*345;`4,*456}^";
            //outputTB1.Text = SaveDataSerialize(savedInfo, dt);
            StringToJobInfo(str); //Not storing anything past Crank MFG
            //StringToMeasTable(str); //WORKS!!!!
        }

        private void CWRadButton_Click(object sender, EventArgs e)
        {
            CWRadButtonText(sender);
        }

        private void journalDiaTB_Leave(object sender, EventArgs e)
        {
            tbleaveCheck(sender);
            cwRadCalc();
        }

        private void cwrTB_Leave(object sender, EventArgs e)
        {
            tbleaveCheck(sender);
            cwRadCalc();
        }

        private void jtcwTB_Leave(object sender, EventArgs e)
        {
            tbleaveCheck(sender);
            cwRadCalc();
        }

        void cwRadCalc ()
        {
            cwrCalcTB.Clear();
            const string str1 = "CW Radius";
            const string str2 = "Journal to CW";

            switch (CWRadButton.Text)
            {
                case str1 :
                    if (PosDecCheck(cwrTB.Text)) cwrCalcTB.Text = cwrTB.Text.Trim();
                    break;
                case str2 :
                    if (journalDiaTB.Text.Trim().Length > 0 && jtcwTB.Text.Trim().Length > 0)
                    {
                        decimal d1 = Decimal.Parse(journalDiaTB.Text.Trim()) / 2;
                        decimal d2 = Decimal.Parse(jtcwTB.Text.Trim());
                        cwrCalcTB.Text = (d1 + d2).ToString();
                    }
                    break;
                default :
                    break;
            }


            outputTB1.Text = cwrCalcTB.Text;
        }
    }
}

