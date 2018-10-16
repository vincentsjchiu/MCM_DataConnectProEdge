using System;
using System.Collections;
// Set the system to using the INI Namespace within the ReadINI Class
using INI;


namespace MainApp
{
	//	Basic Console Application that will read a Common Windows INI file
	//	and display Enumerate Section Headers, Section Entries and Entries Values.
	
	class Class1
	{

        // The main Console routine.
        [STAThread]
        

        static void Main(string[] args)
		{
			
			//	Sets the INI filename and location to be used.
			//	remember to use a double slash "\\" instead of a single for folder levels.
			IniFileName INI = new INI.IniFileName("C:\\test.ini");
            MCMDataBase database = new MCMDataBase();
            string[] SectionHeader = INI.GetSectionNames();
            string TableName;
            string[] temp1  = new string[INI.GetEntryNames(SectionHeader[0]).Length];            
            string[] temp2= new string[INI.GetEntryNames(SectionHeader[0]).Length]; ;
            int i,j;

            // Use the Try comman to gather the information, if an error occurs then throw an exception.
            // and display the error.
            try 
			{
				// set the SectionHeader into an Dynamic Singlelevel Array.
				// the Information is gathered from the GetSectionNames function INI namespace of the ReadINI Class.
				
                // Checks to see if the SectionHeader has returned null.
                if (SectionHeader != null)
				{
                    // Returns a list EntryKey's for each of the SectionHeader(s).
                    i = 0;
                    j = 0;
                    foreach (string  SecHead in SectionHeader)
					{
                        // Write the SectionHeader to the display.
                        //Console.WriteLine(SecHead);

                        // Sets the Entry Dynamic Array for the each of the EntryKeys within the Section Header.
                        // If you already know the SectionHeader and just need to list the Entry's
                        // then enter the name instead of the SecHead in the GetEntrNames function.
                        // ie.  INI.GetEntryNames("TestSecHead")

                        string[] Entry = INI.GetEntryNames(SecHead);
                        // Checks to see if there's an Entry under the SectionHeader and the Entry has not returned a null
                        if (Entry != null)
						{
							// Enumerates a list of Keys For each of the Entry.
							foreach (string EntName in Entry)
							{
                                // writes to display the value for the Entry key.
                                // If you already know the SectionHeader and the Entry Key values then, replace all the code
                                // after the INIFileName line, with the following
                                // Console.WriteLine(" {0} = {1}","TestKey",INI.GetEntryValue("TestSecHead","TestKey"));
                                // this will display the Value for the Entry key under the given SectionHeader.
                                
                                //Console.WriteLine(" {0} = {1}",EntName,INI.GetEntryValue(SecHead,EntName));
                                temp1[j] = (string)INI.GetEntryValue(SecHead, EntName);
                                if (i >0)
                                {
                                    
                                    temp2[j] = temp2[j] + " " + temp1[j];
                                    Console.WriteLine(temp2[j]);

                                }
                                else
                                {
                                    temp2[j] = temp1[j];
                                }
                                
                                j++;
                            }
                            j = 0;
                        }
                        i++;
                        
				
					}
				}
			}
			// If an error if thrown, catch the exception error
            


            catch (Exception ex)
			{
				// Write the exception error to the display.
				Console.WriteLine("Error:  "+ ex);
			}
            database.Connect("MCMtrend");
            TableName = "Vincentdata";
            database.CreateTable(TableName, temp2);
            // Waits for a "Enter" key to be used. I use this like a pause button.
            Console.ReadLine();
            
		}
	}
}



/*	You can also use the Enumerator function to produce the same results. Here is the code if you wish to use that function.
 *	Replace the code from the "Try" at line 26 until the "console.readline()" at line 71 with this.
 * 
 *			try 
 *			{
 *				IEnumerator e = INI.GetSectionNames().GetEnumerator();
 *				while(e.MoveNext()) 
 *				{
 *					string SectionHead = e.Current.ToString();
 *					Console.WriteLine(e.Current);
 *					IEnumerator d = INI.GetEntryNames(SectionHead).GetEnumerator();
 *					while(d.MoveNext()) 
 *					{
 *						string EntryKey = d.Current.ToString();
 *						Console.WriteLine("{0} = {1}", d.Current,INI.GetEntryValue(SectionHead,EntryKey));
 *					}
 *
 *				}
 *			}
 *			catch (Exception ex)
 *			{
 *				Console.WriteLine( "Exception Error:  {0}", ex);
 *			}
 *			Console.ReadLine();
 * 
 * 
 *  
 * 
 */
