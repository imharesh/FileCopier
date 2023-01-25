using System;
using System.IO;
// class define
class FileCopier
{
    // main
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the InputPath:");
        string inputPath = Console.ReadLine();

        Console.WriteLine("Enter the OutputPath:");
        string outputPath = Console.ReadLine();

        Console.WriteLine("Enter File Name:-");
        string fileName = Console.ReadLine();

        try
        {
            //Main method calls the Filecopier method, passing in the input path, output path, and file name as arguments.

            Filecopier(inputPath, outputPath, fileName);
        }

        // catch  FileNotFoundException
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File not found: " + ex.Message);
        }
        // catch  IOException

        catch (IOException ex)
        {
            Console.WriteLine("IO error: " + ex.Message);
        }

        // catch Exception
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    //Filecopier method define
    static void Filecopier(string inputPath, string outputPath, string fileName)
    {
        //Filecopier method creates a FileInfo object

        FileInfo inputFile = new FileInfo(inputPath + "\\" + fileName);
        FileInfo outputFile = new FileInfo(outputPath + "\\" + fileName);
        FileInfo temp = null;

        using (FileStream readFile = new FileStream(inputPath + "\\" + fileName, FileMode.Open))
        {
            if (inputFile.Exists)
            {
                if (outputFile.Exists)
                {
                    temp = new FileInfo(outputPath + "\\" + fileName.Substring(0, fileName.IndexOf(".")) + " - Copy" + fileName.Substring(fileName.IndexOf("."), fileName.Length - fileName.IndexOf(".")));

                    if (temp.Exists)
                    {
                        int i = 2;
                        while (true)
                        {
                            temp = new FileInfo(outputPath + "\\" + fileName.Substring(0, fileName.IndexOf(".")) + " - Copy (" + i + ")" + fileName.Substring(fileName.IndexOf("."), fileName.Length - fileName.IndexOf(".")));
                            if (!temp.Exists)
                            {
                                break;
                            }
                            i++;
                        }
                        using (FileStream writeFile = new FileStream(outputPath + "\\" + fileName.Substring(0, fileName.IndexOf(".")) + " - Copy (" + i + ")" + fileName.Substring(fileName.IndexOf("."), fileName.Length - fileName.IndexOf(".")), FileMode.Create))
                        {
                            readFile.CopyTo(writeFile);
                        }
                        Console.WriteLine("File copied successfully.");
                    }
                    else
                    {
                        using (FileStream writeFile = new FileStream(outputPath + "\\" + fileName.Substring(0, fileName.IndexOf(".")) + " - Copy" + fileName.Substring(fileName.IndexOf("."), fileName.Length - fileName.IndexOf(".")), FileMode.Create))
                        {
                            readFile.CopyTo(writeFile);
                        }
                        Console.WriteLine("File copied successfully.");
                    }
                }
                else
                {
                    using (FileStream writeFile = new FileStream(outputPath + "\\" + fileName, FileMode.Create))
                    {
                        readFile.CopyTo(writeFile);
                    }
                    Console.WriteLine("File copied successfully.");
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
    }
}