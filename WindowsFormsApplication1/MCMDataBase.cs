using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.IO;
using ADOX; //Requires Microsoft ADO Ext. 2.8 for DDL and Security
using INI;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SQLite;

namespace MCMDB
{
    class MCMDataBase
    {
        string connectionString = "";//数据库连接字符串       
        SQLiteConnection db ;
        string cmdString = null;//SQL命令字符串
        public bool filecheck;
        public DataTable data;
        SQLiteCommand cmd;
        SQLiteDataAdapter da;
        
        public SQLiteDataReader reader;
        public string[] ColumnNamelist;
        public string[] ColumnNameWithType;
        public void Connect(string path)
        {
            var binFolderPah = path;//获取文件夹绝对路径，.mdb文件在此文件夹下
            var Databasepath = new ADOX.Catalog();
            connectionString = binFolderPah;//
            filecheck = File.Exists(binFolderPah);
            if (!File.Exists(binFolderPah))
            {

                SQLiteConnection.CreateFile(connectionString);

            }

            db = new SQLiteConnection("Data source="+connectionString);
            db.Open();

        }
        public void Close()
        {
           
            db.Close();

        }
        public void CreateTable(string TableName, String[] ColumnNameWithType)
        {
            cmdString = "create table [" + TableName + "](IndexNumber INTEGER PRIMARY KEY AUTOINCREMENT";
            for (int i = 0; i < ColumnNameWithType.Length - 1; i++)
            {
                cmdString = cmdString + "," + ColumnNameWithType[i];
            }
            cmdString = cmdString + "," + ColumnNameWithType[ColumnNameWithType.Length - 1] + ")";           
            cmd = new SQLiteCommand(cmdString, db);          
            cmd.ExecuteNonQuery();          
        }
        public void RenameTable(string OldTableName, string NewTableName)
        {
            try
            {
            cmdString = "ALTER TABLE [" + OldTableName + "] RENAME TO [" + NewTableName + "]";
            cmd = new SQLiteCommand(cmdString, db);
            cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }


        }

        public void DropTable(string TableName)
        {
            cmdString = "DROP TABLE [" + TableName + "]";
            cmd = new SQLiteCommand(cmdString, db);
            
            cmd.ExecuteNonQuery();
            
        }

        public void DeleteRowbyIndexnumber(string TableName, int indexn)
        {
            cmdString = "delete from [" + TableName + "] where IndexNumber=" + Convert.ToString(indexn);
            cmd = new SQLiteCommand(cmdString, db);
            
            cmd.ExecuteNonQuery();
            
        }

        public void DeleteRowbyOAName(string TableName, string OAName)
        {

            cmdString = "delete from [" + TableName + "] where OAName='" + OAName + "'";
            cmd = new SQLiteCommand(cmdString, db);
            
            cmd.ExecuteNonQuery();
           
        }
        public void EmptyTable(string TableName)
        {
            cmdString = "delete from [" + TableName + "]";
            cmd = new SQLiteCommand(cmdString, db);
            
            cmd.ExecuteNonQuery();
           
        }

        public void InsertTable(string TableName, string[] ColumnNamelist, string[] AllColumnValuelist)
        {

            cmdString = "INSERT INTO [" + TableName + "](";
            for (int i = 0; i < ColumnNamelist.GetLongLength(0) - 1; i++)
            {
                cmdString = cmdString + ColumnNamelist[i] + ",";
            }
            cmdString = cmdString + ColumnNamelist[AllColumnValuelist.GetLongLength(0) - 1] + ") VALUES ('";
            for (int j = 0; j < AllColumnValuelist.GetLongLength(0) - 1; j++)
            {
                cmdString = cmdString + AllColumnValuelist[j] + "','";
            }
            cmdString = cmdString + AllColumnValuelist[AllColumnValuelist.GetLongLength(0) - 1] + "')";
            cmd = new SQLiteCommand(cmdString, db);
           
            cmd.ExecuteNonQuery();
            

        }

        public void InsertTable2D(string TableName, string[] ColumnNamelist, string[,] AllColumnValuelist2D)
        {
            try
            {
                for (int i = 0; i < AllColumnValuelist2D.GetLongLength(0); i++)
                {
                    cmdString = "INSERT INTO [" + TableName + "](";
                    for (int j = 0; j < ColumnNamelist.GetLongLength(0) - 1; j++)
                    {
                        cmdString = cmdString + ColumnNamelist[j] + ",";
                    }
                    cmdString = cmdString + ColumnNamelist[ColumnNamelist.GetLongLength(0) - 1] + ") VALUES ('";
                    for (int k = 0; k < AllColumnValuelist2D.GetLongLength(1) - 1; k++)
                    {
                        cmdString = cmdString + AllColumnValuelist2D[i, k] + "','";
                    }
                    cmdString = cmdString + AllColumnValuelist2D[i, AllColumnValuelist2D.GetLongLength(1) - 1] + "')";
                    cmd = new SQLiteCommand(cmdString, db);
                    
                    cmd.ExecuteNonQuery();
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("DataBase Error!" + "\n" + ex.Message);
            }
        }

        public void UpdateTable(string TableName, string[] ColumnNamelist, string[] AllColumnValuelist, int indexnumber)
        {


            cmdString = "update [" + TableName + "] set ";
            for (int i = 0; i < AllColumnValuelist.GetLongLength(0) - 1; i++)
            {
                cmdString = cmdString + ColumnNamelist[i] + "='" + AllColumnValuelist[i] + "',";
            }
            cmdString = cmdString + ColumnNamelist[AllColumnValuelist.GetLongLength(0) - 1] + "='" + AllColumnValuelist[AllColumnValuelist.GetLongLength(0) - 1] + "' Where IndexNumber=" + Convert.ToString(indexnumber);
            cmd = new SQLiteCommand(cmdString, db);
           
            cmd.ExecuteNonQuery();
           


        }
        public void UpdateTablebyOAName(string TableName, string[] ColumnNamelist, string ColumnValue, string OAName)
        {


            cmdString = "update [" + TableName + "] set ";
            for (int i = 0; i < ColumnNamelist.GetLongLength(0); i++)
            {
                cmdString = cmdString + ColumnNamelist[i] + "='" + ColumnValue + "'";
            }
            cmdString = cmdString + " Where OAName='" + OAName + "'";
            cmd = new SQLiteCommand(cmdString, db);
            
            cmd.ExecuteNonQuery();
            


        }
        public void UpdateColumnbyIndex(string TableName, string ColumnName, string ColumnValue, int indexnumber)
        {

            cmdString = "update [" + TableName + "] set " + ColumnName + "='" + ColumnValue + "'" + " Where IndexNumber=" + Convert.ToString(indexnumber);
            cmd = new SQLiteCommand(cmdString, db);
            
            cmd.ExecuteNonQuery();
           


        }
        public void UpdateColumnbyOAName(string TableName, string ColumnName, string ColumnValue, string OAName)
        {

            cmdString = "update [" + TableName + "] set " + ColumnName + "='" + ColumnValue + "'" + " Where " + ColumnName + "='" + OAName + "'";
            cmd = new SQLiteCommand(cmdString, db);
           
            cmd.ExecuteNonQuery();
          


        }


        public void UpdateTable2D(string TableName, string[] ColumnNamelist, string[,] AllColumnValuelist2D)
        {
            for (int i = 0; i < AllColumnValuelist2D.GetLongLength(0); i++)
            {
                cmdString = "update [" + TableName + "] set ";

                for (int j = 0; j < AllColumnValuelist2D.GetLongLength(1) - 1; j++)
                {
                    cmdString = cmdString + ColumnNamelist[j] + "='" + AllColumnValuelist2D[i, j] + "',";
                }
                cmdString = cmdString + ColumnNamelist[AllColumnValuelist2D.GetLongLength(1) - 1] + "='" + AllColumnValuelist2D[i, AllColumnValuelist2D.GetLongLength(1) - 1] + "' Where IndexNumber=" + Convert.ToString(i + 1);
                cmd = new SQLiteCommand(cmdString, db);
                
                cmd.ExecuteNonQuery();
                

            }
           
        }


        public void SelectTable(string TableName)
        {
                                           
            try
            {
                cmdString = "select * from [" + TableName + "] order by IndexNumber";    //max(index) 
                cmd = new SQLiteCommand(cmdString, db);
                
                da = new SQLiteDataAdapter(cmd);
                //data.Clear();
                //DataSet ds = new DataSet();
                //ds.Clear();
                data = new DataTable();
                da.Fill(data);
                //data = ds.Tables[0];
                //if (db.State == ConnectionState.Open) db.Close();
                
                //data = db.ExecuteDataTable(cmdString, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show("DataBase Error!" + "\n" + ex.Message);
            }

        }
        public void SelectTableorderbydate(string TableName)
        {
            
            cmdString = "select OAvalue,Datadate from [" + TableName + "] order by Datadate asc";    //max(index) 
            cmd = new SQLiteCommand(cmdString, db);
            
            da = new SQLiteDataAdapter(cmd);
            data = new DataTable();
            da.Fill(data);
           

        }
        public void SelectOAValueBetweenDate(string TableName,string startdate, string enddate)
        {
           
            cmdString = "select OAvalue,Datadate from [" + TableName + "] where Datadate Between '"+startdate+ "' And '"+ enddate+"'";    //max(index)    
            cmd = new SQLiteCommand(cmdString, db);
            
            da = new SQLiteDataAdapter(cmd);
            //data.Clear();
            data = new DataTable();
            da.Fill(data);
           
            //DataSet ds = new DataSet();
            //ds.Clear();
            
            //data = ds.Tables[0];
            //if (db.State == ConnectionState.Open) db.Close();
            //data = db.ExecuteDataTable(cmdString, null);

        }
        public void SelectAlarm(string TableName)
        {
            cmdString = "select Alarm from [" + TableName + "] where IndexNumber ==(SELECT max(IndexNumber) FROM ["+ TableName + "])";    //max(index) 
            cmd = new SQLiteCommand(cmdString, db);

            reader = cmd.ExecuteReader();

        }
        public void SelectWarning(string TableName)
        {
            cmdString = "select Warning from [" + TableName + "] where IndexNumber ==(SELECT max(IndexNumber) FROM [" + TableName + "])";   //max(index) 
            cmd = new SQLiteCommand(cmdString, db);

            reader = cmd.ExecuteReader();

        }
        public void SelectUnit(string TableName)
        {
            cmdString = "select Unit from [" + TableName + "] where IndexNumber ==(SELECT max(IndexNumber) FROM [" + TableName + "])";   //max(index) 
            cmd = new SQLiteCommand(cmdString, db);

            reader = cmd.ExecuteReader();

        }
        public void SelectMaxdate(string TableName)
        {
            cmdString = "select max(Datadate) from [" + TableName + "]";    //max(index) 
            cmd = new SQLiteCommand(cmdString, db);
            
            reader = cmd.ExecuteReader();
            
        }

        public void ResetTableIndex(string TableName)
        {
            cmdString = "UPDATE sqlite_sequence SET seq = 0 WHERE name =  '" + TableName + "'";    //max(index) 
            cmd = new SQLiteCommand(cmdString, db);
            cmd.ExecuteNonQuery();
        }
        public void VACUUM()
        {
            cmdString = "vacuum";    //max(index) 
            cmd = new SQLiteCommand(cmdString, db);
            cmd.ExecuteNonQuery();
        }

        public void InitialColumn(string path,string iniFilename)
        {
            IniFileName INI;
            var FolderPah = path + "\\" + iniFilename + ".ini";
            INI = new INI.IniFileName(FolderPah);
            if (!File.Exists(FolderPah))
            {
                if (iniFilename == "OA")
                {
                    INI.IniWriteValue("ColumnName", "Column1", "ChName");
                    INI.IniWriteValue("ColumnName", "Column2", "AnaName");
                    INI.IniWriteValue("ColumnName", "Column3", "OAvalue");
                    INI.IniWriteValue("ColumnName", "Column4", "Unit");
                    INI.IniWriteValue("ColumnName", "Column5", "StartBand");
                    INI.IniWriteValue("ColumnName", "Column6", "EndBand");
                    INI.IniWriteValue("ColumnName", "Column7", "Warning");
                    INI.IniWriteValue("ColumnName", "Column8", "Alarm");
                    INI.IniWriteValue("ColumnName", "Column9", "Datadate");
                    INI.IniWriteValue("ColumnType", "Type1", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type2", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type3", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type4", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type5", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type6", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type7", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type8", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type9", "date");
                }
                if (iniFilename == "UI")
                {

                    INI.IniWriteValue("ColumnName", "Column1", "RowCh0");
                    INI.IniWriteValue("ColumnName", "Column2", "RowCh1");
                    INI.IniWriteValue("ColumnName", "Column3", "RowCh2");
                    INI.IniWriteValue("ColumnName", "Column4", "RowCh3");
                    INI.IniWriteValue("ColumnName", "Column5", "FFTCh0");
                    INI.IniWriteValue("ColumnName", "Column6", "FFTCh1");
                    INI.IniWriteValue("ColumnName", "Column7", "FFTCh2");
                    INI.IniWriteValue("ColumnName", "Column8", "FFTCh3");
                    INI.IniWriteValue("ColumnName", "Column9", "NormalDataRecord");
                    INI.IniWriteValue("ColumnName", "Column10", "TextDataRecord");
                    INI.IniWriteValue("ColumnName", "Column11", "NormalSechedule");
                    INI.IniWriteValue("ColumnName", "Column12", "NormalAverages");
                    INI.IniWriteValue("ColumnName", "Column13", "DDS");
                    INI.IniWriteValue("ColumnName", "Column14", "HDSpaces");
                    INI.IniWriteValue("ColumnName", "Column15", "BandWidth");
                    INI.IniWriteValue("ColumnName", "Column16", "Resolution");
                    INI.IniWriteValue("ColumnType", "Type1", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type2", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type3", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type4", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type5", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type6", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type7", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type8", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type9", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type10", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type11", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type12", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type13", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type14", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type15", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type16", "VARCHAR");
                }
                if (iniFilename == "Channel")
                {
                    INI.IniWriteValue("ColumnName", "Column1", "Channe1Number");
                    INI.IniWriteValue("ColumnName", "Column2", "ChannelEnable");
                    INI.IniWriteValue("ColumnName", "Column3", "ChannelType");
                    INI.IniWriteValue("ColumnName", "Column4", "ChannelSense");
                    INI.IniWriteValue("ColumnName", "Column5", "ChannelHPFilter");
                    INI.IniWriteValue("ColumnName", "Column6", "ChannelMode");
                    INI.IniWriteValue("ColumnType", "Type1", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type2", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type3", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type4", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type5", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type6", "VARCHAR");
                }
                if (iniFilename == "Monitor")
                {
                    INI.IniWriteValue("ColumnName", "Column1", "OATableName");
                    INI.IniWriteValue("ColumnName", "Column2", "MonitorName");
                    INI.IniWriteValue("ColumnName", "Column3", "MonitorUnit");
                    INI.IniWriteValue("ColumnName", "Column4", "MonitorStartFreq");
                    INI.IniWriteValue("ColumnName", "Column5", "MonitorEndFreq");
                    INI.IniWriteValue("ColumnName", "Column6", "MonitorWarning");
                    INI.IniWriteValue("ColumnName", "Column7", "MonitorAlarm");
                    INI.IniWriteValue("ColumnType", "Type1", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type2", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type3", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type4", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type5", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type6", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type6", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type7", "VARCHAR");
                }
                if (iniFilename == "OAName")
                {
                    INI.IniWriteValue("ColumnName", "Column1", "OAName");
                    INI.IniWriteValue("ColumnType", "Type1", "VARCHAR");
                }
                if (iniFilename == "AlarmLog")
                {
                    INI.IniWriteValue("ColumnName", "Column1", "AlarmMessage");
                    INI.IniWriteValue("ColumnName", "Column2", "Datadate");
                    INI.IniWriteValue("ColumnType", "Type1", "VARCHAR");
                    INI.IniWriteValue("ColumnType", "Type2", "date");
                }

            }

            string[] SectionHeader = INI.GetSectionNames();
            string[] temp1 = new string[INI.GetEntryNames(SectionHeader[0]).Length];
            ColumnNamelist = new string[INI.GetEntryNames(SectionHeader[0]).Length];
            ColumnNameWithType = new string[INI.GetEntryNames(SectionHeader[0]).Length];
            int Secctionindex, Coulmnindex;
            try
            {

                if (SectionHeader != null)
                {
                    Secctionindex = 0;
                    Coulmnindex = 0;
                    foreach (string SecHead in SectionHeader)
                    {

                        string[] Entry = INI.GetEntryNames(SecHead);

                        if (Entry != null)
                        {
                            foreach (string EntName in Entry)
                            {
                                temp1[Coulmnindex] = (string)INI.GetEntryValue(SecHead, EntName);
                                if (Secctionindex > 0)
                                {
                                    ColumnNameWithType[Coulmnindex] = ColumnNamelist[Coulmnindex] + " " + temp1[Coulmnindex];

                                }
                                else
                                {
                                    ColumnNamelist[Coulmnindex] = temp1[Coulmnindex];
                                }

                                Coulmnindex++;
                            }
                            Coulmnindex = 0;
                        }
                        Secctionindex++;


                    }
                }
            }
            catch (Exception ex)
            {


            }


        }
    }
}
