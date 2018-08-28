using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class XSDConverter {

public static void Main(){
    List<string> paths =readWsdl("wsdl.wsdl");

            for(int i= 0; i < paths.Count; i++)
            {
                string pathTemp = paths.ElementAt(i);
            try{
                var lineCountTemp = File.ReadLines(pathTemp).Count();
                for ( int j = 0; j <= lineCountTemp; j ++)
                {
                    string contentLine;
                    // Read the file and display it line by line.  
                    
                    System.IO.StreamReader file = new System.IO.StreamReader(@pathTemp);
                 while ((contentLine = file.ReadLine()) != null)
                    {
                        //filtrar linea para quedarnos con el path que interesa
                        bool exists = paths.Contains(contentLine);
                        if(!exists)
                        {
                            paths.Add(contentLine);
                                    System.Console.WriteLine(contentLine);

                        }
                    }
                    file.Close();
                 


            }
            }   catch(FileNotFoundException ex){
                      System.Console.WriteLine("file "+pathTemp+" does not exist");

                    }


            }

                    System.IO.File.WriteAllLines(@"WriteLines.txt", paths);

}

public static List<string> readWsdl(string path){
    int counter = 0;  
    string line;  
    List<string> xlds = new List<string> ();
    // Read the file and display it line by line.  
    System.IO.StreamReader file =   
        new System.IO.StreamReader(@path);  
    while((line = file.ReadLine()) != null)  
    {  
        int first = line.IndexOf("<schemaLocation=") + "<schemaLocation=".Length;
        int last = line.IndexOf(" namespace=");
        string str2 = line.Substring(first, last - first);
        //System.Console.WriteLine(str2);
        xlds.Add(str2);  
        counter++;  
    }  

    file.Close();  
    //System.Console.WriteLine("There were {0} lines.", counter);  
    // Suspend the screen.  
    //System.Console.ReadLine();  
    return xlds;
}



}