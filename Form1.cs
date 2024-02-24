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
using System.CodeDom;
using System.Runtime.Remoting.Messaging;

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
        DataTable displayt = new DataTable();
        DataTable st = new DataTable();
        JobInfo ji = new JobInfo();
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

        string SaveDataSerialize(JobInfo jobInfo, DataTable dataTable) //serializes Job Info and Datatable and returns string
        {
            StringBuilder outString = new StringBuilder();
            return outString.Append(JobInfoToString(jobInfo) + Delims.infoData + MeasTableToString(dataTable)).ToString();
        }

        string JobInfoToString(JobInfo info) //Serializes Job Info data and returns string
        {
            PropertyInfo[] props = typeof(JobInfo).GetProperties();
            StringBuilder sb = new StringBuilder();
            sb.Append($"JobInfo" + Delims.type + Delims.start);
            try
            {
                string str = String.Empty;
                int iter = 1;
                foreach (PropertyInfo prop in props)
                {
                    sb.Append(prop.Name + Delims.propVal + prop.GetValue(info));
                    if (iter < props.Count()) sb.Append(Delims.measInfo);
                    iter++;
                }
            }
            catch
            {
                sb.Append("Datatable is NULL");
            }
            sb.Append(Delims.end);
            return sb.ToString();
        }

        string MeasTableToString(DataTable dt) //Serializes measurement datatable info and returns string 
        {
            StringBuilder sb = new StringBuilder($"Measurements" + Delims.type + Delims.start);
            if (dt != null)
            {
                int iter = 1;
                foreach (DataRow row in dt.Rows)
                {
                    sb.Append(row[1] + Delims.propVal + row[2]);
                    if (iter < dt.Rows.Count) sb.Append(Delims.measInfo);
                    iter++;
                }
            }
            sb.Append(Delims.end);
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
                Console.WriteLine ($"subStr2: " + subStr2 + Environment.NewLine);
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
            StringBuilder sb = new StringBuilder();

            foreach (string subStr2 in subStr1)
            {
                string propName = subStr2.Split(dPV, StringSplitOptions.None)[0].Trim();
                string propValue = subStr2.Split(dPV, StringSplitOptions.None)[1].Trim();
                bool propCheck = true;
                PropertyInfo propertyInfo = typeof(JobInfo).GetProperty(propName);

                if (TryGetPropertyType<JobInfo>(propName, out Type propType))
                {
                    switch (propType.Name) //switch based on property type returned by TryGetPropertyType
                    {
                        case "String":
                            propertyInfo.SetValue(testInfo, propValue);
                            break;
                        case "Decimal":
                            if (decimal.TryParse(propValue, out decimal decOut)) propertyInfo.SetValue(testInfo, decOut);
                            break;
                        case "DateTime":
                            if (DateTime.TryParse(propValue, out DateTime dtOut)) propertyInfo.SetValue(testInfo, dtOut);
                            break;
                        case "Int":
                            if (int.TryParse(propValue, out int intOut)) propertyInfo.SetValue(testInfo, intOut);
                            break;
                        default:
                            Console.WriteLine($"Property '{propName}' is of incompatible type: {propType.Name}");
                            propCheck = false;
                            break;
                    }
                    sb.Append(Environment.NewLine);
                    if (propCheck) sb.Append(propStoredString(propValue, propName, propType)); //debug: appends to stringbuilder for console output
                }
                else
                {
                    Console.WriteLine($"Property '{propName}' not found.");
                }
            }
            Console.WriteLine(sb + Environment.NewLine + JobInfoToString(testInfo)); //debug: outputs reserialized data to console after deserialization
            
        }

        string propStoredString(string pV, string pN, Type pT)
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
        string readSaveFile() //finished?
        {
            if (true) //ADD LOAD CONDITIONS HERE (SET TO TRUE FOR DEBUG)
            {
                st.Clear(); //clears storage datatable
                st = dt; //save measurement datatable to storage datatable

                Stream openStream = null; //creates empty IOstream
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

        void LoadSaveData()
        {
            string loadData = null;
            loadData = readSaveFile();
            try
            {
                if (loadData != null)
                {
                    StringToMeasTable(loadData);
                    StringToJobInfo(loadData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load data could not be properly read/imported. Exception:{ex}", "Load Data Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void SaveFile() //Saves CWLT file of datatable
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
                        saveStr = "JobInfo#:^{WO,*12345;`Name,*Sick Nancheth;`Engine,*LS3;`CrankMfg,*OE;`Date,*11/3/2020 12:00:00 AM;`ImbaRad,*3.25;`ImbaAng,*0;`ImbaMass,*0}^`||`Measurements#:^{1,*123;`2,*234;`3,*345;`4,*456}^"; //debug info string
                        //saveStr = SaveDataSerialize(ji, dt);

                        Console.WriteLine(path + ": " + saveStr); //outputs CWLT string in textbox for debug
                        File.WriteAllText(path, saveStr);  //saves string to CWLT file   
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: Could not save file. " + e.Message);
            }
        }

        void InitDGV1()
        {
            dt.Columns.Add("#", typeof(int));
            dt.Columns.Add("Angle", typeof(decimal));
            dt.Columns.Add("Value", typeof(decimal));
            //dt.Columns.Add("Indicator", typeof(decimal));

            DGV1reload();

            int cWidth = 45;
            int cMarg = 2;

            dataGridView1.Columns[0].Width = cWidth - cMarg;
            dataGridView1.Columns[1].Width = (dataGridView1.Width - cWidth) / 2;
            dataGridView1.Columns[2].Width = (dataGridView1.Width - cWidth) / 2;
            dataGridView1.Columns[2].HeaderText = "Indicator";
        }

        void AddMeas()//adds Measurement row
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

        void ModMeas()//modifies Angle and/or Measurement value
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

        void MeasTypeChange(object sender) //switches grid view values between radius/indicator reading (UNFINISHED)
        {
            const string str1 = "Indicator Reading";
            const string str2 = "Radius";
            //change column header name
            //popup zero-indicator reading value

            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;

            switch (button.Text)
            {
                case str1: //meas type is currently Indicator --> change to radius
                    {
                        dt.Columns[2].ColumnName = str2; //changes column header to Radius
                        panel2.Enabled = false; //disables indicator zero panel

                        button.Text = str2; //changes button text to Radius
                        break;
                    }
                case str2:
                    {
                        dt.Columns[2].ColumnName = str1.Split(' ')[0]; //changes column header to Indicator
                        panel2.Enabled = true; //enables indicator zero panel

                        button.Text = str1; //changes button text to Indicator Reading
                        break;
                    }
            }
        }

        //void MeasListSort() //resort and update list in DataGridView (UNFINISHED)
        //{

        //}

        void DGV1settings() //settings for datagridview1
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }

        void DGV1reload() //reloads DGV1 //currently implements displayt = dt
        {
            displayt.Clear();
            displayt = dt;
            dataGridView1.DataSource = displayt;
        }

        void ModAngle(decimal angle, int rowIndex) //modifies Angle in data table at rowindex
        {
            dt.Rows[rowIndex].SetField("Angle", angle);
            //re-sort angle into appropriate place in data table ///////////////////////////////////////////////////
        }

        void ModValue(decimal value, int rowIndex) //modifies Value in data table at rowindex
        {
            dt.Rows[rowIndex].SetField("Value", value);
        }

        void cwRadCalc()
        {
            cwrCalcTB.Clear();
            const string str1 = "CW Radius";
            const string str2 = "Journal to CW";

            switch (CWRadButton.Text)
            {
                case str1:
                    if (PosDecCheck(cwrTB.Text)) cwrCalcTB.Text = cwrTB.Text.Trim();
                    break;
                case str2:
                    if (journalDiaTB.Text.Trim().Length > 0 && jtcwTB.Text.Trim().Length > 0)
                    {
                        decimal d1 = Decimal.Parse(journalDiaTB.Text.Trim()) / 2;
                        decimal d2 = Decimal.Parse(jtcwTB.Text.Trim());
                        cwrCalcTB.Text = (d1 + d2).ToString();
                    }
                    break;
                default:
                    break;
            }


            outputTB1.Text = cwrCalcTB.Text;
        } //calculates indicator zero radius based on toggle button status

        string JICheck(string input) //add sender //does not work
        {
            input = input.Trim();//trims input string of whitespace
            Console.WriteLine($@"input: ""{input}""{Environment.NewLine}"); //console debug output

            FieldInfo[] fields = typeof(Delims).GetFields();

            foreach (var field in fields)
            {
                string[] delim = { field.GetValue(null).ToString() };
                //Console.WriteLine($"Delim {field.Name}: " + delim[0]);

                string splitStr = input.Split(delim, StringSplitOptions.None)[0];
                //Console.WriteLine($"splitStr = {splitStr}");

                if (input != splitStr)
                {
                    //Console.WriteLine("input != splitStr");
                    StringBuilder sb = new StringBuilder();
                    sb.Append($@"Input: ""{input}"" contains delim string ""{delim[0]}""");
                    return sb.ToString();
                }
            }
            return null;
        }

        void CWRadButtonText(object sender) //changes UI based on indicator zero button toggle
        {
            const string str1 = "Radius";
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
        int AngleExists(string angle) //returns index of row with matching angle value or -1 if angle is not found
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

        bool ValidateMeasInput() //checks validity of Value/Angle inputs, returns validity: true/false
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
            if (("" != angTxt && angTxt != null) //value is not null
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

        bool PosDecCheck(string str)
        {
            if (StrIsDecimal(str) && StrIsPositive(str)) return true;
            else return false;
        }

        void InvInputStatus(char c) //status label input error output
        {
            string angError = "Invalid angle input.";
            string valError = $"Invalid {measTypeButton.Text} input.";
            string noInput = $"Missing angle and {measTypeButton.Text} input.";
            string angExists = "(Angle already exists)";
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine + "Invalid Input.");
            switch (c)
            {
                case 'a':
                    sb.Clear();
                    sb.Append(angError);
                    break;
                case 'v':
                    sb.Clear();
                    sb.Append(valError);
                    break;
                case 'b':
                    sb.Clear();
                    sb.Append(angError + " " + valError);
                    break;
                case 'e':
                    sb.Clear();
                    sb.Append(noInput);
                    break;
                case 'x':
                    sb.Clear();
                    sb.Append(angError + " " + angExists);
                    break;
            }
            toolStripStatusLabel1.Text = sb.ToString();
        }

        bool StrIsPositive(string str) //returns true if input is !null and a positive decimal
        {
            if (str == null)
            {
                return false;
            }
            decimal dec;
            if (Decimal.TryParse(str, out dec) && 0 <= dec) return true;
            return false;
        }

        bool StrIsDecimal(string str) //returns true if String is a decimal
        {
            if (Decimal.TryParse(str.Trim(), out _)) return true;
            return false;
        }

        bool tbleaveCheck(object sender) //validates textbox input is a positive decimal or refocuses textbox and changes background to yellow
        {
            System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
            string str = tb.Text.Trim();
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
        void AddButton1_Click(object sender, EventArgs e)
        {
            AddMeas();
            //AngleTextBox1.Select();
        }

        void ModButton2_Click(object sender, EventArgs e)
        {
            ModMeas();
        }

        void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                AddMeas();
                AngleTextBox1.Select();
            }
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        void LoadButton_Click(object sender, EventArgs e)
        {
            LoadSaveData();
        }

        void RemButton3_Click(object sender, EventArgs e) //currently debug button
        {
            //string str = "JobInfo#:^{WO,*12345;`Name,*Sick Nancheth;`Engine,*LS3;`CrankMfg,*OE;`Date,*11/3/2020 12:00:00 AM;`ImbaRad,*3.25;`ImbaAng,*0;`ImbaMass,*0}^`||`Measurements#:^{1,*123;`2,*234;`3,*345;`4,*456}^";
            //outputTB1.Text = SaveDataSerialize(savedInfo, dt);
            //StringToJobInfo(str); //Not storing anything past Crank MFG
            //StringToMeasTable(str); //WORKS!!!!

            string str = "WO123#:45 ";
            outputTB1.AppendText(Environment.NewLine + $@"JobInfo: ""{str}""; JICheck :" + Environment.NewLine + JICheck(str));

        }

        void CWRadButton_Click(object sender, EventArgs e)
        {
            CWRadButtonText(sender);
        }

        void journalDiaTB_Leave(object sender, EventArgs e)
        {
            tbleaveCheck(sender);
            cwRadCalc();
        }

        void cwrTB_Leave(object sender, EventArgs e)
        {
            tbleaveCheck(sender);
            cwRadCalc();
        }

        void jtcwTB_Leave(object sender, EventArgs e)
        {
            tbleaveCheck(sender);
            cwRadCalc();
        }

        void measTypeButton_Click(object sender, EventArgs e)
        {
            MeasTypeChange(sender);
        }
    }
}

